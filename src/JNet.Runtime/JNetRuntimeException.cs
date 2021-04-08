// Copyright (c) Rodrigo Speller. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.

using System;
using System.Runtime.Serialization;

namespace JNet.Runtime
{
    [Serializable]
    public class JNetRuntimeException : Exception
    {
        public JNetRuntimeException() { }
        public JNetRuntimeException(string message)
            : base(message) { }
        public JNetRuntimeException(string message, Exception inner)
            : base(message, inner) { }
        protected JNetRuntimeException(SerializationInfo info, StreamingContext context)
            : base(info, context) { }
    }
}
