// Copyright (c) Rodrigo Speller. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.

namespace JNet.Runtime.Sample
{
    using java.lang;
    using JNet.Hosting;

    class Program
    {
        static void Main(string[] args)
        {
            JNetHost.Initialize();

            var javaVersion = System.GetProperty("java.version");

            System.Out.Println($"Java version: {javaVersion}");

            JNetHost.Destroy();
        }
    }
}
