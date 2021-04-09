// Copyright (c) Rodrigo Speller. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.

using JNet.Runtime;
using JNet.Runtime.Sample;

namespace java.lang
{
    public class System
    {
        private static readonly JNetRuntime runtime;

        private static readonly jclass clz_System;
        private static readonly jmethodID mid_getProperty;

        static System()
        {
            runtime = JNetHost.GetRuntime();

            clz_System = runtime.FindClass("java/lang/System");
            mid_getProperty = runtime.GetStaticMethodID(clz_System, "getProperty", "(Ljava/lang/String;)Ljava/lang/String;");
        }

        public static jstring GetProperty(jstring key)
            => (jstring)runtime.CallStaticObjectMethod(clz_System, mid_getProperty, key);

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
