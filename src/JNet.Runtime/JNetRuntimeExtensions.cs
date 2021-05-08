// Copyright (c) Rodrigo Speller. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace JNet.Runtime
{
    public static class JNetRuntimeExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowExceptionOccurred(this JNetRuntime runtime)
        {
            if (runtime.ExceptionCheck())
            {
                var ex = runtime.ExceptionOccurred();
                if (ex.HasValue)
                {
                    runtime.ExceptionClear();
                    throw new JNetThrowableException(runtime, ex);
                }

                throw new InvalidOperationException();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static jstring NewString(this JNetRuntime runtime, string str)
        {
            var jchars = AllocJChars(str);
            var result = runtime.NewString(jchars, str.Length);

            Release(jchars);

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static string ToString(this JNetRuntime runtime, jstring jstr)
        {
            var jchars = runtime.GetStringChars(jstr, null);
            var str = ToString(jchars);
            runtime.ReleaseStringChars(jstr, jchars);
            return str;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private unsafe static jchar* AllocJChars(string str)
            => (jchar*)Marshal.StringToCoTaskMemUni(str);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private unsafe static void Release(void* ptr)
            => Marshal.FreeCoTaskMem((IntPtr)ptr);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private unsafe static string ToString(jchar* chars)
            => new string((char*)chars);
    }
}
