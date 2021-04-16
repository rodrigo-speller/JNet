// Copyright (c) Rodrigo Speller. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.

using System;
using System.Runtime.InteropServices;

namespace JNet.Runtime
{
    [StructLayout(LayoutKind.Explicit)]
    public struct jobject
    {
        [FieldOffset(0)]
        private IntPtr ptr;

        public bool HasValue => ptr != IntPtr.Zero;
    }
}
