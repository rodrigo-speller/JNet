// Copyright (c) Rodrigo Speller. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.

using Xunit;

namespace JNet.Runtime.Test
{
    /// <summary>
    /// This fixture initializes the <see cref="JNetVirtualMachine" /> instance.
    /// </summary>
    public class JNetRuntimeFixture
    {
        public const string CollectionName = "VirtualMachineCollectionFixture";

        [CollectionDefinition(CollectionName)]
        public class CollectionFixture : ICollectionFixture<JNetRuntimeFixture>
        { }

        /// <summary>
        /// The virtual machine instance.
        /// </summary>
        public readonly JNetVirtualMachine VirtualMachine;

        public JNetRuntimeFixture()
        {
            VirtualMachine = JNetVirtualMachine.Initialize(new JNetConfiguration()
            {
                EnableDiagnostics = true
            });
        }
    }
}
