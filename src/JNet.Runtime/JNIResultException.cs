// Copyright (c) Rodrigo Speller. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.

using System;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace JNet.Runtime
{
    [Serializable]
    public class JNIResultException : Exception
    {
        public JNIReturnCode ResultValue { get; }

        private JNIResultException(JNIReturnCode resultValue)
            : base($"JNI API returns an error result ({resultValue}).")
        {
            ResultValue = resultValue;
        }

        protected JNIResultException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            ResultValue = info.GetValue(nameof(ResultValue), typeof(JNIReturnCode)) as JNIReturnCode?
                ?? JNIReturnCode.Err;
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);

            info.AddValue(nameof(ResultValue), ResultValue);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Check(JNIReturnCode resultValue)
        {
            if (resultValue == JNIReturnCode.OK)
                return;
            
            throw new JNIResultException(resultValue);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Check(jint resultValue)
            => Check((JNIReturnCode)(int)resultValue);
    }
}
