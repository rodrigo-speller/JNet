// Copyright (c) Rodrigo Speller. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.

using System;
using JNet.Runtime.Sample.Utils;

namespace JNet.Runtime.Sample
{
    internal static class JNetHost
    {
        private static JNetVirtualMachine vm;
        private static readonly ObjectPool<TaskExecutor> executorsPool = new ObjectPool<TaskExecutor>(CreateTaskExecutor);

        public static void Initialize(JNetConfiguration configuration = null)
        {
            var vm = JNetVirtualMachine.Initialize(configuration);

            JNetHost.vm = vm;
        }

        public static void Run(Action<JNetRuntime> task)
        {
            var executor = executorsPool.Get();
            try
            {
                executor.Run(task);
            }
            finally
            {
                executorsPool.Return(executor);
            }
        }

        public static T Run<T>(Func<JNetRuntime, T> task)
        {
            T result = default;

            Run(runtime =>
            {
                result = task(runtime);
            });

            return result;
        }

        private static TaskExecutor CreateTaskExecutor()
        {
            var vm = JNetHost.vm
                ?? throw new InvalidOperationException($"{nameof(JNetHost)} is not initialized.");

            return new TaskExecutor(vm);
        }
    }
}
