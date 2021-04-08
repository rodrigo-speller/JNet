// Copyright (c) Rodrigo Speller. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.

using System.Runtime.InteropServices;

namespace JNet.Runtime.InteropServices
{
    [StructLayout(LayoutKind.Sequential)]
    internal unsafe struct JavaVMOption
    {
        public JavaVMOption(string option)
        {
            optionString = option;
            extraInfo = null;
        }

        public string optionString;
        public void *extraInfo;
    }
}
