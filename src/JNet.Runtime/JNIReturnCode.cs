// Copyright (c) Rodrigo Speller. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.

namespace JNet.Runtime
{
    public enum JNIReturnCode : int
    {
        /// <summary>Success</summary>
        OK = 0,

        /// <summary>Unknown error</summary>
        Err = -1,

        /// <summary>Thread detached from the VM</summary>
        EDetached = -2,

        /// <summary>JNI version error</summary>
        EVersion = -3,

        /// <summary>Not enough memory</summary>
        ENoMem = -4,

        /// <summary>VM already created</summary>
        EExist = -5,

        /// <summary>Invalid arguments</summary>
        EInVal = -6,
    }
}
