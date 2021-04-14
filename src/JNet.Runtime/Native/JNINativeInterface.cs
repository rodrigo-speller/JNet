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

        public delegate* unmanaged<JNIEnv*, jint> GetVersion;

        public IntPtr DefineClass;

        public delegate* unmanaged<JNIEnv*, string, jclass> FindClass;

        public IntPtr FromReflectedMethod;
        public IntPtr FromReflectedField;

        public IntPtr ToReflectedMethod;

        public IntPtr GetSuperclass;
        public IntPtr IsAssignableFrom;

        public IntPtr ToReflectedField;

        public IntPtr Throw;
        public IntPtr ThrowNew;
        public IntPtr ExceptionOccurred;
        public IntPtr ExceptionDescribe;
        public IntPtr ExceptionClear;
        public IntPtr FatalError;

        public IntPtr PushLocalFrame;
        public IntPtr PopLocalFrame;

        public IntPtr NewGlobalRef;
        public IntPtr DeleteGlobalRef;
        public IntPtr DeleteLocalRef;
        public IntPtr IsSameObject;
        public IntPtr NewLocalRef;
        public IntPtr EnsureLocalCapacity;

        public IntPtr AllocObject;
        public IntPtr NewObject;
        public IntPtr NewObjectV;
        public IntPtr NewObjectA;

        public IntPtr GetObjectClass;
        public IntPtr IsInstanceOf;

        public delegate* unmanaged<JNIEnv*, jclass, string, string, jmethodID> GetMethodID;

        public IntPtr CallObjectMethod;
        public IntPtr CallObjectMethodV;
        public IntPtr CallObjectMethodA;

        public IntPtr CallBooleanMethod;
        public IntPtr CallBooleanMethodV;
        public IntPtr CallBooleanMethodA;

        public IntPtr CallByteMethod;
        public IntPtr CallByteMethodV;
        public IntPtr CallByteMethodA;

        public IntPtr CallCharMethod;
        public IntPtr CallCharMethodV;
        public IntPtr CallCharMethodA;

        public IntPtr CallShortMethod;
        public IntPtr CallShortMethodV;
        public IntPtr CallShortMethodA;

        public IntPtr CallIntMethod;
        public IntPtr CallIntMethodV;
        public IntPtr CallIntMethodA;

        public IntPtr CallLongMethod;
        public IntPtr CallLongMethodV;
        public IntPtr CallLongMethodA;

        public IntPtr CallFloatMethod;
        public IntPtr CallFloatMethodV;
        public IntPtr CallFloatMethodA;

        public IntPtr CallDoubleMethod;
        public IntPtr CallDoubleMethodV;
        public IntPtr CallDoubleMethodA;

        public delegate* unmanaged<JNIEnv*, jobject, jmethodID, void> CallVoidMethod;
        public IntPtr CallVoidMethodV;
        public delegate* unmanaged<JNIEnv*, jobject, jmethodID, jvalue[], void> CallVoidMethodA;

        public IntPtr CallNonvirtualObjectMethod;
        public IntPtr CallNonvirtualObjectMethodV;
        public IntPtr CallNonvirtualObjectMethodA;

        public IntPtr CallNonvirtualBooleanMethod;
        public IntPtr CallNonvirtualBooleanMethodV;
        public IntPtr CallNonvirtualBooleanMethodA;

        public IntPtr CallNonvirtualByteMethod;
        public IntPtr CallNonvirtualByteMethodV;
        public IntPtr CallNonvirtualByteMethodA;

        public IntPtr CallNonvirtualCharMethod;
        public IntPtr CallNonvirtualCharMethodV;
        public IntPtr CallNonvirtualCharMethodA;

        public IntPtr CallNonvirtualShortMethod;
        public IntPtr CallNonvirtualShortMethodV;
        public IntPtr CallNonvirtualShortMethodA;

        public IntPtr CallNonvirtualIntMethod;
        public IntPtr CallNonvirtualIntMethodV;
        public IntPtr CallNonvirtualIntMethodA;

        public IntPtr CallNonvirtualLongMethod;
        public IntPtr CallNonvirtualLongMethodV;
        public IntPtr CallNonvirtualLongMethodA;

        public IntPtr CallNonvirtualFloatMethod;
        public IntPtr CallNonvirtualFloatMethodV;
        public IntPtr CallNonvirtualFloatMethodA;

        public IntPtr CallNonvirtualDoubleMethod;
        public IntPtr CallNonvirtualDoubleMethodV;
        public IntPtr CallNonvirtualDoubleMethodA;

        public IntPtr CallNonvirtualVoidMethod;
        public IntPtr CallNonvirtualVoidMethodV;
        public IntPtr CallNonvirtualVoidMethodA;

        public delegate* unmanaged<JNIEnv*, jclass, string, string, jfieldID> GetFieldID;

        public IntPtr GetObjectField;
        public IntPtr GetBooleanField;
        public IntPtr GetByteField;
        public IntPtr GetCharField;
        public IntPtr GetShortField;
        public IntPtr GetIntField;
        public IntPtr GetLongField;
        public IntPtr GetFloatField;
        public IntPtr GetDoubleField;

        public IntPtr SetObjectField;
        public IntPtr SetBooleanField;
        public IntPtr SetByteField;
        public IntPtr SetCharField;
        public IntPtr SetShortField;
        public IntPtr SetIntField;
        public IntPtr SetLongField;
        public IntPtr SetFloatField;
        public IntPtr SetDoubleField;

        public delegate* unmanaged<JNIEnv*, jclass, string, string, jmethodID> GetStaticMethodID;

        public delegate* unmanaged<JNIEnv*, jclass, jmethodID, jobject> CallStaticObjectMethod;
        public IntPtr CallStaticObjectMethodV;
        public delegate* unmanaged<JNIEnv*, jclass, jmethodID, jvalue[], jobject> CallStaticObjectMethodA;

        public IntPtr CallStaticBooleanMethod;
        public IntPtr CallStaticBooleanMethodV;
        public IntPtr CallStaticBooleanMethodA;

        public IntPtr CallStaticByteMethod;
        public IntPtr CallStaticByteMethodV;
        public IntPtr CallStaticByteMethodA;

        public IntPtr CallStaticCharMethod;
        public IntPtr CallStaticCharMethodV;
        public IntPtr CallStaticCharMethodA;

        public IntPtr CallStaticShortMethod;
        public IntPtr CallStaticShortMethodV;
        public IntPtr CallStaticShortMethodA;

        public IntPtr CallStaticIntMethod;
        public IntPtr CallStaticIntMethodV;
        public IntPtr CallStaticIntMethodA;

        public IntPtr CallStaticLongMethod;
        public IntPtr CallStaticLongMethodV;
        public IntPtr CallStaticLongMethodA;

        public IntPtr CallStaticFloatMethod;
        public IntPtr CallStaticFloatMethodV;
        public IntPtr CallStaticFloatMethodA;

        public IntPtr CallStaticDoubleMethod;
        public IntPtr CallStaticDoubleMethodV;
        public IntPtr CallStaticDoubleMethodA;

        public delegate* unmanaged<JNIEnv*, jclass, jmethodID, void> CallStaticVoidMethod;
        public IntPtr CallStaticVoidMethodV;
        public delegate* unmanaged<JNIEnv*, jclass, jmethodID, jvalue[], void> CallStaticVoidMethodA;

        public delegate* unmanaged<JNIEnv*, jclass, string, string, jfieldID> GetStaticFieldID;
        public delegate* unmanaged<JNIEnv*, jclass, jfieldID, jobject> GetStaticObjectField;
        public IntPtr GetStaticBooleanField;
        public IntPtr GetStaticByteField;
        public IntPtr GetStaticCharField;
        public IntPtr GetStaticShortField;
        public IntPtr GetStaticIntField;
        public IntPtr GetStaticLongField;
        public IntPtr GetStaticFloatField;
        public IntPtr GetStaticDoubleField;

        public IntPtr SetStaticObjectField;
        public IntPtr SetStaticBooleanField;
        public IntPtr SetStaticByteField;
        public IntPtr SetStaticCharField;
        public IntPtr SetStaticShortField;
        public IntPtr SetStaticIntField;
        public IntPtr SetStaticLongField;
        public IntPtr SetStaticFloatField;
        public IntPtr SetStaticDoubleField;

        public delegate* unmanaged<JNIEnv*, jchar*, jsize, jstring> NewString;
        public delegate* unmanaged<JNIEnv*, jstring, jsize> GetStringLength;
        public delegate* unmanaged<JNIEnv*, jstring, jboolean*, jchar*> GetStringChars;
        public delegate* unmanaged<JNIEnv*, jstring, jchar*, void> ReleaseStringChars;

        public delegate* unmanaged<JNIEnv*, byte*, jstring> NewStringUTF;
        public delegate* unmanaged<JNIEnv*, jstring, jsize> GetStringUTFLength;
        public delegate* unmanaged<JNIEnv*, jstring, jboolean*, byte*> GetStringUTFChars;
        public delegate* unmanaged<JNIEnv*, jstring, byte*, void> ReleaseStringUTFChars;

        public IntPtr GetArrayLength;

        public IntPtr NewObjectArray;
        public IntPtr GetObjectArrayElement;
        public IntPtr SetObjectArrayElement;

        public IntPtr NewBooleanArray;
        public IntPtr NewByteArray;
        public IntPtr NewCharArray;
        public IntPtr NewShortArray;
        public IntPtr NewIntArray;
        public IntPtr NewLongArray;
        public IntPtr NewFloatArray;
        public IntPtr NewDoubleArray;

        public IntPtr GetBooleanArrayElements;
        public IntPtr GetByteArrayElements;
        public IntPtr GetCharArrayElements;
        public IntPtr GetShortArrayElements;
        public IntPtr GetIntArrayElements;
        public IntPtr GetLongArrayElements;
        public IntPtr GetFloatArrayElements;
        public IntPtr GetDoubleArrayElements;

        public IntPtr ReleaseBooleanArrayElements;
        public IntPtr ReleaseByteArrayElements;
        public IntPtr ReleaseCharArrayElements;
        public IntPtr ReleaseShortArrayElements;
        public IntPtr ReleaseIntArrayElements;
        public IntPtr ReleaseLongArrayElements;
        public IntPtr ReleaseFloatArrayElements;
        public IntPtr ReleaseDoubleArrayElements;

        public IntPtr GetBooleanArrayRegion;
        public IntPtr GetByteArrayRegion;
        public IntPtr GetCharArrayRegion;
        public IntPtr GetShortArrayRegion;
        public IntPtr GetIntArrayRegion;
        public IntPtr GetLongArrayRegion;
        public IntPtr GetFloatArrayRegion;
        public IntPtr GetDoubleArrayRegion;

        public IntPtr SetBooleanArrayRegion;
        public IntPtr SetByteArrayRegion;
        public IntPtr SetCharArrayRegion;
        public IntPtr SetShortArrayRegion;
        public IntPtr SetIntArrayRegion;
        public IntPtr SetLongArrayRegion;
        public IntPtr SetFloatArrayRegion;
        public IntPtr SetDoubleArrayRegion;

        public delegate* unmanaged<JNIEnv*, jclass, void*, jint, jint> RegisterNatives;
        public delegate* unmanaged<JNIEnv*, jclass, jint> UnregisterNatives;

        public IntPtr MonitorEnter;
        public IntPtr MonitorExit;

        public IntPtr GetJavaVM;

        public IntPtr GetStringRegion;
        public IntPtr GetStringUTFRegion;

        public IntPtr GetPrimitiveArrayCritical;
        public IntPtr ReleasePrimitiveArrayCritical;

        public IntPtr GetStringCritical;
        public IntPtr ReleaseStringCritical;

        public IntPtr NewWeakGlobalRef;
        public IntPtr DeleteWeakGlobalRef;

        public IntPtr ExceptionCheck;

        public IntPtr NewDirectByteBuffer;
        public IntPtr GetDirectBufferAddress;
        public IntPtr GetDirectBufferCapacity;

        /* New JNI 1.6 Features */

        public IntPtr GetObjectRefType;

        /* Module Features */

        public IntPtr GetModule;
    }
}
