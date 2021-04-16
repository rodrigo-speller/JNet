// Copyright (c) Rodrigo Speller. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.

using System.Runtime.InteropServices;

namespace JNet.Runtime
{
    [StructLayout(LayoutKind.Explicit)]
    public struct jarray
    {
        [FieldOffset(0)]
        private jobject obj;

        public bool HasValue => obj.HasValue;

        public static implicit operator jobject(jarray array)
            => array.obj;

        public static explicit operator jarray(jobject obj)
            => new jarray() { obj = obj };
    }
}
