// Copyright (c) Rodrigo Speller. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.

using System;
using JNet.Runtime;
using JNet.Runtime.Sample;

namespace java.io
{
    public class PrintStream
    {
        private static readonly jclass clz_PrintStream;
        private static readonly jmethodID mid_println_A;

        private readonly jobject obj;

        static PrintStream()
        {
            var setup = JNetHost.Run(runtime =>
            {
                var clz_PrintStream = runtime.FindClass("java/io/PrintStream");
                var mid_println_A = runtime.GetMethodID(clz_PrintStream, "println", "(Ljava/lang/String;)V");

                clz_PrintStream = (jclass)runtime.NewGlobalRef(clz_PrintStream);

                return (clz_PrintStream, mid_println_A);
            });

            clz_PrintStream = setup.clz_PrintStream;
            mid_println_A = setup.mid_println_A;
        }

        public PrintStream(jobject obj)
        {
            if (!obj.HasValue)
                throw new ArgumentException("Empty object reference.", nameof(obj));

            this.obj = obj;
        }

        public void Println(jstring x)
            => JNetHost.Run(runtime => runtime.CallVoidMethod(obj, mid_println_A, x));

        public void Println(string x)
        {
            var _x = JNetHost.ToJString(x);
            Println(_x);
        }
    }
}
