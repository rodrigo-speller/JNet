// Copyright (c) Rodrigo Speller. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.

using System.Runtime.InteropServices;

namespace JNet.Runtime
{
    [StructLayout(LayoutKind.Explicit)]
    public struct jfloat
    {
        [FieldOffset(0)]
        public float Value;

        public jfloat(float value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }

        public static implicit operator jfloat(float value)
        {
            return new jfloat(value);
        }

        public static implicit operator float(jfloat value)
        {
            return value.Value;
        }
    }
}
