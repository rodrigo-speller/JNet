// Copyright (c) Rodrigo Speller. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.

using System;

using static JNet.Runtime.InteropServices.JNIDelegates;

namespace JNet.Runtime.InteropServices
{
    internal unsafe class JNIVirtualMachineInterface
    {
        private readonly JavaVM* vm;

        public JNIVirtualMachineInterface(JavaVM* vm)
        {
            this.vm = vm;

            var functions = vm->functions;

            CreateDelegate<DestroyJavaVMDelegate>(functions->DestroyJavaVM, x => DestroyJavaVM = x);
            CreateDelegate<AttachCurrentThreadDelegate>(functions->AttachCurrentThread, x => AttachCurrentThread = x);
            CreateDelegate<DetachCurrentThreadDelegate>(functions->DetachCurrentThread, x => DetachCurrentThread = x);
            CreateDelegate<GetEnvDelegate>(functions->GetEnv, x => GetEnv = x);
            CreateDelegate<AttachCurrentThreadAsDaemonDelegate>(functions->AttachCurrentThreadAsDaemon, x => AttachCurrentThreadAsDaemon = x);
        }

        public Func<DestroyJavaVMDelegate> DestroyJavaVM;
        public Func<AttachCurrentThreadDelegate> AttachCurrentThread;
        public Func<DetachCurrentThreadDelegate> DetachCurrentThread;
        public Func<GetEnvDelegate> GetEnv;
        public Func<AttachCurrentThreadAsDaemonDelegate> AttachCurrentThreadAsDaemon;

    }
}
