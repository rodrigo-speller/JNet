// Copyright (c) Rodrigo Speller. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.

using System.Runtime.InteropServices;

namespace JNet.Runtime
{
    [StructLayout(LayoutKind.Explicit)]
    public struct jboolean
    {
        [FieldOffset(0)]
        public bool Value;

        public jboolean(bool value)
        {
            Value = value;
        }

        public static jboolean True => true;
        public static jboolean False => false;

        public override string ToString()
        {
            return Value.ToString();
        }

        public static implicit operator jboolean(bool value)
        {
            return new jboolean(value);
        }

        public static implicit operator bool(jboolean value)
        {
            return value.Value;
        }
    }
}
