// Copyright (c) Rodrigo Speller. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.

using System.Runtime.InteropServices;

namespace JNet.Runtime
{
    [StructLayout(LayoutKind.Explicit)]
    public struct jchar
    {
        [FieldOffset(0)]
        public ushort Value;

        [FieldOffset(0)]
        public char Char;

        public override string ToString()
        {
            return Value.ToString();
        }

        public static implicit operator jchar(ushort value)
        {
            return new jchar() { Value = value };
        }

        public static implicit operator ushort(jchar value)
        {
            return value.Value;
        }
    }
}
