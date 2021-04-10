// Copyright (c) Rodrigo Speller. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.

using System;
using System.Runtime.InteropServices;

namespace JNet.Runtime.Sample
{
    internal class JNetHost
    {
        public static JNetRuntime GetRuntime()
        {
            var vm = JNetVirtualMachine.CurrentInstance
                ?? throw new InvalidOperationException("Virtual Machine is not defined.");

            return vm.AttachCurrentThreadAsDaemon();
        }

        public unsafe static void Release(void* ptr)
            => Marshal.FreeCoTaskMem((IntPtr)ptr);

        public unsafe static jchar* ToJCharsPtr(string str)
            => (jchar* )Marshal.StringToCoTaskMemUni(str);

        public unsafe static jstring ToJString(string str)
        {
            var runtime = GetRuntime();

            var jchars = ToJCharsPtr(str);
            var jstr = runtime.NewString(jchars, str.Length);

            Release(jchars);

            return jstr;
        }

        public unsafe static string ToString(jchar* chars)
            => new string((char*)chars);

        public unsafe static string ToString(jstring jstr)
        {
            var runtime = GetRuntime();

            var jchars = runtime.GetStringChars(jstr, null);
            var str = ToString(jchars);

            runtime.ReleaseStringChars(jstr, jchars);

            return str;
        }
    }
}
