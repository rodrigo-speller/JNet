// Copyright (c) Rodrigo Speller. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.

using System;
using Xunit;

namespace JNet.Runtime.Test
{
    [Collection(JNetRuntimeFixture.CollectionName)]
    public abstract class JNetRuntimeTestBase : IDisposable
    {
        private readonly JNetVirtualMachine VirtualMachine;
        protected readonly JNetRuntime Runtime;

        private bool disposed;

        public JNetRuntimeTestBase(JNetRuntimeFixture runtime)
        {
            VirtualMachine = runtime.VirtualMachine;
            Runtime = runtime.VirtualMachine.AttachCurrentThread();
        }

        public void Dispose()
        {
            if (!disposed)
            {
                VirtualMachine.DetachCurrentThread();
                disposed = true;
            }

            GC.SuppressFinalize(this);
        }
    }
}
