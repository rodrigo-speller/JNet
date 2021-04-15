// Copyright (c) Rodrigo Speller. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.

using System;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace JNet.Runtime
{
    [Serializable]
    public class JNetThrowableException : JNetRuntimeException
    {
        public jthrowable Throwable { get; }

        internal JNetThrowableException(JNetRuntime runtime, jthrowable throwable)
            : base(GetMessage(runtime, throwable))
        {
            // TODO: enrich exception information (asynchronously)

            Throwable = throwable;
        }

        protected JNetThrowableException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }

        private static string GetMessage(JNetRuntime runtime, jthrowable throwable)
        {
            // TODO: Can we get 'throwable' message asynchronously (using another runtime instance)?
            
            var clz_Throwable = runtime.GetObjectClass(throwable);

            var mid_GetMessage = runtime.GetMethodID(clz_Throwable, "getMessage", "()Ljava/lang/String;");
            var jmessage = (jstring)runtime.CallObjectMethod(throwable, mid_GetMessage);

            return runtime.ToString(jmessage);
        }
    }
}
