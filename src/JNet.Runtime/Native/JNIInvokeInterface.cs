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

        public delegate* unmanaged<JavaVM*, jint> DestroyJavaVM;
        public delegate* unmanaged<JavaVM*, void**, void*, jint> AttachCurrentThread;
        public delegate* unmanaged<JavaVM*, jint> DetachCurrentThread;
        public delegate* unmanaged<JavaVM*, void**, jint, jint> GetEnv;
        public delegate* unmanaged<JavaVM*, void**, void*, jint> AttachCurrentThreadAsDaemon;
    }
}
