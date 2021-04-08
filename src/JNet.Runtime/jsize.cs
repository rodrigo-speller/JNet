// Copyright (c) Rodrigo Speller. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.

using System.Runtime.InteropServices;

namespace JNet.Runtime
{
    [StructLayout(LayoutKind.Explicit)]
    public struct jsize
    {
        [FieldOffset(0)]
        public int Value;

        public jsize(int value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }

        public static implicit operator jsize(int value)
        {
            return new jsize(value);
        }

        public static implicit operator jsize(jint value)
        {
            return (int)value;
        }

        public static implicit operator int(jsize value)
        {
            return value.Value;
        }

        public static implicit operator jint(jsize value)
        {
            return value.Value;
        }
    }
}
