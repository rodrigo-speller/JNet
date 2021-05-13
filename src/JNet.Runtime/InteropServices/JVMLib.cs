// Copyright (c) Rodrigo Speller. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.

using System;
using System.IO;
using System.Runtime.InteropServices;

namespace JNet.Runtime.InteropServices
{
    internal unsafe partial class JVMLib
    {
        /// <summary>
        /// Dynamic JVM native library name.
        /// </summary>
        public const string JVMLibName = "jvm";

        internal static void Load(JNetConfiguration configuration)
        {
            var javahome = configuration.JavaRuntimePath
                ?? Environment.GetEnvironmentVariable("JAVA_HOME")
                ?? throw new InvalidOperationException("Java Runtime path not found.")
                ;

            /* Checks the OS platform an sets the native library resolver
             * to resolve the 'jvm' library.
             * 
             * If no supported platform is detected, it does not define any
             * resolver and the default DllImportResolver is used.
             */

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                NativeLibraryResolver.SetResolver(
                    JVMLibName,
                    () => LoadJVMLib(javahome, @"bin\server\jvm.dll")
                );
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                NativeLibraryResolver.SetResolver(
                    JVMLibName,
                    () => LoadJVMLib(javahome, @"lib/server/libjvm.so")
                );
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                NativeLibraryResolver.SetResolver(
                    JVMLibName,
                    () => LoadJVMLib(javahome, @"lib/server/libjvm.dylib")
                );
            }
        }

        private static IntPtr LoadJVMLib(string javahome, string relativelib)
        {
            var lib = Path.Combine(javahome, relativelib);
            if (!File.Exists(lib))
            {
                lib = Path.Combine(javahome, "jre", relativelib);

                if (!File.Exists(lib))
                    throw new InvalidOperationException("Java Runtime path not found.");
            }

            return NativeLibrary.Load(lib);
        }

        /// <summary>
        /// Returns all Java VMs that have been created. Pointers to VMs are written in the buffer vmBuf in the order
        /// they are created. At most bufLen number of entries will be written. The total number of created VMs is
        /// returned in *nVMs.
        /// </summary>
        /// <param name="vm_args">
        /// A pointer to a <see cref="JavaVMInitArgs" /> structure in to which the default arguments are filled,
        /// must not be NULL.
        /// </param>
        /// <returns>
        /// Returns <see cref="JNIReturnCode.OK" /> if the requested version is supported;
        /// returns a JNI error code (a negative number) if the requested version is not supported.
        /// </returns>
        [DllImport(JVMLibName, CallingConvention = CallingConvention.Winapi)]
        public static extern jint JNI_GetDefaultJavaVMInitArgs(void* vm_args);

        /// <summary>
        /// Loads and initializes a Java VM. The current thread becomes the main thread. Sets the env argument to the
        /// JNI interface pointer of the main thread.
        /// <br />
        /// Creation of multiple VMs in a single process is not supported.
        /// <br />
        /// The second argument to <see cref="JNI_CreateJavaVM" /> is always a pointer to <see cref="JNIEnv" />*,
        /// while the third argument is a pointer to a <see cref="JavaVMInitArgs" /> structure which uses option strings
        /// to encode arbitrary VM start up options.
        /// </summary>
        /// <param name="p_vm">
        /// Pointer to the location where the resulting VM structure will be placed, must not be <i>null</i>.
        /// </param>
        /// <param name="p_env">
        /// Pointer to the location where the JNI interface pointer for the main thread will be placed, must not be
        /// <i>null</i>.
        /// </param>
        /// <param name="vm_args">Java VM initialization arguments, must not be <i>null</i>.</param>
        /// <returns>Returns <see cref="JNIReturnCode.OK" /> on success; returns a suitable JNI error code
        /// (a negative number) on failure.
        /// </returns>
        [DllImport(JVMLibName, CallingConvention = CallingConvention.Winapi)]
        public static extern jint JNI_CreateJavaVM(JavaVM** p_vm, void** p_env, void* vm_args);

        /// <summary>
        /// Returns all Java VMs that have been created. Pointers to VMs are written in the buffer <i>vmBuf</i> in the
        /// order they are created. At most <i>bufLen</i> number of entries will be written. The total number of created
        /// VMs is returned in <i>*nVMs</i>.
        /// <br />
        /// Creation of multiple VMs in a single process is not supported.
        /// </summary>
        /// <param name="vmBuf">Pointer to the buffer where the VM structures will be placed, must not be <i>null</i>.</param>
        /// <param name="bufLen">The length of the buffer.</param>
        /// <param name="nVMs">A pointer to an integer. May be a <i>null</i> value.</param>
        /// <returns></returns>
        [DllImport(JVMLibName, CallingConvention = CallingConvention.Winapi)]
        public static extern jint JNI_GetCreatedJavaVMs(JavaVM** vmBuf, jsize bufLen, jsize* nVMs);
    }
}
