// Copyright (c) Rodrigo Speller. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.

using System;

using static JNet.Runtime.InteropServices.JNIDelegates;

namespace JNet.Runtime.InteropServices
{
    internal unsafe class JNIRuntimeInterface
    {
        private readonly JNIEnv* env;

        public JNIRuntimeInterface(JNIEnv* env)
        {
            this.env = env;

            var functions = env->functions;

            CreateDelegate<GetVersionDelegate>(functions->GetVersion, x => GetVersion = x);

            CreateDelegate<FindClassDelegate>(functions->FindClass, x => FindClass = x);

            CreateDelegate<GetMethodIDDelegate>(functions->GetMethodID, x => GetMethodID = x);

            CreateDelegate<CallVoidMethodDelegate>(functions->CallVoidMethod, x => CallVoidMethod = x);
            CreateDelegate<CallVoidMethodADelegate>(functions->CallVoidMethodA, x => CallVoidMethodA = x);

            CreateDelegate<GetFieldIDDelegate>(functions->GetFieldID, x => GetFieldID = x);

            CreateDelegate<GetStaticMethodIDDelegate>(functions->GetStaticMethodID, x => GetStaticMethodID = x);

            CreateDelegate<CallStaticObjectMethodDelegate>(functions->CallStaticObjectMethod, x => CallStaticObjectMethod = x);
            CreateDelegate<CallStaticObjectMethodADelegate>(functions->CallStaticObjectMethodA, x => CallStaticObjectMethodA = x);

            CreateDelegate<GetStaticFieldIDDelegate>(functions->GetStaticFieldID, x => GetStaticFieldID = x);
            CreateDelegate<GetStaticObjectFieldDelegate>(functions->GetStaticObjectField, x => GetStaticObjectField = x);

            CreateDelegate<NewStringDelegate>(functions->NewString, x => NewString = x);
            CreateDelegate<GetStringLengthDelegate>(functions->GetStringLength, x => GetStringLength = x);
            CreateDelegate<GetStringCharsDelegate>(functions->GetStringChars, x => GetStringChars = x);
            CreateDelegate<ReleaseStringCharsDelegate>(functions->ReleaseStringChars, x => ReleaseStringChars = x);

            CreateDelegate<NewStringUTFDelegate>(functions->NewStringUTF, x => NewStringUTF = x);
            CreateDelegate<GetStringUTFLengthDelegate>(functions->GetStringUTFLength, x => GetStringUTFLength = x);
            CreateDelegate<GetStringUTFCharsDelegate>(functions->GetStringUTFChars, x => GetStringUTFChars = x);
            CreateDelegate<ReleaseStringUTFCharsDelegate>(functions->ReleaseStringUTFChars, x => ReleaseStringUTFChars = x);
        }

        /* JNI Native Interface */

        public Func<GetVersionDelegate> GetVersion;

        public Func<FindClassDelegate> FindClass;

        public Func<GetMethodIDDelegate> GetMethodID;

        public Func<CallVoidMethodDelegate> CallVoidMethod;
        public Func<CallVoidMethodADelegate> CallVoidMethodA;

        public Func<GetFieldIDDelegate> GetFieldID;

        public Func<GetStaticMethodIDDelegate> GetStaticMethodID;

        public Func<CallStaticObjectMethodDelegate> CallStaticObjectMethod;
        public Func<CallStaticObjectMethodADelegate> CallStaticObjectMethodA;

        public Func<GetStaticFieldIDDelegate> GetStaticFieldID;
        public Func<GetStaticObjectFieldDelegate> GetStaticObjectField;

        public Func<NewStringDelegate> NewString;
        public Func<GetStringLengthDelegate> GetStringLength;
        public Func<GetStringCharsDelegate> GetStringChars;
        public Func<ReleaseStringCharsDelegate> ReleaseStringChars;

        public Func<NewStringUTFDelegate> NewStringUTF;
        public Func<GetStringUTFLengthDelegate> GetStringUTFLength;
        public Func<GetStringUTFCharsDelegate> GetStringUTFChars;
        public Func<ReleaseStringUTFCharsDelegate> ReleaseStringUTFChars;

    }
}
