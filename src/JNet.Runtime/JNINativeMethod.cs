// Copyright (c) Rodrigo Speller. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.

using System;
using System.Runtime.InteropServices;

namespace JNet.Runtime
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct JNINativeMethod
    {
        public string name;
        public string signature;
        public IntPtr fnPtr;

        public static IntPtr MethodsToPtr(params JNINativeMethod[] methods)
        {
            var sz = Marshal.SizeOf<JNINativeMethod>();
            var len = methods.Length;
            var ptr = Marshal.AllocCoTaskMem(len * sz);

            var current = ptr;
            foreach (var method in methods)
            {
                Marshal.StructureToPtr(method, current, false);
                current += sz;
            }

            return ptr;
        }

        public static void DestroyMethods(IntPtr methods, int nMethods)
        {
            var sz = Marshal.SizeOf<JNINativeMethod>();

            var current = methods;
            while (nMethods-- > 0)
            {
                Marshal.DestroyStructure<JNINativeMethod>(current);
                current += sz;
            }

            Marshal.FreeCoTaskMem(methods);
        }
    }
}
