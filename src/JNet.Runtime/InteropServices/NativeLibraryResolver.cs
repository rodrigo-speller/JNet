// Copyright (c) Rodrigo Speller. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;

namespace JNet.Runtime.InteropServices
{
    internal static class NativeLibraryResolver
    {
        private static readonly Dictionary<string, DllImportResolver> resolvers = new();

        static NativeLibraryResolver()
        {
            NativeLibrary.SetDllImportResolver(typeof(NativeLibraryResolver).Assembly, DllImportResolver);
        }

        public static void SetResolver(string libraryName, Func<IntPtr> resolver)
        {
            if (libraryName is null)
                throw new ArgumentNullException(nameof(libraryName));

            if (resolver is null)
                throw new ArgumentNullException(nameof(resolver));

            lock (resolvers)
            {
                resolvers[libraryName] = (_, _, _) => resolver();
            }
        }

        public static void SetResolver(string libraryName, DllImportResolver resolver)
        {
            if (libraryName is null)
                throw new ArgumentNullException(nameof(libraryName));

            if (resolver is null)
                throw new ArgumentNullException(nameof(resolver));

            lock (resolvers)
            {
                resolvers[libraryName] = resolver;
            }
        }

        private static IntPtr DllImportResolver(string libraryName, Assembly assembly, DllImportSearchPath? searchPath)
        {
            DllImportResolver resolver;

            lock (resolvers)
            {
                resolver = resolvers.GetValueOrDefault(libraryName);
            }

            if (resolver != null)
                return resolver(libraryName, assembly, searchPath);

            return IntPtr.Zero;
        }
    }
}
