// Copyright (c) Rodrigo Speller. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.

using System.Runtime.InteropServices;

namespace JNet.Runtime
{
    /// <summary>
    /// The <see cref="jvalue" /> is a union structure type that is used as the element type in function argument
    /// arrays.
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct jvalue
    {
        [FieldOffset(0)]
        public jboolean z;

        [FieldOffset(0)]
        public jbyte b;

        [FieldOffset(0)]
        public jchar c;

        [FieldOffset(0)]
        public jshort s;

        [FieldOffset(0)]
        public jint i;

        [FieldOffset(0)]
        public jlong j;

        [FieldOffset(0)]
        public jfloat f;

        [FieldOffset(0)]
        public jdouble d;

        [FieldOffset(0)]
        public jobject l;

        public static implicit operator jvalue(jboolean z)
            => new jvalue() { z = z };

        public static implicit operator jvalue(jbyte b)
            => new jvalue() { b = b };

        public static implicit operator jvalue(jchar c)
            => new jvalue() { c = c };

        public static implicit operator jvalue(jshort s)
            => new jvalue() { s = s };

        public static implicit operator jvalue(jint i)
            => new jvalue() { i = i };

        public static implicit operator jvalue(jlong j)
            => new jvalue() { j = j };

        public static implicit operator jvalue(jfloat f)
            => new jvalue() { f = f };

        public static implicit operator jvalue(jdouble d)
            => new jvalue() { d = d };

        public static implicit operator jvalue(jobject l)
            => new jvalue() { l = l };

        public static implicit operator jvalue(jclass l)
            => (jobject)l;

        public static implicit operator jvalue(jstring l)
            => (jobject)l;

        public static implicit operator jvalue(jarray l)
            => (jobject)l;

        public static implicit operator jvalue(jobjectArray l)
            => (jobject)l;

        public static implicit operator jvalue(jbooleanArray l)
            => (jobject)l;

        public static implicit operator jvalue(jbyteArray l)
            => (jobject)l;

        public static implicit operator jvalue(jcharArray l)
            => (jobject)l;

        public static implicit operator jvalue(jshortArray l)
            => (jobject)l;

        public static implicit operator jvalue(jintArray l)
            => (jobject)l;

        public static implicit operator jvalue(jlongArray l)
            => (jobject)l;

        public static implicit operator jvalue(jfloatArray l)
            => (jobject)l;

        public static implicit operator jvalue(jdoubleArray l)
            => (jobject)l;

        public static implicit operator jvalue(jthrowable l)
            => (jobject)l;
    }
}
