// Copyright (c) Rodrigo Speller. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.

using JNet.Runtime.InteropServices;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace JNet.Runtime
{
    public class JNetConfiguration
    {
        public string JavaRuntimePath { get; set; }
        public IEnumerable<string> Classpath { get; set; }
        public IJNetBootstrap Bootstrap { get; set; }

        internal IEnumerable<JavaVMOption> BuildOptions()
        {
            var options = new List<JavaVMOption>();

            if (Classpath is not null)
            {
                var classpath = string.Join(Path.PathSeparator, Classpath);
                options.Add(new JavaVMOption($"-Djava.class.path={classpath}"));
            }

            return options.AsEnumerable();
        }
    }
}
