// Copyright (c) Rodrigo Speller. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.

using System;

namespace JNet.Runtime
{
    internal class DefaultBootstrap : IJNetBootstrap
    {
        private Action<JNetRuntime> _startup;

        public static IJNetBootstrap GetBootstrap(JNetRuntime runtime)
        {
            var clz_Bootstrap = runtime.FindClass("jnet/runtime/JNetBootstrap");

            if (!clz_Bootstrap.HasValue)
                return null;

            var mid_GetBootstrap = runtime.GetStaticMethodID(clz_Bootstrap, "getBootstrap", "()Ljnet/runtime/JNetBootstrap;");
            var mid_GetVersion = runtime.GetMethodID(clz_Bootstrap, "getVersion", "()I");
            var mid_Startup = runtime.GetMethodID(clz_Bootstrap, "startup", "()V");

            if (!mid_GetBootstrap.HasValue || !mid_GetVersion.HasValue || !mid_Startup.HasValue)
                return null;

            runtime.ExceptionClear();
            var bootstrap = runtime.CallStaticObjectMethod(clz_Bootstrap, mid_GetBootstrap);
            runtime.CheckException();

            if (!bootstrap.HasValue)
                return null;

            return new DefaultBootstrap()
            {
                _startup = (runtime) =>
                {
                    runtime.ExceptionClear();
                    runtime.CallVoidMethod(bootstrap, mid_Startup);
                    runtime.CheckException();
                }
            };
        }

        public void Startup(JNetRuntime runtime)
            => _startup(runtime);
    }
}
