// Copyright (c) Rodrigo Speller. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.

using System.Runtime.InteropServices;

namespace JNet.Runtime
{
    [StructLayout(LayoutKind.Explicit)]
    public struct jstring
    {
        [FieldOffset(0)]
        private jobject obj;

        public bool HasValue => obj.HasValue;

        public static implicit operator jobject(jstring str)
            => str.obj;

        public static explicit operator jstring(jobject obj)
            => new jstring() { obj = obj };
    }
}
