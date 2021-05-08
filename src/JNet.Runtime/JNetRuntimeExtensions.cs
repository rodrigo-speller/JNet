// Copyright (c) Rodrigo Speller. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.

using System.Runtime.CompilerServices;

namespace JNet.Runtime
{
    internal static class JNetRuntimeExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CheckException(this JNetRuntime runtime)
        {
            var ex = runtime.ExceptionOccurred();
            if (ex.HasValue)
            {
                runtime.ExceptionClear();
                throw new JNetThrowableException(runtime, ex);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private unsafe static string ToString(jchar* chars)
            => new string((char*)chars);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static string ToString(this JNetRuntime runtime, jstring jstr)
        {
            var jchars = runtime.GetStringChars(jstr, null);
            var str = ToString(jchars);
            runtime.ReleaseStringChars(jstr, jchars);
            return str;
        }
    }
}