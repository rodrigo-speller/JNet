// Copyright (c) Rodrigo Speller. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.

using System.Runtime.InteropServices;

namespace JNet.Runtime
{
    [StructLayout(LayoutKind.Explicit)]
    public struct jfloatArray
    {
        [FieldOffset(0)]
        private jarray arr;

        [FieldOffset(0)]
        private jobject obj;

        public bool HasValue => arr.HasValue;

        public static implicit operator jarray(jfloatArray arr)
            => arr.arr;

        public static implicit operator jobject(jfloatArray arr)
            => arr.obj;

        public static explicit operator jfloatArray(jarray arr)
            => new jfloatArray() { arr = arr };

        public static explicit operator jfloatArray(jobject obj)
            => new jfloatArray() { obj = obj };
    }
}
