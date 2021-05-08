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

        // FromReflectedMethod
        public jmethodID FromReflectedMethod(jobject method)
            => functions->FromReflectedMethod(env, method);
        // FromReflectedField
        public jfieldID FromReflectedField(jobject field)
            => functions->FromReflectedField(env, field);

        // ToReflectedMethod
        public jobject ToReflectedMethod(jclass cls, jmethodID methodID, jboolean isStatic)
            => functions->ToReflectedMethod(env, cls, methodID, isStatic);

        // GetSuperclass
        public jclass GetSuperclass(jclass clazz)
            => functions->GetSuperclass(env, clazz);
        // IsAssignableFrom
        public jboolean IsAssignableFrom(jclass clazz1, jclass clazz2)
            => functions->IsAssignableFrom(env, clazz1, clazz2);

        // ToReflectedField
        public jobject ToReflectedMethod(jclass cls, jfieldID fieldID, jboolean isStatic)
            => functions->ToReflectedField(env, cls, fieldID, isStatic);

        // Throw
        public jint Throw(jthrowable obj)
            => functions->Throw(env, obj);
        // ThrowNew
        public jint ThrowNew(jclass clazz, string msg)
            => functions->ThrowNew(env, clazz, msg);
        // ExceptionOccurred
        public jthrowable ExceptionOccurred()
            => functions->ExceptionOccurred(env);
        // ExceptionDescribe
        public void ExceptionDescribe()
            => functions->ExceptionDescribe(env);
        // ExceptionClear
        public void ExceptionClear()
            => functions->ExceptionClear(env);
        // FatalError
        public void FaltalError(string msg)
            => functions->FatalError(env, msg);

        // PushLocalFrame
        public jint PushLocalFrame(jint capacity)
            => functions->PushLocalFrame(env, capacity);
        // PopLocalFrame
        public jobject PopLocalFrame(jobject result)
            => functions->PopLocalFrame(env, result);

        // NewGlobalRef
        public jobject NewGlobalRef(jobject obj)
            => functions->NewGlobalRef(env, obj);
        // DeleteGlobalRef
        public void DeleteGlobalRef(jobject globalRef)
            => functions->DeleteGlobalRef(env, globalRef);
        // DeleteLocalRef
        public void DeleteLocalRef(jobject localRef)
            => functions->DeleteLocalRef(env, localRef);
        // IsSameObject
        public jboolean IsSameObject(jobject ref1, jobject ref2)
            => functions->IsSameObject(env, ref1, ref2);
        // NewLocalRef
        public jobject NewLocalRef(jobject @ref)
            => functions->NewLocalRef(env, @ref);
        // EnsureLocalCapacity
        public jint EnsureLocalCapacity(jint capacity)
            => functions->EnsureLocalCapacity(env, capacity);

        // AllocObject
        public jobject AllocObject(jclass clazz)
            => functions->AllocObject(env, clazz);
        // NewObject
        public jobject NewObject(jclass clazz, jmethodID methodID)
            => functions->NewObject(env, clazz, methodID);
        public jobject NewObject(jclass clazz, jmethodID methodID, jvalue[] args)
            => functions->NewObjectA(env, clazz, methodID, args);

        // GetObjectClass
        public jclass GetObjectClass(jobject obj)
            => functions->GetObjectClass(env, obj);
        // IsInstanceOf
        public jboolean IsInstanceOf(jobject obj, jclass clazz)
            => functions->IsInstanceOf(env, obj, clazz);

        // GetMethodID
        public jmethodID GetMethodID(jclass clazz, string name, string sig)
            => functions->GetMethodID(env, clazz, name, sig);

        // CallObjectMethod
        public jobject CallObjectMethod(jobject obj, jmethodID methodID)
            => functions->CallObjectMethod(env, obj, methodID);
        public jobject CallObjectMethod(jobject obj, jmethodID methodID, params jvalue[] args)
            => functions->CallObjectMethodA(env, obj, methodID, args);

        // CallBooleanMethod
        public jboolean CallBooleanMethod(jobject obj, jmethodID methodID)
            => functions->CallBooleanMethod(env, obj, methodID);
        public jboolean CallBooleanMethod(jobject obj, jmethodID methodID, params jvalue[] args)
            => functions->CallBooleanMethodA(env, obj, methodID, args);

        // CallByteMethod
        public jbyte CallByteMethod(jobject obj, jmethodID methodID)
            => functions->CallByteMethod(env, obj, methodID);
        public jbyte CallByteMethod(jobject obj, jmethodID methodID, params jvalue[] args)
            => functions->CallByteMethodA(env, obj, methodID, args);

        // CallCharMethod
        public jchar CallCharMethod(jobject obj, jmethodID methodID)
            => functions->CallCharMethod(env, obj, methodID);
        public jchar CallCharMethod(jobject obj, jmethodID methodID, params jvalue[] args)
            => functions->CallCharMethodA(env, obj, methodID, args);

        // CallShortMethod
        public jshort CallShortMethod(jobject obj, jmethodID methodID)
            => functions->CallShortMethod(env, obj, methodID);
        public jshort CallShortMethod(jobject obj, jmethodID methodID, params jvalue[] args)
            => functions->CallShortMethodA(env, obj, methodID, args);

        // CallIntMethod
        public jint CallIntMethod(jobject obj, jmethodID methodID)
            => functions->CallIntMethod(env, obj, methodID);
        public jint CallIntMethod(jobject obj, jmethodID methodID, params jvalue[] args)
            => functions->CallIntMethodA(env, obj, methodID, args);

        // CallLongMethod
        public jlong CallLongMethod(jobject obj, jmethodID methodID)
            => functions->CallLongMethod(env, obj, methodID);
        public jlong CallLongMethod(jobject obj, jmethodID methodID, params jvalue[] args)
            => functions->CallLongMethodA(env, obj, methodID, args);

        // CallFloatMethod
        public jfloat CallFloatMethod(jobject obj, jmethodID methodID)
            => functions->CallFloatMethod(env, obj, methodID);
        public jfloat CallFloatMethod(jobject obj, jmethodID methodID, params jvalue[] args)
            => functions->CallFloatMethodA(env, obj, methodID, args);

        // CallDoubleMethod
        public jdouble CallDoubleMethod(jobject obj, jmethodID methodID)
            => functions->CallDoubleMethod(env, obj, methodID);
        public jdouble CallDoubleMethod(jobject obj, jmethodID methodID, params jvalue[] args)
            => functions->CallDoubleMethodA(env, obj, methodID, args);

        // CallVoidMethod
        public void CallVoidMethod(jobject obj, jmethodID methodID)
            => functions->CallVoidMethod(env, obj, methodID);
        public void CallVoidMethod(jobject obj, jmethodID methodID, params jvalue[] args)
            => functions->CallVoidMethodA(env, obj, methodID, args);

        // CallNonvirtualObjectMethod
        public jobject CallNonvirtualObjectMethod(jobject obj, jclass clazz, jmethodID methodID)
            => functions->CallNonvirtualObjectMethod(env, obj, clazz, methodID);
        public jobject CallNonvirtualObjectMethod(jobject obj, jclass clazz, jmethodID methodID, params jvalue[] args)
            => functions->CallNonvirtualObjectMethodA(env, obj, clazz, methodID, args);

        // CallNonvirtualBooleanMethod
        public jboolean CallNonvirtualBooleanMethod(jobject obj, jclass clazz, jmethodID methodID)
            => functions->CallNonvirtualBooleanMethod(env, obj, clazz, methodID);
        public jboolean CallNonvirtualBooleanMethod(jobject obj, jclass clazz, jmethodID methodID, params jvalue[] args)
            => functions->CallNonvirtualBooleanMethodA(env, obj, clazz, methodID, args);

        // CallNonvirtualByteMethod
        public jbyte CallNonvirtualByteMethod(jobject obj, jclass clazz, jmethodID methodID)
            => functions->CallNonvirtualByteMethod(env, obj, clazz, methodID);
        public jbyte CallNonvirtualByteMethod(jobject obj, jclass clazz, jmethodID methodID, params jvalue[] args)
            => functions->CallNonvirtualByteMethodA(env, obj, clazz, methodID, args);

        // CallNonvirtualCharMethod
        public jchar CallNonvirtualCharMethod(jobject obj, jclass clazz, jmethodID methodID)
            => functions->CallNonvirtualCharMethod(env, obj, clazz, methodID);
        public jchar CallNonvirtualCharMethod(jobject obj, jclass clazz, jmethodID methodID, params jvalue[] args)
            => functions->CallNonvirtualCharMethodA(env, obj, clazz, methodID, args);

        // CallNonvirtualShortMethod
        public jshort CallNonvirtualShortMethod(jobject obj, jclass clazz, jmethodID methodID)
            => functions->CallNonvirtualShortMethod(env, obj, clazz, methodID);
        public jshort CallNonvirtualShortMethod(jobject obj, jclass clazz, jmethodID methodID, params jvalue[] args)
            => functions->CallNonvirtualShortMethodA(env, obj, clazz, methodID, args);

        // CallNonvirtualIntMethod
        public jint CallNonvirtualIntMethod(jobject obj, jclass clazz, jmethodID methodID)
            => functions->CallNonvirtualIntMethod(env, obj, clazz, methodID);
        public jint CallNonvirtualIntMethod(jobject obj, jclass clazz, jmethodID methodID, params jvalue[] args)
            => functions->CallNonvirtualIntMethodA(env, obj, clazz, methodID, args);

        // CallNonvirtualLongMethod
        public jlong CallNonvirtualLongMethod(jobject obj, jclass clazz, jmethodID methodID)
            => functions->CallNonvirtualLongMethod(env, obj, clazz, methodID);
        public jlong CallNonvirtualLongMethod(jobject obj, jclass clazz, jmethodID methodID, params jvalue[] args)
            => functions->CallNonvirtualLongMethodA(env, obj, clazz, methodID, args);

        // CallNonvirtualFloatMethod
        public jfloat CallNonvirtualFloatMethod(jobject obj, jclass clazz, jmethodID methodID)
            => functions->CallNonvirtualFloatMethod(env, obj, clazz, methodID);
        public jfloat CallNonvirtualFloatMethod(jobject obj, jclass clazz, jmethodID methodID, params jvalue[] args)
            => functions->CallNonvirtualFloatMethodA(env, obj, clazz, methodID, args);

        // CallNonvirtualDoubleMethod
        public jdouble CallNonvirtualDoubleMethod(jobject obj, jclass clazz, jmethodID methodID)
            => functions->CallNonvirtualDoubleMethod(env, obj, clazz, methodID);
        public jdouble CallNonvirtualDoubleMethod(jobject obj, jclass clazz, jmethodID methodID, params jvalue[] args)
            => functions->CallNonvirtualDoubleMethodA(env, obj, clazz, methodID, args);

        // CallNonvirtualVoidMethod
        public void CallNonvirtualVoidMethod(jobject obj, jclass clazz, jmethodID methodID)
            => functions->CallNonvirtualVoidMethod(env, obj, clazz, methodID);
        public void CallNonvirtualVoidMethod(jobject obj, jclass clazz, jmethodID methodID, params jvalue[] args)
            => functions->CallNonvirtualVoidMethodA(env, obj, clazz, methodID, args);

        // GetFieldID
        public jfieldID GetFieldID(jclass clazz, string name, string sig)
            => functions->GetFieldID(env, clazz, name, sig);

        // GetObjectField
        public jobject GetObjectField(jobject obj, jfieldID fieldID)
            => functions->GetObjectField(env, obj, fieldID);
        // GetBooleanField
        public jboolean GetBooleanField(jobject obj, jfieldID fieldID)
            => functions->GetBooleanField(env, obj, fieldID);
        // GetByteField
        public jbyte GetByteField(jobject obj, jfieldID fieldID)
            => functions->GetByteField(env, obj, fieldID);
        // GetCharField
        public jchar GetCharField(jobject obj, jfieldID fieldID)
            => functions->GetCharField(env, obj, fieldID);
        // GetShortField
        public jshort GetShortField(jobject obj, jfieldID fieldID)
            => functions->GetShortField(env, obj, fieldID);
        // GetIntField
        public jint GetIntField(jobject obj, jfieldID fieldID)
            => functions->GetIntField(env, obj, fieldID);
        // GetLongField
        public jlong GetLongField(jobject obj, jfieldID fieldID)
            => functions->GetLongField(env, obj, fieldID);
        // GetFloatField
        public jfloat GetFloatField(jobject obj, jfieldID fieldID)
            => functions->GetFloatField(env, obj, fieldID);
        // GetDoubleField
        public jdouble GetDoubleField(jobject obj, jfieldID fieldID)
            => functions->GetDoubleField(env, obj, fieldID);

        // SetObjectField
        public void SetObjectField(jobject obj, jfieldID fieldID, jobject value)
            => functions->SetObjectField(env, obj, fieldID, value);
        // SetBooleanField
        public void SetBooleanField(jobject obj, jfieldID fieldID, jboolean value)
            => functions->SetBooleanField(env, obj, fieldID, value);
        // SetByteField
        public void SetByteField(jobject obj, jfieldID fieldID, jbyte value)
            => functions->SetByteField(env, obj, fieldID, value);
        // SetCharField
        public void SetCharField(jobject obj, jfieldID fieldID, jchar value)
            => functions->SetCharField(env, obj, fieldID, value);
        // SetShortField
        public void SetShortField(jobject obj, jfieldID fieldID, jshort value)
            => functions->SetShortField(env, obj, fieldID, value);
        // SetIntField
        public void SetIntField(jobject obj, jfieldID fieldID, jint value)
            => functions->SetIntField(env, obj, fieldID, value);
        // SetLongField
        public void SetLongField(jobject obj, jfieldID fieldID, jlong value)
            => functions->SetLongField(env, obj, fieldID, value);
        // SetFloatField
        public void SetFloatField(jobject obj, jfieldID fieldID, jfloat value)
            => functions->SetFloatField(env, obj, fieldID, value);
        // SetDoubleField
        public void SetDoubleField(jobject obj, jfieldID fieldID, jdouble value)
            => functions->SetDoubleField(env, obj, fieldID, value);

        // GetStaticMethodID
        public jmethodID GetStaticMethodID(jclass clazz, string name, string sig)
            => functions->GetStaticMethodID(env, clazz, name, sig);

        // CallStaticObjectMethod
        public jobject CallStaticObjectMethod(jclass clazz, jmethodID methodID)
            => functions->CallStaticObjectMethod(env, clazz, methodID);
        public jobject CallStaticObjectMethod(jclass clazz, jmethodID methodID, params jvalue[] args)
            => functions->CallStaticObjectMethodA(env, clazz, methodID, args);

        // CallStaticBooleanMethod
        public jboolean CallStaticBooleanMethod(jclass clazz, jmethodID methodID)
            => functions->CallStaticBooleanMethod(env, clazz, methodID);
        public jboolean CallStaticBooleanMethod(jclass clazz, jmethodID methodID, params jvalue[] args)
            => functions->CallStaticBooleanMethodA(env, clazz, methodID, args);

        // CallStaticByteMethod
        public jbyte CallStaticByteMethod(jclass clazz, jmethodID methodID)
            => functions->CallStaticByteMethod(env, clazz, methodID);
        public jbyte CallStaticByteMethod(jclass clazz, jmethodID methodID, params jvalue[] args)
            => functions->CallStaticByteMethodA(env, clazz, methodID, args);

        // CallStaticCharMethod
        public jchar CallStaticCharMethod(jclass clazz, jmethodID methodID)
            => functions->CallStaticCharMethod(env, clazz, methodID);
        public jchar CallStaticCharMethod(jclass clazz, jmethodID methodID, params jvalue[] args)
            => functions->CallStaticCharMethodA(env, clazz, methodID, args);

        // CallStaticShortMethod
        public jshort CallStaticShortMethod(jclass clazz, jmethodID methodID)
            => functions->CallStaticShortMethod(env, clazz, methodID);
        public jshort CallStaticShortMethod(jclass clazz, jmethodID methodID, params jvalue[] args)
            => functions->CallStaticShortMethodA(env, clazz, methodID, args);

        // CallStaticIntMethod
        public jint CallStaticIntMethod(jclass clazz, jmethodID methodID)
            => functions->CallStaticIntMethod(env, clazz, methodID);
        public jint CallStaticIntMethod(jclass clazz, jmethodID methodID, params jvalue[] args)
            => functions->CallStaticIntMethodA(env, clazz, methodID, args);

        // CallStaticLongMethod
        public jlong CallStaticLongMethod(jclass clazz, jmethodID methodID)
            => functions->CallStaticLongMethod(env, clazz, methodID);
        public jlong CallStaticLongMethod(jclass clazz, jmethodID methodID, params jvalue[] args)
            => functions->CallStaticLongMethodA(env, clazz, methodID, args);

        // CallStaticFloatMethod
        public jfloat CallStaticFloatMethod(jclass clazz, jmethodID methodID)
            => functions->CallStaticFloatMethod(env, clazz, methodID);
        public jfloat CallStaticFloatMethod(jclass clazz, jmethodID methodID, params jvalue[] args)
            => functions->CallStaticFloatMethodA(env, clazz, methodID, args);

        // CallStaticDoubleMethod
        public jdouble CallStaticDoubleMethod(jclass clazz, jmethodID methodID)
            => functions->CallStaticDoubleMethod(env, clazz, methodID);
        public jdouble CallStaticDoubleMethod(jclass clazz, jmethodID methodID, params jvalue[] args)
            => functions->CallStaticDoubleMethodA(env, clazz, methodID, args);

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
        // GetStaticBooleanField
        public jboolean GetStaticBooleanField(jclass clazz, jfieldID fieldID)
            => functions->GetStaticBooleanField(env, clazz, fieldID);
        // GetStaticByteField
        public jbyte GetStaticByteField(jclass clazz, jfieldID fieldID)
            => functions->GetStaticByteField(env, clazz, fieldID);
        // GetStaticCharField
        public jchar GetStaticCharField(jclass clazz, jfieldID fieldID)
            => functions->GetStaticCharField(env, clazz, fieldID);
        // GetStaticShortField
        public jshort GetStaticShortField(jclass clazz, jfieldID fieldID)
            => functions->GetStaticShortField(env, clazz, fieldID);
        // GetStaticIntField
        public jint GetStaticIntField(jclass clazz, jfieldID fieldID)
            => functions->GetStaticIntField(env, clazz, fieldID);
        // GetStaticLongField
        public jlong GetStaticLongField(jclass clazz, jfieldID fieldID)
            => functions->GetStaticLongField(env, clazz, fieldID);
        // GetStaticFloatField
        public jfloat GetStaticFloatField(jclass clazz, jfieldID fieldID)
            => functions->GetStaticFloatField(env, clazz, fieldID);
        // GetStaticDoubleField
        public jdouble GetStaticDoubleField(jclass clazz, jfieldID fieldID)
            => functions->GetStaticDoubleField(env, clazz, fieldID);

        // SetStaticObjectField
        public void SetStaticObjectField(jclass clazz, jfieldID fieldID, jobject value)
            => functions->SetStaticObjectField(env, clazz, fieldID, value);
        // SetStaticBooleanField
        public void SetStaticBooleanField(jclass clazz, jfieldID fieldID, jboolean value)
            => functions->SetStaticBooleanField(env, clazz, fieldID, value);
        // SetStaticByteField
        public void SetStaticByteField(jclass clazz, jfieldID fieldID, jbyte value)
            => functions->SetStaticByteField(env, clazz, fieldID, value);
        // SetStaticCharField
        public void SetStaticCharField(jclass clazz, jfieldID fieldID, jchar value)
            => functions->SetStaticCharField(env, clazz, fieldID, value);
        // SetStaticShortField
        public void SetStaticShortField(jclass clazz, jfieldID fieldID, jshort value)
            => functions->SetStaticShortField(env, clazz, fieldID, value);
        // SetStaticIntField
        public void SetStaticIntField(jclass clazz, jfieldID fieldID, jint value)
            => functions->SetStaticIntField(env, clazz, fieldID, value);
        // SetStaticLongField
        public void SetStaticLongField(jclass clazz, jfieldID fieldID, jlong value)
            => functions->SetStaticLongField(env, clazz, fieldID, value);
        // SetStaticFloatField
        public void SetStaticFloatField(jclass clazz, jfieldID fieldID, jfloat value)
            => functions->SetStaticFloatField(env, clazz, fieldID, value);
        // SetStaticDoubleField
        public void SetStaticDoubleField(jclass clazz, jfieldID fieldID, jdouble value)
            => functions->SetStaticDoubleField(env, clazz, fieldID, value);

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

        // GetArrayLength
        public jsize GetArrayLength(jarray array)
            => functions->GetArrayLength(env, array);

        // NewObjectArray
        public jobjectArray NewObjectArray(jsize length, jclass elementClass, jobject initialElement)
            => functions->NewObjectArray(env, length, elementClass, initialElement);
        // GetObjectArrayElement
        public jobject GetObjectArrayElement(jobjectArray array, jsize index)
            => functions->GetObjectArrayElement(env, array, index);
        // SetObjectArrayElement
        public void SetObjectArrayElement(jobjectArray array, jsize index, jobject value)
            => functions->SetObjectArrayElement(env, array, index, value);

        // NewBooleanArray
        public jbooleanArray NewBooleanArray(jsize length)
            => functions->NewBooleanArray(env, length);
        // NewByteArray
        public jbyteArray NewByteArray(jsize length)
            => functions->NewByteArray(env, length);
        // NewCharArray
        public jcharArray NewCharArray(jsize length)
            => functions->NewCharArray(env, length);
        // NewShortArray
        public jshortArray NewShortArray(jsize length)
            => functions->NewShortArray(env, length);
        // NewIntArray
        public jintArray NewIntArray(jsize length)
            => functions->NewIntArray(env, length);
        // NewLongArray
        public jlongArray NewLongArray(jsize length)
            => functions->NewLongArray(env, length);
        // NewFloatArray
        public jfloatArray NewFloatArray(jsize length)
            => functions->NewFloatArray(env, length);
        // NewDoubleArray
        public jdoubleArray NewDoubleArray(jsize length)
            => functions->NewDoubleArray(env, length);

        // GetBooleanArrayElements
        public jboolean* GetBooleanArrayElements(jbooleanArray array, jboolean* isCopy)
            => functions->GetBooleanArrayElements(env, array, isCopy);
        // GetByteArrayElements
        public jbyte* GetByteArrayElements(jbyteArray array, jboolean* isCopy)
            => functions->GetByteArrayElements(env, array, isCopy);
        // GetCharArrayElements
        public jchar* GetCharArrayElements(jcharArray array, jboolean* isCopy)
            => functions->GetCharArrayElements(env, array, isCopy);
        // GetShortArrayElements
        public jshort* GetShortArrayElements(jshortArray array, jboolean* isCopy)
            => functions->GetShortArrayElements(env, array, isCopy);
        // GetIntArrayElements
        public jint* GetIntArrayElements(jintArray array, jboolean* isCopy)
            => functions->GetIntArrayElements(env, array, isCopy);
        // GetLongArrayElements
        public jlong* GetLongArrayElements(jlongArray array, jboolean* isCopy)
            => functions->GetLongArrayElements(env, array, isCopy);
        // GetFloatArrayElements
        public jfloat* GetFloatArrayElements(jfloatArray array, jboolean* isCopy)
            => functions->GetFloatArrayElements(env, array, isCopy);
        // GetDoubleArrayElements
        public jdouble* GetDoubleArrayElements(jdoubleArray array, jboolean* isCopy)
            => functions->GetDoubleArrayElements(env, array, isCopy);

        // ReleaseBooleanArrayElements
        public void ReleaseBooleanArrayElements(jbooleanArray array, jboolean* elems, jint mode)
            => functions->ReleaseBooleanArrayElements(env, array, elems, mode);
        // ReleaseByteArrayElements
        public void ReleaseByteArrayElements(jbyteArray array, jbyte* elems, jint mode)
            => functions->ReleaseByteArrayElements(env, array, elems, mode);
        // ReleaseCharArrayElements
        public void ReleaseCharArrayElements(jcharArray array, jchar* elems, jint mode)
            => functions->ReleaseCharArrayElements(env, array, elems, mode);
        // ReleaseShortArrayElements
        public void ReleaseShortArrayElements(jshortArray array, jshort* elems, jint mode)
            => functions->ReleaseShortArrayElements(env, array, elems, mode);
        // ReleaseIntArrayElements
        public void ReleaseIntArrayElements(jintArray array, jint* elems, jint mode)
            => functions->ReleaseIntArrayElements(env, array, elems, mode);
        // ReleaseLongArrayElements
        public void ReleaseLongArrayElements(jlongArray array, jlong* elems, jint mode)
            => functions->ReleaseLongArrayElements(env, array, elems, mode);
        // ReleaseFloatArrayElements
        public void ReleaseFloatArrayElements(jfloatArray array, jfloat* elems, jint mode)
            => functions->ReleaseFloatArrayElements(env, array, elems, mode);
        // ReleaseDoubleArrayElements
        public void ReleaseDoubleArrayElements(jdoubleArray array, jdouble* elems, jint mode)
            => functions->ReleaseDoubleArrayElements(env, array, elems, mode);

        // GetBooleanArrayRegion
        public void GetBooleanArrayRegion(jbooleanArray array, jsize start, jsize len, jboolean* buf)
            => functions->GetBooleanArrayRegion(env, array, start, len, buf);
        // GetByteArrayRegion
        public void GetByteArrayRegion(jbyteArray array, jsize start, jsize len, jbyte* buf)
            => functions->GetByteArrayRegion(env, array, start, len, buf);
        // GetCharArrayRegion
        public void GetCharArrayRegion(jcharArray array, jsize start, jsize len, jchar* buf)
            => functions->GetCharArrayRegion(env, array, start, len, buf);
        // GetShortArrayRegion
        public void GetShortArrayRegion(jshortArray array, jsize start, jsize len, jshort* buf)
            => functions->GetShortArrayRegion(env, array, start, len, buf);
        // GetIntArrayRegion
        public void GetIntArrayRegion(jintArray array, jsize start, jsize len, jint* buf)
            => functions->GetIntArrayRegion(env, array, start, len, buf);
        // GetLongArrayRegion
        public void GetLongArrayRegion(jlongArray array, jsize start, jsize len, jlong* buf)
            => functions->GetLongArrayRegion(env, array, start, len, buf);
        // GetFloatArrayRegion
        public void GetFloatArrayRegion(jfloatArray array, jsize start, jsize len, jfloat* buf)
            => functions->GetFloatArrayRegion(env, array, start, len, buf);
        // GetDoubleArrayRegion
        public void GetDoubleArrayRegion(jdoubleArray array, jsize start, jsize len, jdouble* buf)
            => functions->GetDoubleArrayRegion(env, array, start, len, buf);

        // SetBooleanArrayRegion
        public void SetBooleanArrayRegion(jbooleanArray array, jsize start, jsize len, jboolean* buf)
            => functions->SetBooleanArrayRegion(env, array, start, len, buf);
        // SetByteArrayRegion
        public void SetByteArrayRegion(jbyteArray array, jsize start, jsize len, jbyte* buf)
            => functions->SetByteArrayRegion(env, array, start, len, buf);
        // SetCharArrayRegion
        public void SetCharArrayRegion(jcharArray array, jsize start, jsize len, jchar* buf)
            => functions->SetCharArrayRegion(env, array, start, len, buf);
        // SetShortArrayRegion
        public void SetShortArrayRegion(jshortArray array, jsize start, jsize len, jshort* buf)
            => functions->SetShortArrayRegion(env, array, start, len, buf);
        // SetIntArrayRegion
        public void SetIntArrayRegion(jintArray array, jsize start, jsize len, jint* buf)
            => functions->SetIntArrayRegion(env, array, start, len, buf);
        // SetLongArrayRegion
        public void SetLongArrayRegion(jlongArray array, jsize start, jsize len, jlong* buf)
            => functions->SetLongArrayRegion(env, array, start, len, buf);
        // SetFloatArrayRegion
        public void SetFloatArrayRegion(jfloatArray array, jsize start, jsize len, jfloat* buf)
            => functions->SetFloatArrayRegion(env, array, start, len, buf);
        // SetDoubleArrayRegion
        public void SetDoubleArrayRegion(jdoubleArray array, jsize start, jsize len, jdouble* buf)
            => functions->SetDoubleArrayRegion(env, array, start, len, buf);

        // RegisterNatives
        public jint RegisterNatives(jclass clazz, void* methods, jint nMethods)
            => functions->RegisterNatives(env, clazz, methods, nMethods);
        // UnregisterNatives
        public jint UnregisterNatives(jclass clazz)
            => functions->UnregisterNatives(env, clazz);

        // MonitorEnter
        public jint MonitorEnter(jobject obj)
            => functions->MonitorEnter(env, obj);
        // MonitorExit
        public jint MonitorExit(jobject obj)
            => functions->MonitorExit(env, obj);

        // GetJavaVM
        internal jint GetJavaVM(JavaVM** vm)
            => functions->GetJavaVM(env, vm);

        // GetStringRegion
        public void GetStringRegion(jstring str, jsize start, jsize len, jchar* buf)
            => functions->GetStringRegion(env, str, start, len, buf);
        // GetStringUTFRegion
        public void GetStringUTFRegion(jstring str, jsize start, jsize len, byte* buf)
            => functions->GetStringUTFRegion(env, str, start, len, buf);

        // GetPrimitiveArrayCritical
        public void* GetPrimitiveArrayCritical(jarray array, jboolean* isCopy)
            => functions->GetPrimitiveArrayCritical(env, array, isCopy);
        // ReleasePrimitiveArrayCritical
        public void ReleasePrimitiveArrayCritical(jarray array, void* carray, jint mode)
            => functions->ReleasePrimitiveArrayCritical(env, array, carray, mode);

        // GetStringCritical
        public jchar* GetStringCritical(jstring str, jboolean* isCopy)
            => functions->GetStringCritical(env, str, isCopy);
        // ReleaseStringCritical
        public void ReleaseStringCritical(jstring str, jchar* carray)
            => functions->ReleaseStringCritical(env, str, carray);

        // NewWeakGlobalRef
        public jweak NewWeakGlobalRef(jobject obj)
            => functions->NewWeakGlobalRef(env, obj);
        // DeleteWeakGlobalRef
        public void DeleteWeakGlobalRef(jweak weak)
            => functions->DeleteWeakGlobalRef(env, weak);

        // ExceptionCheck
        public jboolean ExceptionCheck()
            => functions->ExceptionCheck(env);

        // NewDirectByteBuffer
        public jobject NewDirectByteBuffer(void* address, jlong capacity)
            => functions->NewDirectByteBuffer(env, address, capacity);
        // GetDirectBufferAddress
        public void* GetDirectBufferAddress(jobject buf)
            => functions->GetDirectBufferAddress(env, buf);
        // GetDirectBufferCapacity
        public jlong GetDirectBufferCapacity(jobject buf)
            => functions->GetDirectBufferCapacity(env, buf);

        /* New JNI 1.6 Features */

        /// GetObjectRefType
        public jobjectRefType GetObjectRefType(jobject obj)
            => functions->GetObjectRefType(env, obj);

        /* Module Features */

        // GetModule
        public jobject GetModule(jclass clazz)
            => functions->GetModule(env, clazz);
    }
}
