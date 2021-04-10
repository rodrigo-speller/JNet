// Copyright (c) Rodrigo Speller. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using JNet.Runtime.InteropServices;

namespace JNet.Runtime
{
    public unsafe class JNetVirtualMachine
    {
        private static readonly object instanceSync = new object();

        private readonly JavaVM* vm;
        private readonly JNIVirtualMachineInterface runtime;

        private JNetVirtualMachine(JavaVM* vm)
        {
            this.vm = vm;
            this.runtime = new JNIVirtualMachineInterface(vm);
        }

        public static JNetVirtualMachine Initialize(IEnumerable<string> optionStrings)
        {
            lock (instanceSync)
            {
                if (optionStrings is null)
                    optionStrings = Array.Empty<string>();

                var options = optionStrings.Select(opt => new JavaVMOption(opt));

                JavaVMInitArgs vm_args = new JavaVMInitArgs();
                vm_args.version = (int)JNIVersion.Version10;
                vm_args.SetOptions(options.ToArray());
                vm_args.ignoreUnrecognized = true; // invalid options make the JVM init fail

                var p_vmArgs = Marshal.AllocCoTaskMem(Marshal.SizeOf<JavaVMInitArgs>());
                Marshal.StructureToPtr(vm_args, p_vmArgs, false);

                JavaVM* vm;
                JNIEnv* env;

                var ret = JVMLib.JNI_CreateJavaVM(&vm, (void**)&env, (void*)p_vmArgs);

                vm_args.ReleaseOptions();
                Marshal.FreeCoTaskMem(p_vmArgs);

                JNIResultException.Check(ret);

                var instance = new JNetVirtualMachine(vm);

                return instance;
            }
        }

        public JNetRuntime AttachCurrentThread()
        {
            JNIEnv* env;

            var ret = runtime.AttachCurrentThread()(vm, (void**)&env, null);
            JNIResultException.Check(ret);

            return new JNetRuntime(env);
        }

        public JNetRuntime AttachCurrentThreadAsDaemon()
        {
            JNIEnv* env;

            var ret = runtime.AttachCurrentThreadAsDaemon()(vm, (void**)&env, null);
            JNIResultException.Check(ret);

            return new JNetRuntime(env);
        }

        public void DetachCurrentThread()
        {
            var ret = runtime.DetachCurrentThread()(vm);
            JNIResultException.Check(ret);
        }

        public void Destroy()
        {
            lock (instanceSync)
            {
                var ret = runtime.DestroyJavaVM()(vm);
                JNIResultException.Check(ret);
            }
        }
    }
}
