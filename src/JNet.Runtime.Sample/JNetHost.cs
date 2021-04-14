// Copyright (c) Rodrigo Speller. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.

using System;
using System.Runtime.InteropServices;
using JNet.Runtime.Sample.Utils;

namespace JNet.Runtime.Sample
{
    internal static class JNetHost
    {
        private static JNetVirtualMachine vm;
        private static readonly ObjectPool<TaskExecutor> executorsPool = new ObjectPool<TaskExecutor>(CreateTaskExecutor);

        public static void Initialize(JNetConfiguration configuration = null)
        {
            var vm = JNetVirtualMachine.Initialize(configuration);

            JNetHost.vm = vm;
        }

        public static void Run(Action<JNetRuntime> task)
        {
            var executor = executorsPool.Get();
            try
            {
                executor.Run(task);
            }
            finally
            {
                executorsPool.Return(executor);
            }
        }

        public static T Run<T>(Func<JNetRuntime, T> task)
        {
            T result = default;

            Run(runtime =>
            {
                result = task(runtime);
            });

            return result;
        }

        private static TaskExecutor CreateTaskExecutor()
        {
            var vm = JNetHost.vm
                ?? throw new InvalidOperationException($"{nameof(JNetHost)} is not initialized.");

            return new TaskExecutor(vm);
        }

        public unsafe static void Release(void* ptr)
            => Marshal.FreeCoTaskMem((IntPtr)ptr);

        public unsafe static jchar* ToJCharsPtr(string str)
            => (jchar* )Marshal.StringToCoTaskMemUni(str);

        public unsafe static jstring ToJString(string str)
        {
            var jchars = ToJCharsPtr(str);
            var jstr = Run(runtime => runtime.NewString(jchars, str.Length));

            Release(jchars);

            return jstr;
        }

        public unsafe static string ToString(jchar* chars)
            => new string((char*)chars);

        public unsafe static string ToString(jstring jstr)
        {
            return Run(runtime =>
            {
                var jchars = runtime.GetStringChars(jstr, null);
                var str = ToString(jchars);
                runtime.ReleaseStringChars(jstr, jchars);
                return str;
            });
        }
    }
}
