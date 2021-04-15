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

        // GetVersion
        public jint GetVersion()
            => functions->GetVersion(env);

        // FindClass
        public jclass FindClass(string name)
            => functions->FindClass(env, name);

        // GetMethodID
        public jmethodID GetMethodID(jclass clazz, string name, string sig)
            => functions->GetMethodID(env, clazz, name, sig);

        // CallVoidMethod
        public void CallVoidMethod(jobject obj, jmethodID methodID)
            => functions->CallVoidMethod(env, obj, methodID);
        public void CallVoidMethod(jobject obj, jmethodID methodID, params jvalue[] args)
            => functions->CallVoidMethodA(env, obj, methodID, args);

        // GetFieldID
        public jfieldID GetFieldID(jclass clazz, string name, string sig)
            => functions->GetFieldID(env, clazz, name, sig);

        // GetStaticMethodID
        public jmethodID GetStaticMethodID(jclass clazz, string name, string sig)
            => functions->GetStaticMethodID(env, clazz, name, sig);

        // CallStaticObjectMethod
        public jobject CallStaticObjectMethod(jclass clazz, jmethodID methodID)
            => functions->CallStaticObjectMethod(env, clazz, methodID);
        public jobject CallStaticObjectMethod(jclass clazz, jmethodID methodID, params jvalue[] args)
            => functions->CallStaticObjectMethodA(env, clazz, methodID, args);

        // CallStaticVoidMethod
        public void CallStaticVoidMethod(jclass clazz, jmethodID methodID)
            => functions->CallStaticVoidMethod(env, clazz, methodID);
        public void CallStaticVoidMethod(jclass clazz, jmethodID methodID, params jvalue[] args)
            => functions->CallStaticVoidMethodA(env, clazz, methodID, args);

        // GetStaticFieldID
        public jfieldID GetStaticFieldID(jclass clazz, string name, string sig)
            => functions->GetStaticFieldID(env, clazz, name, sig);
        // GetStaticObjectField
        public jobject GetStaticObjectField(jclass clazz, jfieldID fieldID)
            => functions->GetStaticObjectField(env, clazz, fieldID);

        // NewString
        public jstring NewString(jchar* unicode, jsize len)
            => functions->NewString(env, unicode, len);
        // GetStringLength
        public jsize GetStringLength(jstring str)
            => functions->GetStringLength(env, str);
        // GetStringChars
        public jchar* GetStringChars(jstring str, jboolean* isCopy)
            => functions->GetStringChars(env, str, isCopy);
        // ReleaseStringChars
        public void ReleaseStringChars(jstring str, jchar* chars)
            => functions->ReleaseStringChars(env, str, chars);

        // NewStringUTF
        public jstring NewStringUTF(byte* utf)
            => functions->NewStringUTF(env, utf);
        // GetStringUTFLength
        public jsize GetStringUTFLength(jstring str)
            => functions->GetStringUTFLength(env, str);
        // GetStringUTFChars
        public byte* GetStringUTFChars(jstring str, jboolean* isCopy)
            => functions->GetStringUTFChars(env, str, isCopy);
        // ReleaseStringUTFChars
        public void ReleaseStringUTFChars(jstring str, byte* utf)
            => functions->ReleaseStringUTFChars(env, str, utf);

        // RegisterNatives
        public jint RegisterNatives(jclass clazz, void* methods, jint nMethods)
            => functions->RegisterNatives(env, clazz, methods, nMethods);
        // UnregisterNatives
        public jint UnregisterNatives(jclass clazz)
            => functions->UnregisterNatives(env, clazz);

        // NewWeakGlobalRef
        public jweak NewWeakGlobalRef(jobject obj)
            => functions->NewWeakGlobalRef(env, obj);
        // DeleteWeakGlobalRef
        public void DeleteWeakGlobalRef(jweak weak)
            => functions->DeleteWeakGlobalRef(env, weak);

        /// GetObjectRefType
        public jobjectRefType GetObjectRefType(jobject obj)
            => functions->GetObjectRefType(env, obj);
    }
}
