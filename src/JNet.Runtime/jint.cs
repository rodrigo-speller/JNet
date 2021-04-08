// Copyright (c) Rodrigo Speller. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.

using System.Runtime.InteropServices;

namespace JNet.Runtime
{
    [StructLayout(LayoutKind.Explicit)]
    public struct jint
    {
        [FieldOffset(0)]
        public int Value;

        public jint(int value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }

        public static implicit operator jint(int value)
        {
            return new jint(value);
        }

        public static implicit operator int(jint value)
        {
            return value.Value;
        }
    }
}
