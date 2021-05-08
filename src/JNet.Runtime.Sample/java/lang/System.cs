// Copyright (c) Rodrigo Speller. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.

using java.io;
using JNet.Runtime;
using JNet.Runtime.Sample;

namespace java.lang
{
    public class System
    {
        private static readonly jclass clz_System;
        private static readonly jfieldID fid_out;
        private static readonly jmethodID mid_getProperty;

        static System()
        {   
            var setup = JNetHost.Run(runtime => {
                var clz_System = runtime.FindClass("java/lang/System");
                var fid_out = runtime.GetStaticFieldID(clz_System, "out", "Ljava/io/PrintStream;");
                var mid_getProperty = runtime.GetStaticMethodID(clz_System, "getProperty", "(Ljava/lang/String;)Ljava/lang/String;");

                clz_System = (jclass)runtime.NewGlobalRef(clz_System);

                return (clz_System, fid_out, mid_getProperty);
            });

            clz_System = setup.clz_System;
            fid_out = setup.fid_out;
            mid_getProperty = setup.mid_getProperty;
        }

        public static PrintStream Out
        {
            get => JNetHost.Run(runtime => {
                var jobj = runtime.GetStaticObjectField(clz_System, fid_out);

                if (!jobj.HasValue)
                    return null;

                jobj = runtime.NewGlobalRef(jobj);

                return new PrintStream(jobj);
            });
        }

        public unsafe static string GetProperty(string key)
            => JNetHost.Run(runtime => {
                var jkey = runtime.NewString(key);

                var value = (jstring)runtime.CallStaticObjectMethod(clz_System, mid_getProperty, jkey);

                runtime.ThrowExceptionOccurred();

                if (!value.HasValue)
                    return null;

                return runtime.ToString(value);
            });
    }
}
