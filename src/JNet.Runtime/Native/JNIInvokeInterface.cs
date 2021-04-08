// Copyright (c) Rodrigo Speller. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.

using System;
using System.Runtime.InteropServices;

namespace JNet.Runtime.InteropServices
{
    [StructLayout(LayoutKind.Sequential)]
    internal unsafe struct JNIInvokeInterface
    {
        private IntPtr reserved0;
        private IntPtr reserved1;
        private IntPtr reserved2;

        public IntPtr DestroyJavaVM;
        public IntPtr AttachCurrentThread;
        public IntPtr DetachCurrentThread;
        public IntPtr GetEnv;
        public IntPtr AttachCurrentThreadAsDaemon;
    }
}
