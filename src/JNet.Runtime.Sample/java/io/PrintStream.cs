// Copyright (c) Rodrigo Speller. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.

using System;
using JNet.Runtime;
using JNet.Runtime.Sample;

namespace java.io
{
    public class PrintStream
    {
        private static readonly JNetRuntime runtime;

        private static readonly jclass clz_PrintStream;
        private static readonly jmethodID mid_println_A;

        private readonly jobject obj;

        static PrintStream()
        {
            runtime = JNetHost.GetRuntime();

            clz_PrintStream = runtime.FindClass("java/io/PrintStream");
            mid_println_A = runtime.GetMethodID(clz_PrintStream, "println", "(Ljava/lang/String;)V");
        }

        public PrintStream(jobject obj)
        {
            if (!obj.HasValue)
                throw new ArgumentException("Empty object reference.", nameof(obj));

            this.obj = obj;
        }

        public void Println(jstring x)
            => runtime.CallVoidMethod(obj, mid_println_A, x);

        public void Println(string x)
        {
            var _x = JNetHost.ToJString(x);
            Println(_x);
        }
    }
}
