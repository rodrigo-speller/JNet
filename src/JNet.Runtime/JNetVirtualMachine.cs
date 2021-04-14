// Copyright (c) Rodrigo Speller. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.

using System.Linq;
using System.Runtime.InteropServices;
using JNet.Runtime.InteropServices;

namespace JNet.Runtime
{
    public unsafe class JNetVirtualMachine
    {
        private static readonly object instanceSync = new object();

        private readonly JavaVM* vm;

        private JNetVirtualMachine(JavaVM* vm)
        {
            this.vm = vm;
        }

        public static JNetVirtualMachine Initialize(JNetConfiguration configuration)
        {
            configuration = configuration ?? new JNetConfiguration();

            lock (instanceSync)
            {
                var options = configuration.BuildOptions();

                JVMLib.Load(configuration);

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
                var runtime = new JNetRuntime(env);

                var bootstrap = configuration.Bootstrap
                    ?? DefaultBootstrap.GetBootstrap(runtime)
                    ?? new NopBootstrap();

                bootstrap.Startup(runtime);

                return instance;
            }
        }

        public JNetRuntime AttachCurrentThread()
        {
            JNIEnv* env;

            var ret = vm->functions->AttachCurrentThread(vm, (void**)&env, null);
            JNIResultException.Check(ret);

            return new JNetRuntime(env);
        }

        public JNetRuntime AttachCurrentThreadAsDaemon()
        {
            JNIEnv* env;

            var ret = vm->functions->AttachCurrentThreadAsDaemon(vm, (void**)&env, null);
            JNIResultException.Check(ret);

            return new JNetRuntime(env);
        }

        public void DetachCurrentThread()
        {
            var ret = vm->functions->DetachCurrentThread(vm);
            JNIResultException.Check(ret);
        }

        public void Destroy()
        {
            lock (instanceSync)
            {
                var ret = vm->functions->DestroyJavaVM(vm);
                JNIResultException.Check(ret);
            }
        }
    }
}
