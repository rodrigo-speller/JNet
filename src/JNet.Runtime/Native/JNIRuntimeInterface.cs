// Copyright (c) Rodrigo Speller. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.

using System;
using System.Runtime.InteropServices;

using static JNet.Runtime.InteropServices.JNIRuntimeDelegates;

namespace JNet.Runtime.InteropServices
{
    internal unsafe class JNIRuntimeInterface
    {
        private readonly JavaVM* vm;
        private readonly JNIEnv* env;

        public JNIRuntimeInterface(JavaVM* vm, JNIEnv* env)
        {
            this.vm = vm;
            this.env = env;

            /* JNI Invoke Inteface */

            var vmFunctions = vm->functions;

            CreateDelegate<DestroyJavaVMDelegate>(vmFunctions->DestroyJavaVM, x => DestroyJavaVM = x);
            CreateDelegate<AttachCurrentThreadDelegate>(vmFunctions->AttachCurrentThread, x => AttachCurrentThread = x);
            CreateDelegate<DetachCurrentThreadDelegate>(vmFunctions->DetachCurrentThread, x => DetachCurrentThread = x);
            CreateDelegate<GetEnvDelegate>(vmFunctions->GetEnv, x => GetEnv = x);
            CreateDelegate<AttachCurrentThreadAsDaemonDelegate>(vmFunctions->AttachCurrentThreadAsDaemon, x => AttachCurrentThreadAsDaemon = x);

            /* JNI Native Inteface */

            var envFunctions = env->functions;

            CreateDelegate<GetVersionDelegate>(envFunctions->GetVersion, x => GetVersion = x);

            CreateDelegate<FindClassDelegate>(envFunctions->FindClass, x => FindClass = x);

            CreateDelegate<GetMethodIDDelegate>(envFunctions->GetMethodID, x => GetMethodID = x);

            CreateDelegate<CallVoidMethodDelegate>(envFunctions->CallVoidMethod, x => CallVoidMethod = x);
            CreateDelegate<CallVoidMethodADelegate>(envFunctions->CallVoidMethodA, x => CallVoidMethodA = x);

            CreateDelegate<GetFieldIDDelegate>(envFunctions->GetFieldID, x => GetFieldID = x);

            CreateDelegate<GetStaticMethodIDDelegate>(envFunctions->GetStaticMethodID, x => GetStaticMethodID = x);

            CreateDelegate<CallStaticObjectMethodDelegate>(envFunctions->CallStaticObjectMethod, x => CallStaticObjectMethod = x);
            CreateDelegate<CallStaticObjectMethodADelegate>(envFunctions->CallStaticObjectMethodA, x => CallStaticObjectMethodA = x);

            CreateDelegate<GetStaticFieldIDDelegate>(envFunctions->GetStaticFieldID, x => GetStaticFieldID = x);
            CreateDelegate<GetStaticObjectFieldDelegate>(envFunctions->GetStaticObjectField, x => GetStaticObjectField = x);

            CreateDelegate<NewStringDelegate>(envFunctions->NewString, x => NewString = x);
            CreateDelegate<GetStringLengthDelegate>(envFunctions->GetStringLength, x => GetStringLength = x);
            CreateDelegate<GetStringCharsDelegate>(envFunctions->GetStringChars, x => GetStringChars = x);
            CreateDelegate<ReleaseStringCharsDelegate>(envFunctions->ReleaseStringChars, x => ReleaseStringChars = x);

            CreateDelegate<NewStringUTFDelegate>(envFunctions->NewStringUTF, x => NewStringUTF = x);
            CreateDelegate<GetStringUTFLengthDelegate>(envFunctions->GetStringUTFLength, x => GetStringUTFLength = x);
            CreateDelegate<GetStringUTFCharsDelegate>(envFunctions->GetStringUTFChars, x => GetStringUTFChars = x);
            CreateDelegate<ReleaseStringUTFCharsDelegate>(envFunctions->ReleaseStringUTFChars, x => ReleaseStringUTFChars = x);
        }

        /* JNI Invoke Inteface */

        public Func<DestroyJavaVMDelegate> DestroyJavaVM;
        public Func<AttachCurrentThreadDelegate> AttachCurrentThread;
        public Func<DetachCurrentThreadDelegate> DetachCurrentThread;
        public Func<GetEnvDelegate> GetEnv;
        public Func<AttachCurrentThreadAsDaemonDelegate> AttachCurrentThreadAsDaemon;

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

        private static void CreateDelegate<TDelegate>(IntPtr ptr, Action<Func<TDelegate>> setter)
            where TDelegate : Delegate
        {
            setter(() => {
                var _delegate = Marshal.GetDelegateForFunctionPointer<TDelegate>(ptr);

                setter(() => _delegate);

                return _delegate;
            });
        }
    }
}
