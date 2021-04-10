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

                return (clz_System, fid_out, mid_getProperty);
            });

            clz_System = setup.clz_System;
            fid_out = setup.fid_out;
            mid_getProperty = setup.mid_getProperty;
        }

        public static PrintStream Out
        {
            get
            {
                var obj = JNetHost.Run(runtime => runtime.GetStaticObjectField(clz_System, fid_out));

                if (obj.HasValue)
                    return new PrintStream(obj);

                return null;
            }
        }

        public static jstring GetProperty(jstring key)
            => JNetHost.Run(runtime => (jstring)runtime.CallStaticObjectMethod(clz_System, mid_getProperty, key));

        public unsafe static string GetProperty(string key)
        {
            var _key = JNetHost.ToJString(key);

            var _value = GetProperty(_key);

            if (!_value.HasValue)
                return null;

            return JNetHost.ToString(_value);
        }
    }
}
