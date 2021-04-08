// Copyright (c) Rodrigo Speller. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.

using System.Runtime.InteropServices;

namespace JNet.Runtime
{
    [StructLayout(LayoutKind.Explicit)]
    public struct jbyte
    {
        [FieldOffset(0)]
        public byte Value;

        public jbyte(byte value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }

        public static implicit operator jbyte(byte value)
        {
            return new jbyte(value);
        }

        public static implicit operator byte(jbyte value)
        {
            return value.Value;
        }
    }
}
