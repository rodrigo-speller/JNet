// Copyright (c) Rodrigo Speller. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.

using JNet.Runtime.InteropServices;

namespace JNet.Runtime
{
    public unsafe class JNetRuntime
    {
        private readonly JNIEnv* env;
        private readonly JNINativeInterface* functions;

        internal JNetRuntime(JNIEnv* env)
        {
            this.env = env;
            this.functions = env->functions;
        }

        public jint GetVersion()
            => functions->GetVersion(env);

        public jclass FindClass(string name)
            => functions->FindClass(env, name);

        public jmethodID GetMethodID(jclass clazz, string name, string sig)
            => functions->GetMethodID(env, clazz, name, sig);

        public void CallVoidMethod(jobject obj, jmethodID methodID)
            => functions->CallVoidMethod(env, obj, methodID);
        public void CallVoidMethod(jobject obj, jmethodID methodID, params jvalue[] args)
            => functions->CallVoidMethodA(env, obj, methodID, args);

        public jfieldID GetFieldID(jclass clazz, string name, string sig)
            => functions->GetFieldID(env, clazz, name, sig);

        public jmethodID GetStaticMethodID(jclass clazz, string name, string sig)
            => functions->GetStaticMethodID(env, clazz, name, sig);

        public jobject CallStaticObjectMethod(jclass clazz, jmethodID methodID)
            => functions->CallStaticObjectMethod(env, clazz, methodID);
        public jobject CallStaticObjectMethod(jclass clazz, jmethodID methodID, params jvalue[] args)
            => functions->CallStaticObjectMethodA(env, clazz, methodID, args);

        public void CallStaticVoidMethod(jclass clazz, jmethodID methodID)
            => functions->CallStaticVoidMethod(env, clazz, methodID);
        public void CallStaticVoidMethod(jclass clazz, jmethodID methodID, params jvalue[] args)
            => functions->CallStaticVoidMethodA(env, clazz, methodID, args);

        public jfieldID GetStaticFieldID(jclass clazz, string name, string sig)
            => functions->GetStaticFieldID(env, clazz, name, sig);
        public jobject GetStaticObjectField(jclass clazz, jfieldID fieldID)
            => functions->GetStaticObjectField(env, clazz, fieldID);

        public jstring NewString(jchar* unicode, jsize len)
            => functions->NewString(env, unicode, len);
        public jsize GetStringLength(jstring str)
            => functions->GetStringLength(env, str);
        public jchar* GetStringChars(jstring str, jboolean* isCopy)
            => functions->GetStringChars(env, str, isCopy);
        public void ReleaseStringChars(jstring str, jchar* chars)
            => functions->ReleaseStringChars(env, str, chars);

        public jstring NewStringUTF(byte* utf)
            => functions->NewStringUTF(env, utf);
        public jsize GetStringUTFLength(jstring str)
            => functions->GetStringUTFLength(env, str);
        public byte* GetStringUTFChars(jstring str, jboolean* isCopy)
            => functions->GetStringUTFChars(env, str, isCopy);
        public void ReleaseStringUTFChars(jstring str, byte* utf)
            => functions->ReleaseStringUTFChars(env, str, utf);

        public jint RegisterNatives(jclass clazz, void* methods, jint nMethods)
            => functions->RegisterNatives(env, clazz, methods, nMethods);
        public jint UnregisterNatives(jclass clazz)
            => functions->UnregisterNatives(env, clazz);
    }
}
