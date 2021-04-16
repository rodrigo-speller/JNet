// Copyright (c) Rodrigo Speller. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.

using System.Runtime.InteropServices;

namespace JNet.Runtime
{
    [StructLayout(LayoutKind.Explicit)]
    public struct jbyteArray
    {
        [FieldOffset(0)]
        private jarray arr;

        [FieldOffset(0)]
        private jobject obj;

        public bool HasValue => arr.HasValue;

        public static implicit operator jarray(jbyteArray arr)
            => arr.arr;

        public static implicit operator jobject(jbyteArray arr)
            => arr.obj;

        public static explicit operator jbyteArray(jarray arr)
            => new jbyteArray() { arr = arr };

        public static explicit operator jbyteArray(jobject obj)
            => new jbyteArray() { obj = obj };
    }
}
