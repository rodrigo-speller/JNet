// Copyright (c) Rodrigo Speller. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.

using System.Runtime.InteropServices;

namespace JNet.Runtime
{
    [StructLayout(LayoutKind.Explicit)]
    public struct jlong
    {
        [FieldOffset(0)]
        public long Value;

        public jlong(long value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }

        public static implicit operator jlong(long value)
        {
            return new jlong(value);
        }

        public static implicit operator long(jlong value)
        {
            return value.Value;
        }
    }
}
