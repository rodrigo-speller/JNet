// Copyright (c) Rodrigo Speller. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.

using System;
using System.Runtime.InteropServices;

namespace JNet.Runtime.InteropServices
{
    internal unsafe static class JNIDelegates
    {
        /* JNI Invoke Interface */

        public delegate jint DestroyJavaVMDelegate(JavaVM* vm);
        public delegate jint AttachCurrentThreadDelegate(JavaVM* vm, void** penv, void* args);
        public delegate jint DetachCurrentThreadDelegate(JavaVM* vm);
        public delegate jint GetEnvDelegate(JavaVM* vm, void** penv, jint version);
        public delegate jint AttachCurrentThreadAsDaemonDelegate(JavaVM* vm, void** penv, void* args);

        /* JNI Native Interface */

        public delegate jint GetVersionDelegate(JNIEnv* env);
        
        public delegate jclass FindClassDelegate(JNIEnv* env, string name);

        public delegate jmethodID GetMethodIDDelegate(JNIEnv* env, jclass clazz, string name, string sig);

        public delegate void CallVoidMethodDelegate(JNIEnv* env, jobject obj, jmethodID methodID);
        public delegate void CallVoidMethodADelegate(JNIEnv* env, jobject obj, jmethodID methodID, jvalue[] args);

        public delegate jfieldID GetFieldIDDelegate(JNIEnv* env, jclass clazz, string name, string sig);

        public delegate jmethodID GetStaticMethodIDDelegate(JNIEnv* env, jclass clazz, string name, string sig);

        public delegate jobject CallStaticObjectMethodDelegate(JNIEnv* env, jclass clazz, jmethodID methodID);
        public delegate jobject CallStaticObjectMethodADelegate(JNIEnv* env, jclass clazz, jmethodID methodID, jvalue[] args);

        public delegate void CallStaticVoidMethodDelegate(JNIEnv* env, jclass clazz, jmethodID methodID);
        public delegate void CallStaticVoidMethodADelegate(JNIEnv* env, jclass clazz, jmethodID methodID, jvalue[] args);

        public delegate jfieldID GetStaticFieldIDDelegate(JNIEnv* env, jclass clazz, string name, string sig);
        public delegate jobject GetStaticObjectFieldDelegate(JNIEnv* env, jclass clazz, jfieldID fieldID);

        public delegate jstring NewStringDelegate(JNIEnv* env, jchar* unicode, jsize len);
        public delegate jsize GetStringLengthDelegate(JNIEnv* env, jstring str);
        public delegate jchar* GetStringCharsDelegate(JNIEnv* env, jstring str, jboolean* isCopy);
        public delegate void ReleaseStringCharsDelegate(JNIEnv* env, jstring str, jchar* chars);

        public delegate jstring NewStringUTFDelegate(JNIEnv* env, byte* utf);
        public delegate jsize GetStringUTFLengthDelegate(JNIEnv* env, jstring str);
        public delegate byte* GetStringUTFCharsDelegate(JNIEnv* env, jstring str, jboolean* isCopy);
        public delegate void ReleaseStringUTFCharsDelegate(JNIEnv* env, jstring str, byte* utf);

        internal static void CreateDelegate<TDelegate>(IntPtr ptr, Action<Func<TDelegate>> setter)
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
