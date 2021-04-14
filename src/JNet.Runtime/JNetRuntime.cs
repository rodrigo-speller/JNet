// Copyright (c) Rodrigo Speller. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.

using JNet.Runtime.InteropServices;

namespace JNet.Runtime
{
    public unsafe class JNetRuntime
    {
        private readonly JNIEnv* env;

        internal JNetRuntime(JNIEnv* env)
        {
            this.env = env;
        }

        public jint GetVersion()
            => env->functions->GetVersion(env);

        public jclass FindClass(string name)
            => env->functions->FindClass(env, name);

        public jmethodID GetMethodID(jclass clazz, string name, string sig)
            => env->functions->GetMethodID(env, clazz, name, sig);

        public void CallVoidMethod(jobject obj, jmethodID methodID)
            => env->functions->CallVoidMethod(env, obj, methodID);
        public void CallVoidMethod(jobject obj, jmethodID methodID, params jvalue[] args)
            => env->functions->CallVoidMethodA(env, obj, methodID, args);

        public jfieldID GetFieldID(jclass clazz, string name, string sig)
            => env->functions->GetFieldID(env, clazz, name, sig);

        public jmethodID GetStaticMethodID(jclass clazz, string name, string sig)
            => env->functions->GetStaticMethodID(env, clazz, name, sig);

        public jobject CallStaticObjectMethod(jclass clazz, jmethodID methodID)
            => env->functions->CallStaticObjectMethod(env, clazz, methodID);
        public jobject CallStaticObjectMethod(jclass clazz, jmethodID methodID, params jvalue[] args)
            => env->functions->CallStaticObjectMethodA(env, clazz, methodID, args);

        public void CallStaticVoidMethod(jclass clazz, jmethodID methodID)
            => env->functions->CallStaticVoidMethod(env, clazz, methodID);
        public void CallStaticVoidMethod(jclass clazz, jmethodID methodID, params jvalue[] args)
            => env->functions->CallStaticVoidMethodA(env, clazz, methodID, args);

        public jfieldID GetStaticFieldID(jclass clazz, string name, string sig)
            => env->functions->GetStaticFieldID(env, clazz, name, sig);
        public jobject GetStaticObjectField(jclass clazz, jfieldID fieldID)
            => env->functions->GetStaticObjectField(env, clazz, fieldID);

        public jstring NewString(jchar* unicode, jsize len)
            => env->functions->NewString(env, unicode, len);
        public jsize GetStringLength(jstring str)
            => env->functions->GetStringLength(env, str);
        public jchar* GetStringChars(jstring str, jboolean* isCopy)
            => env->functions->GetStringChars(env, str, isCopy);
        public void ReleaseStringChars(jstring str, jchar* chars)
            => env->functions->ReleaseStringChars(env, str, chars);

        public jstring NewStringUTF(byte* utf)
            => env->functions->NewStringUTF(env, utf);
        public jsize GetStringUTFLength(jstring str)
            => env->functions->GetStringUTFLength(env, str);
        public byte* GetStringUTFChars(jstring str, jboolean* isCopy)
            => env->functions->GetStringUTFChars(env, str, isCopy);
        public void ReleaseStringUTFChars(jstring str, byte* utf)
            => env->functions->ReleaseStringUTFChars(env, str, utf);

        public jint RegisterNatives(jclass clazz, void* methods, jint nMethods)
            => env->functions->RegisterNatives(env, clazz, methods, nMethods);
        public jint UnregisterNatives(jclass clazz)
            => env->functions->UnregisterNatives(env, clazz);
    }
}
