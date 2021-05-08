// Copyright (c) Rodrigo Speller. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.

using JNet.Runtime.InteropServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

namespace JNet.Runtime
{
    public class JNetConfiguration
    {
        public string JavaRuntimePath { get; set; }
        public IEnumerable<string> Classpath { get; set; }
        public IJNetBootstrap Bootstrap { get; set; }
        public JNIVersion JNIVersion { get; set; } = JNIVersion.Version10;
        public bool EnableDiagnostics { get; set; }
        public Logger LoggerCallback { get; set; }

        public delegate void Logger(string format, IntPtr args);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int vfprintf_Contract(
            IntPtr stream,
            [In][MarshalAs(UnmanagedType.LPStr)] string format,
            IntPtr args
        );

        internal unsafe IEnumerable<JavaVMOption> BuildOptions()
        {
            var options = new List<JavaVMOption>();

            if (Classpath is not null)
            {
                var classpath = string.Join(Path.PathSeparator, Classpath);
                options.Add(new JavaVMOption($"-Djava.class.path={classpath}"));
            }

            var logger = LoggerCallback;
            if (logger is not null)
            {
                options.Add(new JavaVMOption("vfprintf")
                {
                    extraInfo = Marshal.GetFunctionPointerForDelegate<vfprintf_Contract>((stream, format, args) => {
                        logger(format, args);
                        return 0;
                    }).ToPointer()
                });
            }

            if (EnableDiagnostics)
                options.Add(new JavaVMOption("-Xcheck:jni"));

            return options.AsEnumerable();
        }
    }
}
