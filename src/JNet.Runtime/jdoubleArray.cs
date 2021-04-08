// Copyright (c) Rodrigo Speller. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.

using System.Runtime.InteropServices;

namespace JNet.Runtime
{
    [StructLayout(LayoutKind.Explicit)]
    public struct jdoubleArray
    {
        [FieldOffset(0)]
        private jarray arr;

        [FieldOffset(0)]
        private jobject obj;

        public bool HasValue => arr.HasValue;

        public static implicit operator jarray(jdoubleArray arr)
            => arr.arr;

        public static implicit operator jobject(jdoubleArray arr)
            => arr.obj;

        public static explicit operator jdoubleArray(jarray arr)
            => new jdoubleArray() { arr = arr };

        public static explicit operator jdoubleArray(jobject obj)
            => new jdoubleArray() { obj = obj };
    }
}
