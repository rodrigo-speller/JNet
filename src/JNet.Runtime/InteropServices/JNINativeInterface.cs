// Copyright (c) Rodrigo Speller. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.

using System;
using System.Runtime.InteropServices;

namespace JNet.Runtime.InteropServices
{
    [StructLayout(LayoutKind.Sequential)]
    internal unsafe struct JNINativeInterface
    {
        private IntPtr reserved0;
        private IntPtr reserved1;
        private IntPtr reserved2;
        private IntPtr reserved3;

        // GetVersion
        public delegate* unmanaged<JNIEnv*, jint> GetVersion;

        // DefineClass
        public delegate* unmanaged<JNIEnv*, string, jobject, jbyte*, jsize, jclass> DefineClass;

        // FindClass
        public delegate* unmanaged<JNIEnv*, string, jclass> FindClass;

        // FromReflectedMethod
        public delegate* unmanaged<JNIEnv*, jobject, jmethodID> FromReflectedMethod;
        // FromReflectedField
        public delegate* unmanaged<JNIEnv*, jobject, jfieldID> FromReflectedField;

        // ToReflectedMethod
        public delegate* unmanaged<JNIEnv*, jclass, jmethodID, jboolean, jobject> ToReflectedMethod;

        // GetSuperclass
        public delegate* unmanaged<JNIEnv*, jclass, jclass> GetSuperclass;
        // IsAssignableFrom
        public delegate* unmanaged<JNIEnv*, jclass, jclass, jboolean> IsAssignableFrom;

        // ToReflectedField
        public delegate* unmanaged<JNIEnv*, jclass, jfieldID, jboolean, jobject> ToReflectedField;

        // Throw
        public delegate* unmanaged<JNIEnv*, jthrowable, jint> Throw;
        // ThrowNew
        public delegate* unmanaged<JNIEnv*, jclass, string, jint> ThrowNew;
        // ExceptionOccurred
        public delegate* unmanaged<JNIEnv*, jthrowable> ExceptionOccurred;
        // ExceptionDescribe
        public delegate* unmanaged<JNIEnv*, void> ExceptionDescribe;
        // ExceptionClear
        public delegate* unmanaged<JNIEnv*, void> ExceptionClear;
        // FatalError
        public delegate* unmanaged<JNIEnv*, string, void> FatalError;

        // PushLocalFrame
        public delegate* unmanaged<JNIEnv*, jint, jint> PushLocalFrame;
        // PopLocalFrame
        public delegate* unmanaged<JNIEnv*, jobject, jobject> PopLocalFrame;

        // NewGlobalRef
        public delegate* unmanaged<JNIEnv*, jobject, jobject> NewGlobalRef;
        // DeleteGlobalRef
        public delegate* unmanaged<JNIEnv*, jobject, void> DeleteGlobalRef;
        // DeleteLocalRef
        public delegate* unmanaged<JNIEnv*, jobject, void> DeleteLocalRef;
        // IsSameObject
        public delegate* unmanaged<JNIEnv*, jobject, jobject, jboolean> IsSameObject;
        // NewLocalRef
        public delegate* unmanaged<JNIEnv*, jobject, jobject> NewLocalRef;
        // EnsureLocalCapacity
        public delegate* unmanaged<JNIEnv*, jint, jint> EnsureLocalCapacity;

        // AllocObject
        public delegate* unmanaged<JNIEnv*, jclass, jobject> AllocObject;
        // NewObject
        public delegate* unmanaged<JNIEnv*, jclass, jmethodID, jobject> NewObject;
        public IntPtr NewObjectV;
        public delegate* unmanaged<JNIEnv*, jclass, jmethodID, jvalue[], jobject> NewObjectA;

        // GetObjectClass
        public delegate* unmanaged<JNIEnv*, jobject, jclass> GetObjectClass;
        // IsInstanceOf
        public delegate* unmanaged<JNIEnv*, jobject, jclass, jboolean> IsInstanceOf;

        // GetMethodID
        public delegate* unmanaged<JNIEnv*, jclass, string, string, jmethodID> GetMethodID;

        // CallObjectMethod
        public delegate* unmanaged<JNIEnv*, jobject, jmethodID, jboolean> CallObjectMethod;
        public IntPtr CallObjectMethodV;
        public delegate* unmanaged<JNIEnv*, jobject, jmethodID, jvalue[], jboolean> CallObjectMethodA;

        // CallBooleanMethod
        public delegate* unmanaged<JNIEnv*, jobject, jmethodID, jboolean> CallBooleanMethod;
        public IntPtr CallBooleanMethodV;
        public delegate* unmanaged<JNIEnv*, jobject, jmethodID, jvalue[], jboolean> CallBooleanMethodA;

        // CallByteMethod
        public delegate* unmanaged<JNIEnv*, jobject, jmethodID, jbyte> CallByteMethod;
        public IntPtr CallByteMethodV;
        public delegate* unmanaged<JNIEnv*, jobject, jmethodID, jvalue[], jbyte> CallByteMethodA;

        // CallCharMethod
        public delegate* unmanaged<JNIEnv*, jobject, jmethodID, jchar> CallCharMethod;
        public IntPtr CallCharMethodV;
        public delegate* unmanaged<JNIEnv*, jobject, jmethodID, jvalue[], jchar> CallCharMethodA;

        // CallShortMethod
        public delegate* unmanaged<JNIEnv*, jobject, jmethodID, jshort> CallShortMethod;
        public IntPtr CallShortMethodV;
        public delegate* unmanaged<JNIEnv*, jobject, jmethodID, jvalue[], jshort> CallShortMethodA;

        // CallIntMethod
        public delegate* unmanaged<JNIEnv*, jobject, jmethodID, jint> CallIntMethod;
        public IntPtr CallIntMethodV;
        public delegate* unmanaged<JNIEnv*, jobject, jmethodID, jvalue[], jint> CallIntMethodA;

        // CallLongMethod
        public delegate* unmanaged<JNIEnv*, jobject, jmethodID, jlong> CallLongMethod;
        public IntPtr CallLongMethodV;
        public delegate* unmanaged<JNIEnv*, jobject, jmethodID, jvalue[], jlong> CallLongMethodA;

        // CallFloatMethod
        public delegate* unmanaged<JNIEnv*, jobject, jmethodID, jfloat> CallFloatMethod;
        public IntPtr CallFloatMethodV;
        public delegate* unmanaged<JNIEnv*, jobject, jmethodID, jvalue[], jfloat> CallFloatMethodA;

        // CallDoubleMethod
        public delegate* unmanaged<JNIEnv*, jobject, jmethodID, jdouble> CallDoubleMethod;
        public IntPtr CallDoubleMethodV;
        public delegate* unmanaged<JNIEnv*, jobject, jmethodID, jvalue[], jdouble> CallDoubleMethodA;

        // CallVoidMethod
        public delegate* unmanaged<JNIEnv*, jobject, jmethodID, void> CallVoidMethod;
        public IntPtr CallVoidMethodV;
        public delegate* unmanaged<JNIEnv*, jobject, jmethodID, jvalue[], void> CallVoidMethodA;

        // CallNonvirtualObjectMethod
        public delegate* unmanaged<JNIEnv*, jobject, jclass, jmethodID, jobject> CallNonvirtualObjectMethod;
        public IntPtr CallNonvirtualObjectMethodV;
        public delegate* unmanaged<JNIEnv*, jobject, jclass, jmethodID, jvalue[], jobject> CallNonvirtualObjectMethodA;

        // CallNonvirtualBooleanMethod
        public delegate* unmanaged<JNIEnv*, jobject, jclass, jmethodID, jboolean> CallNonvirtualBooleanMethod;
        public IntPtr CallNonvirtualBooleanMethodV;
        public delegate* unmanaged<JNIEnv*, jobject, jclass, jmethodID, jvalue[], jboolean> CallNonvirtualBooleanMethodA;

        // CallNonvirtualByteMethod
        public delegate* unmanaged<JNIEnv*, jobject, jclass, jmethodID, jbyte> CallNonvirtualByteMethod;
        public IntPtr CallNonvirtualByteMethodV;
        public delegate* unmanaged<JNIEnv*, jobject, jclass, jmethodID, jvalue[], jbyte> CallNonvirtualByteMethodA;

        // CallNonvirtualCharMethod
        public delegate* unmanaged<JNIEnv*, jobject, jclass, jmethodID, jchar> CallNonvirtualCharMethod;
        public IntPtr CallNonvirtualCharMethodV;
        public delegate* unmanaged<JNIEnv*, jobject, jclass, jmethodID, jvalue[], jchar> CallNonvirtualCharMethodA;

        // CallNonvirtualShortMethod
        public delegate* unmanaged<JNIEnv*, jobject, jclass, jmethodID, jshort> CallNonvirtualShortMethod;
        public IntPtr CallNonvirtualShortMethodV;
        public delegate* unmanaged<JNIEnv*, jobject, jclass, jmethodID, jvalue[], jshort> CallNonvirtualShortMethodA;

        // CallNonvirtualIntMethod
        public delegate* unmanaged<JNIEnv*, jobject, jclass, jmethodID, jint> CallNonvirtualIntMethod;
        public IntPtr CallNonvirtualIntMethodV;
        public delegate* unmanaged<JNIEnv*, jobject, jclass, jmethodID, jvalue[], jint> CallNonvirtualIntMethodA;

        // CallNonvirtualLongMethod
        public delegate* unmanaged<JNIEnv*, jobject, jclass, jmethodID, jlong> CallNonvirtualLongMethod;
        public IntPtr CallNonvirtualLongMethodV;
        public delegate* unmanaged<JNIEnv*, jobject, jclass, jmethodID, jvalue[], jlong> CallNonvirtualLongMethodA;

        // CallNonvirtualFloatMethod
        public delegate* unmanaged<JNIEnv*, jobject, jclass, jmethodID, jfloat> CallNonvirtualFloatMethod;
        public IntPtr CallNonvirtualFloatMethodV;
        public delegate* unmanaged<JNIEnv*, jobject, jclass, jmethodID, jvalue[], jfloat> CallNonvirtualFloatMethodA;

        // CallNonvirtualDoubleMethod
        public delegate* unmanaged<JNIEnv*, jobject, jclass, jmethodID, jdouble> CallNonvirtualDoubleMethod;
        public IntPtr CallNonvirtualDoubleMethodV;
        public delegate* unmanaged<JNIEnv*, jobject, jclass, jmethodID, jvalue[], jdouble> CallNonvirtualDoubleMethodA;

        // CallNonvirtualVoidMethod
        public delegate* unmanaged<JNIEnv*, jobject, jclass, jmethodID, void> CallNonvirtualVoidMethod;
        public IntPtr CallNonvirtualVoidMethodV;
        public delegate* unmanaged<JNIEnv*, jobject, jclass, jmethodID, jvalue[], void> CallNonvirtualVoidMethodA;

        // GetFieldID
        public delegate* unmanaged<JNIEnv*, jclass, string, string, jfieldID> GetFieldID;

        // GetObjectField
        public delegate* unmanaged<JNIEnv*, jobject, jfieldID, jobject> GetObjectField;
        // GetBooleanField
        public delegate* unmanaged<JNIEnv*, jobject, jfieldID, jboolean> GetBooleanField;
        // GetByteField
        public delegate* unmanaged<JNIEnv*, jobject, jfieldID, jbyte> GetByteField;
        // GetCharField
        public delegate* unmanaged<JNIEnv*, jobject, jfieldID, jchar> GetCharField;
        // GetShortField
        public delegate* unmanaged<JNIEnv*, jobject, jfieldID, jshort> GetShortField;
        // GetIntField
        public delegate* unmanaged<JNIEnv*, jobject, jfieldID, jint> GetIntField;
        // GetLongField
        public delegate* unmanaged<JNIEnv*, jobject, jfieldID, jlong> GetLongField;
        // GetFloatField
        public delegate* unmanaged<JNIEnv*, jobject, jfieldID, jfloat> GetFloatField;
        // GetDoubleField
        public delegate* unmanaged<JNIEnv*, jobject, jfieldID, jdouble> GetDoubleField;

        // SetObjectField
        public delegate* unmanaged<JNIEnv*, jobject, jfieldID, jobject, void> SetObjectField;
        // SetBooleanField
        public delegate* unmanaged<JNIEnv*, jobject, jfieldID, jboolean, void> SetBooleanField;
        // SetByteField
        public delegate* unmanaged<JNIEnv*, jobject, jfieldID, jbyte, void> SetByteField;
        // SetCharField
        public delegate* unmanaged<JNIEnv*, jobject, jfieldID, jchar, void> SetCharField;
        // SetShortField
        public delegate* unmanaged<JNIEnv*, jobject, jfieldID, jshort, void> SetShortField;
        // SetIntField
        public delegate* unmanaged<JNIEnv*, jobject, jfieldID, jint, void> SetIntField;
        // SetLongField
        public delegate* unmanaged<JNIEnv*, jobject, jfieldID, jlong, void> SetLongField;
        // SetFloatField
        public delegate* unmanaged<JNIEnv*, jobject, jfieldID, jfloat, void> SetFloatField;
        // SetDoubleField
        public delegate* unmanaged<JNIEnv*, jobject, jfieldID, jdouble, void> SetDoubleField;

        // GetStaticMethodID
        public delegate* unmanaged<JNIEnv*, jclass, string, string, jmethodID> GetStaticMethodID;

        // CallStaticObjectMethod
        public delegate* unmanaged<JNIEnv*, jclass, jmethodID, jobject> CallStaticObjectMethod;
        public IntPtr CallStaticObjectMethodV;
        public delegate* unmanaged<JNIEnv*, jclass, jmethodID, jvalue[], jobject> CallStaticObjectMethodA;

        // CallStaticBooleanMethod
        public delegate* unmanaged<JNIEnv*, jclass, jmethodID, jboolean> CallStaticBooleanMethod;
        public IntPtr CallStaticBooleanMethodV;
        public delegate* unmanaged<JNIEnv*, jclass, jmethodID, jvalue[], jboolean> CallStaticBooleanMethodA;

        // CallStaticByteMethod
        public delegate* unmanaged<JNIEnv*, jclass, jmethodID, jbyte> CallStaticByteMethod;
        public IntPtr CallStaticByteMethodV;
        public delegate* unmanaged<JNIEnv*, jclass, jmethodID, jvalue[], jbyte> CallStaticByteMethodA;

        // CallStaticCharMethod
        public delegate* unmanaged<JNIEnv*, jclass, jmethodID, jchar> CallStaticCharMethod;
        public IntPtr CallStaticCharMethodV;
        public delegate* unmanaged<JNIEnv*, jclass, jmethodID, jvalue[], jchar> CallStaticCharMethodA;

        // CallStaticShortMethod
        public delegate* unmanaged<JNIEnv*, jclass, jmethodID, jshort> CallStaticShortMethod;
        public IntPtr CallStaticShortMethodV;
        public delegate* unmanaged<JNIEnv*, jclass, jmethodID, jvalue[], jshort> CallStaticShortMethodA;

        // CallStaticIntMethod
        public delegate* unmanaged<JNIEnv*, jclass, jmethodID, jint> CallStaticIntMethod;
        public IntPtr CallStaticIntMethodV;
        public delegate* unmanaged<JNIEnv*, jclass, jmethodID, jvalue[], jint> CallStaticIntMethodA;

        // CallStaticLongMethod
        public delegate* unmanaged<JNIEnv*, jclass, jmethodID, jlong> CallStaticLongMethod;
        public IntPtr CallStaticLongMethodV;
        public delegate* unmanaged<JNIEnv*, jclass, jmethodID, jvalue[], jlong> CallStaticLongMethodA;

        // CallStaticFloatMethod
        public delegate* unmanaged<JNIEnv*, jclass, jmethodID, jfloat> CallStaticFloatMethod;
        public IntPtr CallStaticFloatMethodV;
        public delegate* unmanaged<JNIEnv*, jclass, jmethodID, jvalue[], jfloat> CallStaticFloatMethodA;

        // CallStaticDoubleMethod
        public delegate* unmanaged<JNIEnv*, jclass, jmethodID, jdouble> CallStaticDoubleMethod;
        public IntPtr CallStaticDoubleMethodV;
        public delegate* unmanaged<JNIEnv*, jclass, jmethodID, jvalue[], jdouble> CallStaticDoubleMethodA;

        // CallStaticVoidMethod
        public delegate* unmanaged<JNIEnv*, jclass, jmethodID, void> CallStaticVoidMethod;
        public IntPtr CallStaticVoidMethodV;
        public delegate* unmanaged<JNIEnv*, jclass, jmethodID, jvalue[], void> CallStaticVoidMethodA;

        // GetStaticFieldID
        public delegate* unmanaged<JNIEnv*, jclass, string, string, jfieldID> GetStaticFieldID;
        // GetStaticObjectField
        public delegate* unmanaged<JNIEnv*, jclass, jfieldID, jobject> GetStaticObjectField;
        // GetStaticBooleanField
        public delegate* unmanaged<JNIEnv*, jclass, jfieldID, jboolean> GetStaticBooleanField;
        // GetStaticByteField
        public delegate* unmanaged<JNIEnv*, jclass, jfieldID, jbyte> GetStaticByteField;
        // GetStaticCharField
        public delegate* unmanaged<JNIEnv*, jclass, jfieldID, jchar> GetStaticCharField;
        // GetStaticShortField
        public delegate* unmanaged<JNIEnv*, jclass, jfieldID, jshort> GetStaticShortField;
        // GetStaticIntField
        public delegate* unmanaged<JNIEnv*, jclass, jfieldID, jint> GetStaticIntField;
        // GetStaticLongField
        public delegate* unmanaged<JNIEnv*, jclass, jfieldID, jlong> GetStaticLongField;
        // GetStaticFloatField
        public delegate* unmanaged<JNIEnv*, jclass, jfieldID, jfloat> GetStaticFloatField;
        // GetStaticDoubleField
        public delegate* unmanaged<JNIEnv*, jclass, jfieldID, jdouble> GetStaticDoubleField;

        // SetStaticObjectField
        public delegate* unmanaged<JNIEnv*, jclass, jfieldID, jobject, void> SetStaticObjectField;
        // SetStaticBooleanField
        public delegate* unmanaged<JNIEnv*, jclass, jfieldID, jboolean, void> SetStaticBooleanField;
        // SetStaticByteField
        public delegate* unmanaged<JNIEnv*, jclass, jfieldID, jbyte, void> SetStaticByteField;
        // SetStaticCharField
        public delegate* unmanaged<JNIEnv*, jclass, jfieldID, jchar, void> SetStaticCharField;
        // SetStaticShortField
        public delegate* unmanaged<JNIEnv*, jclass, jfieldID, jshort, void> SetStaticShortField;
        // SetStaticIntField
        public delegate* unmanaged<JNIEnv*, jclass, jfieldID, jint, void> SetStaticIntField;
        // SetStaticLongField
        public delegate* unmanaged<JNIEnv*, jclass, jfieldID, jlong, void> SetStaticLongField;
        // SetStaticFloatField
        public delegate* unmanaged<JNIEnv*, jclass, jfieldID, jfloat, void> SetStaticFloatField;
        // SetStaticDoubleField
        public delegate* unmanaged<JNIEnv*, jclass, jfieldID, jdouble, void> SetStaticDoubleField;

        // NewString
        public delegate* unmanaged<JNIEnv*, jchar*, jsize, jstring> NewString;
        // GetStringLength
        public delegate* unmanaged<JNIEnv*, jstring, jsize> GetStringLength;
        // GetStringChars
        public delegate* unmanaged<JNIEnv*, jstring, jboolean*, jchar*> GetStringChars;
        // ReleaseStringChars
        public delegate* unmanaged<JNIEnv*, jstring, jchar*, void> ReleaseStringChars;

        // NewStringUTF
        public delegate* unmanaged<JNIEnv*, byte*, jstring> NewStringUTF;
        // GetStringUTFLength
        public delegate* unmanaged<JNIEnv*, jstring, jsize> GetStringUTFLength;
        // GetStringUTFChars
        public delegate* unmanaged<JNIEnv*, jstring, jboolean*, byte*> GetStringUTFChars;
        // ReleaseStringUTFChars
        public delegate* unmanaged<JNIEnv*, jstring, byte*, void> ReleaseStringUTFChars;

        // GetArrayLength
        public delegate* unmanaged<JNIEnv*, jarray, jsize> GetArrayLength;

        // NewObjectArray
        public delegate* unmanaged<JNIEnv*, jsize, jclass, jobject, jobjectArray> NewObjectArray;
        // GetObjectArrayElement
        public delegate* unmanaged<JNIEnv*, jobjectArray, jsize, jobject> GetObjectArrayElement;
        // SetObjectArrayElement
        public delegate* unmanaged<JNIEnv*, jobjectArray, jsize, jobject, void> SetObjectArrayElement;

        // NewBooleanArray
        public delegate* unmanaged<JNIEnv*, jsize, jbooleanArray> NewBooleanArray;
        // NewByteArray
        public delegate* unmanaged<JNIEnv*, jsize, jbyteArray> NewByteArray;
        // NewCharArray
        public delegate* unmanaged<JNIEnv*, jsize, jcharArray> NewCharArray;
        // NewShortArray
        public delegate* unmanaged<JNIEnv*, jsize, jshortArray> NewShortArray;
        // NewIntArray
        public delegate* unmanaged<JNIEnv*, jsize, jintArray> NewIntArray;
        // NewLongArray
        public delegate* unmanaged<JNIEnv*, jsize, jlongArray> NewLongArray;
        // NewFloatArray
        public delegate* unmanaged<JNIEnv*, jsize, jfloatArray> NewFloatArray;
        // NewDoubleArray
        public delegate* unmanaged<JNIEnv*, jsize, jdoubleArray> NewDoubleArray;

        // GetBooleanArrayElements
        public delegate* unmanaged<JNIEnv*, jbooleanArray, jboolean*, jobject*> GetBooleanArrayElements;
        // GetByteArrayElements
        public delegate* unmanaged<JNIEnv*, jbyteArray, jboolean*, jbyte*> GetByteArrayElements;
        // GetCharArrayElements
        public delegate* unmanaged<JNIEnv*, jcharArray, jboolean*, jchar*> GetCharArrayElements;
        // GetShortArrayElements
        public delegate* unmanaged<JNIEnv*, jshortArray, jboolean*, jshort*> GetShortArrayElements;
        // GetIntArrayElements
        public delegate* unmanaged<JNIEnv*, jintArray, jboolean*, jint*> GetIntArrayElements;
        // GetLongArrayElements
        public delegate* unmanaged<JNIEnv*, jlongArray, jboolean*, jlong*> GetLongArrayElements;
        // GetFloatArrayElements
        public delegate* unmanaged<JNIEnv*, jfloatArray, jboolean*, jfloat*> GetFloatArrayElements;
        // GetDoubleArrayElements
        public delegate* unmanaged<JNIEnv*, jdoubleArray, jboolean*, jdouble*> GetDoubleArrayElements;

        // ReleaseBooleanArrayElements
        public delegate* unmanaged<JNIEnv*, jbooleanArray, jboolean*, jint> ReleaseBooleanArrayElements;
        // ReleaseByteArrayElements
        public delegate* unmanaged<JNIEnv*, jbyteArray, jbyte*, jint> ReleaseByteArrayElements;
        // ReleaseCharArrayElements
        public delegate* unmanaged<JNIEnv*, jcharArray, jchar*, jint> ReleaseCharArrayElements;
        // ReleaseShortArrayElements
        public delegate* unmanaged<JNIEnv*, jshortArray, jshort*, jint> ReleaseShortArrayElements;
        // ReleaseIntArrayElements
        public delegate* unmanaged<JNIEnv*, jintArray, jint*, jint> ReleaseIntArrayElements;
        // ReleaseLongArrayElements
        public delegate* unmanaged<JNIEnv*, jlongArray, jlong*, jint> ReleaseLongArrayElements;
        // ReleaseFloatArrayElements
        public delegate* unmanaged<JNIEnv*, jfloatArray, jfloat*, jint> ReleaseFloatArrayElements;
        // ReleaseDoubleArrayElements
        public delegate* unmanaged<JNIEnv*, jdoubleArray, jdouble*, jint> ReleaseDoubleArrayElements;

        // GetBooleanArrayRegion
        public delegate* unmanaged<JNIEnv*, jbooleanArray, jsize, jsize, jboolean*, void> GetBooleanArrayRegion;
        // GetByteArrayRegion
        public delegate* unmanaged<JNIEnv*, jbyteArray, jsize, jsize, jbyte*, void> GetByteArrayRegion;
        // GetCharArrayRegion
        public delegate* unmanaged<JNIEnv*, jcharArray, jsize, jsize, jchar*, void> GetCharArrayRegion;
        // GetShortArrayRegion
        public delegate* unmanaged<JNIEnv*, jshortArray, jsize, jsize, jshort*, void> GetShortArrayRegion;
        // GetIntArrayRegion
        public delegate* unmanaged<JNIEnv*, jintArray, jsize, jsize, jint*, void> GetIntArrayRegion;
        // GetLongArrayRegion
        public delegate* unmanaged<JNIEnv*, jlongArray, jsize, jsize, jlong*, void> GetLongArrayRegion;
        // GetFloatArrayRegion
        public delegate* unmanaged<JNIEnv*, jfloatArray, jsize, jsize, jfloat*, void> GetFloatArrayRegion;
        // GetDoubleArrayRegion
        public delegate* unmanaged<JNIEnv*, jdoubleArray, jsize, jsize, jdouble*, void> GetDoubleArrayRegion;

        // SetBooleanArrayRegion
        public delegate* unmanaged<JNIEnv*, jbooleanArray, jsize, jsize, jboolean*, void> SetBooleanArrayRegion;
        // SetByteArrayRegion
        public delegate* unmanaged<JNIEnv*, jbyteArray, jsize, jsize, jbyte*, void> SetByteArrayRegion;
        // SetCharArrayRegion
        public delegate* unmanaged<JNIEnv*, jcharArray, jsize, jsize, jchar*, void> SetCharArrayRegion;
        // SetShortArrayRegion
        public delegate* unmanaged<JNIEnv*, jshortArray, jsize, jsize, jshort*, void> SetShortArrayRegion;
        // SetIntArrayRegion
        public delegate* unmanaged<JNIEnv*, jintArray, jsize, jsize, jint*, void> SetIntArrayRegion;
        // SetLongArrayRegion
        public delegate* unmanaged<JNIEnv*, jlongArray, jsize, jsize, jlong*, void> SetLongArrayRegion;
        // SetFloatArrayRegion
        public delegate* unmanaged<JNIEnv*, jfloatArray, jsize, jsize, jfloat*, void> SetFloatArrayRegion;
        // SetDoubleArrayRegion
        public delegate* unmanaged<JNIEnv*, jdoubleArray, jsize, jsize, jdouble*, void> SetDoubleArrayRegion;

        // RegisterNatives
        public delegate* unmanaged<JNIEnv*, jclass, void*, jint, jint> RegisterNatives;
        // UnregisterNatives
        public delegate* unmanaged<JNIEnv*, jclass, jint> UnregisterNatives;

        // MonitorEnter
        public delegate* unmanaged<JNIEnv*, jobject, jint> MonitorEnter;
        // MonitorExit
        public delegate* unmanaged<JNIEnv*, jobject, jint> MonitorExit;

        // GetJavaVM
        public delegate* unmanaged<JNIEnv*, JavaVM**, jint> GetJavaVM;

        // GetStringRegion
        public delegate* unmanaged<JNIEnv*, jstring, jsize, jsize, jchar*, void> GetStringRegion;
        // GetStringUTFRegion
        public delegate* unmanaged<JNIEnv*, jstring, jsize, jsize, byte*, void> GetStringUTFRegion;

        // GetPrimitiveArrayCritical
        public delegate* unmanaged<JNIEnv*, jarray, jboolean*, void*> GetPrimitiveArrayCritical;
        // ReleasePrimitiveArrayCritical
        public delegate* unmanaged<JNIEnv*, jarray, void*, jint, void> ReleasePrimitiveArrayCritical;

        // GetStringCritical
        public delegate* unmanaged<JNIEnv*, jstring, jboolean*, jchar*> GetStringCritical;
        // ReleaseStringCritical
        public delegate* unmanaged<JNIEnv*, jstring, jchar*, void> ReleaseStringCritical;

        // NewWeakGlobalRef
        public delegate* unmanaged<JNIEnv*, jobject, jweak> NewWeakGlobalRef;
        // DeleteWeakGlobalRef
        public delegate* unmanaged<JNIEnv*, jweak, void> DeleteWeakGlobalRef;

        // ExceptionCheck
        public delegate* unmanaged<JNIEnv*, jboolean> ExceptionCheck;

        // NewDirectByteBuffer
        public delegate* unmanaged<JNIEnv*, void*, jlong, jobject> NewDirectByteBuffer;
        // GetDirectBufferAddress
        public delegate* unmanaged<JNIEnv*, jobject, void*> GetDirectBufferAddress;
        // GetDirectBufferCapacity
        public delegate* unmanaged<JNIEnv*, jobject, jlong> GetDirectBufferCapacity;

        /* New JNI 1.6 Features */

        // GetObjectRefType
        public delegate* unmanaged<JNIEnv*, jobject, jobjectRefType> GetObjectRefType;

        /* Module Features */

        // GetModule
        public delegate* unmanaged<JNIEnv*, jclass, jobject> GetModule;
    }
}
