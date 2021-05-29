// Copyright (c) Rodrigo Speller. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.

namespace JNet.Runtime
{
    public interface IJNetBootstrap
    {
        void Startup(JNetVirtualMachine vm, JNetRuntime runtime);
    }
}
