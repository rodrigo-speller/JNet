// Copyright (c) Rodrigo Speller. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.

using System;

namespace JNet.Runtime.Sample
{
    using java.lang;

    unsafe class Program
    {
        static void Main(string[] args)
        {
            var javaVersion = System.getProperty("java.version");

            Console.WriteLine($"Java version: {javaVersion}");
        }
    }
}
