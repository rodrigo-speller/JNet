// Copyright (c) Rodrigo Speller. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.

using System;
using System.IO;
using System.Runtime.InteropServices;

namespace JNet.Runtime.InteropServices
{
    partial class JVMLib
    {
        private unsafe class OSX : IJVMLib
        {
            public const string JVMLibName = "libjvm.dylib";

            [DllImport(JVMLibName, CallingConvention = CallingConvention.Cdecl)]
            public static extern jint JNI_GetDefaultJavaVMInitArgs(void* vm_args);

            [DllImport(JVMLibName, CallingConvention = CallingConvention.Cdecl)]
            public static extern jint JNI_CreateJavaVM(JavaVM** p_vm, void** p_env, void* vm_args);

            [DllImport(JVMLibName, CallingConvention = CallingConvention.Cdecl)]
            public static extern jint JNI_GetCreatedJavaVMs(JavaVM** vmBuf, jsize bufLen, jsize* nVMs);

            public static IJVMLib Load(string path)
            {
                path = Path.Combine(path, "jre", "lib", "server", JVMLibName);

                NativeLibrary.Load(path);

                return new Linux();
            }

            public jint GetDefaultJavaVMInitArgs(void* vm_args)
                => JNI_GetDefaultJavaVMInitArgs(vm_args);

            public jint CreateJavaVM(JavaVM** p_vm, void** p_env, void* vm_args)
                => JNI_CreateJavaVM(p_vm, p_env, vm_args);

            public jint GetCreatedJavaVMs(JavaVM** vmBuf, jsize bufLen, jsize* nVMs)
                => JNI_GetCreatedJavaVMs(vmBuf, bufLen, nVMs);
        }
    }
}
