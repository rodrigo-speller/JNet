// Copyright (c) Rodrigo Speller. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.

using System;
using System.Runtime.InteropServices;

namespace JNet.Runtime.InteropServices
{
    [StructLayout(LayoutKind.Sequential)]
    internal unsafe struct JavaVMInitArgs
    {
        public jint version;
        public jint nOptions;
        public IntPtr options;
        public jboolean ignoreUnrecognized;

        public void SetOptions(JavaVMOption[] options)
        {
            var sz = Marshal.SizeOf<JavaVMOption>();
            var len = options.Length;
            var ptr = Marshal.AllocCoTaskMem(len * sz);

            var current = ptr;
            foreach (var option in options)
            {
                Marshal.StructureToPtr(option, current, false);
                current += sz;
            }

            this.options = ptr;
            this.nOptions = len;
        }

        public void ReleaseOptions()
        {
            var ptr = options;
            if (ptr == IntPtr.Zero)
                return;

            options = IntPtr.Zero;
            nOptions = 0;

            Marshal.FreeCoTaskMem(ptr);
        }
    }
}
