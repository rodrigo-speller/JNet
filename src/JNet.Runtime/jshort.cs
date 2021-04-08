// Copyright (c) Rodrigo Speller. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.

using System.Runtime.InteropServices;

namespace JNet.Runtime
{
    [StructLayout(LayoutKind.Explicit)]
    public struct jshort
    {
        [FieldOffset(0)]
        public short Value;

        public jshort(short value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }

        public static implicit operator jshort(short value)
        {
            return new jshort(value);
        }

        public static implicit operator short(jshort value)
        {
            return value.Value;
        }
    }
}
