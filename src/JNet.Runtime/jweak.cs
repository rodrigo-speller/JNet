// Copyright (c) Rodrigo Speller. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.

using System.Runtime.InteropServices;

namespace JNet.Runtime
{
    [StructLayout(LayoutKind.Explicit)]
    public struct jweak
    {
        [FieldOffset(0)]
        private jobject obj;

        public bool HasValue => obj.HasValue;

        public static implicit operator jobject(jweak weak)
            => weak.obj;

        public static explicit operator jweak(jobject obj)
            => new jweak() { obj = obj };
    }
}
