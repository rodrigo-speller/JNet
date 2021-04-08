// Copyright (c) Rodrigo Speller. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using JNet.Runtime.InteropServices;

namespace JNet.Runtime
{
    public unsafe class JNetRuntime
    {
        private readonly JNIEnv *env;
        private readonly JNIRuntimeInterface runtime;

        private JNetRuntime(JavaVM *vm, JNIEnv *env)
        {
            this.env = env;
            this.runtime = new JNIRuntimeInterface(env);
        }

        public static JNetRuntime Create(params string[] optionStrings)
            => Create((IEnumerable<string>)optionStrings);

        public static JNetRuntime Create(IEnumerable<string> optionStrings)
        {
            if (optionStrings is null)
                optionStrings = Array.Empty<string>();

            var options = optionStrings.Select(opt => new JavaVMOption(opt));

            JavaVMInitArgs vm_args = new JavaVMInitArgs();
            vm_args.version = (int)JNIVersion.Version10;
            vm_args.SetOptions(options.ToArray());
            vm_args.ignoreUnrecognized = true; // invalid options make the JVM init fail

            var p_vmArgs = Marshal.AllocCoTaskMem(Marshal.SizeOf<JavaVMInitArgs>());
            Marshal.StructureToPtr(vm_args, p_vmArgs, false);

            JavaVM *vm;
            JNIEnv *env;

            var ret = JVMLib.JNI_CreateJavaVM(&vm, (void**)&env, (void*)p_vmArgs);

            vm_args.ReleaseOptions();
            Marshal.FreeCoTaskMem(p_vmArgs);

            JNIResultException.Check(ret);

            return new JNetRuntime(vm, env);
        }

        public jint GetVersion()
            => runtime.GetVersion()(env);

        public jclass FindClass(string name)
            => runtime.FindClass()(env, name);

        public jmethodID GetStaticMethodID(jclass clazz, string name, string sig)
            => runtime.GetStaticMethodID()(env, clazz, name, sig);

        public jobject CallStaticObjectMethod(jclass clazz, jmethodID methodID)
            => runtime.CallStaticObjectMethod()(env, clazz, methodID);
        public jobject CallStaticObjectMethod(jclass clazz, jmethodID methodID, params jvalue[] args)
            => runtime.CallStaticObjectMethodA()(env, clazz, methodID, args);

        public jstring NewString(jchar *unicode, jsize len)
            => runtime.NewString()(env, unicode, len);
        public jsize GetStringLength(jstring str)
            => runtime.GetStringLength()(env, str);
        public jchar *GetStringChars(jstring str, jboolean *isCopy)
            => runtime.GetStringChars()(env, str, isCopy);
        public void ReleaseStringChars(jstring str, jchar *chars)
            => runtime.ReleaseStringChars()(env, str, chars);

        public jstring NewStringUTF(byte *utf)
            => runtime.NewStringUTF()(env, utf);
        public jsize GetStringUTFLength(jstring str)
            => runtime.GetStringUTFLength()(env, str);
        public byte *GetStringUTFChars(jstring str, jboolean *isCopy)
            => runtime.GetStringUTFChars()(env, str, isCopy);
        public void ReleaseStringUTFChars(jstring str, byte *utf)
            => runtime.ReleaseStringUTFChars()(env, str, utf);
    }
}
