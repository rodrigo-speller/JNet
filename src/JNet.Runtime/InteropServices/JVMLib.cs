// Copyright (c) Rodrigo Speller. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.

using System;
using System.IO;
using System.Runtime.InteropServices;

namespace JNet.Runtime.InteropServices
{
    internal partial class JVMLib
    {
        internal static IJVMLib Load(JNetConfiguration configuration)
        {
            var path = configuration.JavaRuntimePath
                ?? Environment.GetEnvironmentVariable("JAVA_HOME")
                ?? throw new InvalidOperationException("Java Runtime path not found.")
                ;

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return Windows.Load(path);

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return Linux.Load(path);

            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return OSX.Load(path);

            throw new PlatformNotSupportedException();
        }
    }
}
