// Copyright (c) Rodrigo Speller. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.

using System.Runtime.InteropServices;

namespace JNet.Runtime
{
    [StructLayout(LayoutKind.Explicit)]
    public struct jdouble
    {
        [FieldOffset(0)]
        public double Value;

        public jdouble(double value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }

        public static implicit operator jdouble(double value)
        {
            return new jdouble(value);
        }

        public static implicit operator double(jdouble value)
        {
            return value.Value;
        }
    }
}
