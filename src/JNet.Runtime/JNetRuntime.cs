// Copyright (c) Rodrigo Speller. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.

using JNet.Runtime.InteropServices;

namespace JNet.Runtime
{
    public unsafe class JNetRuntime
    {
        private readonly JNIEnv* env;
        private readonly JNIRuntimeInterface runtime;

        internal JNetRuntime(JNIEnv* env)
        {
            this.env = env;
            this.runtime = new JNIRuntimeInterface(env);
        }

        public jint GetVersion()
            => runtime.GetVersion()(env);

        public jclass FindClass(string name)
            => runtime.FindClass()(env, name);

        public jmethodID GetMethodID(jclass clazz, string name, string sig)
            => runtime.GetMethodID()(env, clazz, name, sig);

        public void CallVoidMethod(jobject obj, jmethodID methodID)
            => runtime.CallVoidMethod()(env, obj, methodID);
        public void CallVoidMethod(jobject obj, jmethodID methodID, params jvalue[] args)
            => runtime.CallVoidMethodA()(env, obj, methodID, args);

        public jfieldID GetFieldID(jclass clazz, string name, string sig)
            => runtime.GetFieldID()(env, clazz, name, sig);

        public jmethodID GetStaticMethodID(jclass clazz, string name, string sig)
            => runtime.GetStaticMethodID()(env, clazz, name, sig);

        public jobject CallStaticObjectMethod(jclass clazz, jmethodID methodID)
            => runtime.CallStaticObjectMethod()(env, clazz, methodID);
        public jobject CallStaticObjectMethod(jclass clazz, jmethodID methodID, params jvalue[] args)
            => runtime.CallStaticObjectMethodA()(env, clazz, methodID, args);

        public void CallStaticVoidMethod(jclass clazz, jmethodID methodID)
            => runtime.CallStaticVoidMethod()(env, clazz, methodID);
        public void CallStaticVoidMethod(jclass clazz, jmethodID methodID, params jvalue[] args)
            => runtime.CallStaticVoidMethodA()(env, clazz, methodID, args);

        public jfieldID GetStaticFieldID(jclass clazz, string name, string sig)
            => runtime.GetStaticFieldID()(env, clazz, name, sig);
        public jobject GetStaticObjectField(jclass clazz, jfieldID fieldID)
            => runtime.GetStaticObjectField()(env, clazz, fieldID);

        public jstring NewString(jchar* unicode, jsize len)
            => runtime.NewString()(env, unicode, len);
        public jsize GetStringLength(jstring str)
            => runtime.GetStringLength()(env, str);
        public jchar* GetStringChars(jstring str, jboolean* isCopy)
            => runtime.GetStringChars()(env, str, isCopy);
        public void ReleaseStringChars(jstring str, jchar* chars)
            => runtime.ReleaseStringChars()(env, str, chars);

        public jstring NewStringUTF(byte* utf)
            => runtime.NewStringUTF()(env, utf);
        public jsize GetStringUTFLength(jstring str)
            => runtime.GetStringUTFLength()(env, str);
        public byte* GetStringUTFChars(jstring str, jboolean* isCopy)
            => runtime.GetStringUTFChars()(env, str, isCopy);
        public void ReleaseStringUTFChars(jstring str, byte* utf)
            => runtime.ReleaseStringUTFChars()(env, str, utf);
    }
}
