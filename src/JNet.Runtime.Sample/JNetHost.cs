// Copyright (c) Rodrigo Speller. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.

using System;
using JNet.Runtime.Sample.Utils;

namespace JNet.Runtime.Sample
{
    internal static class JNetHost
    {
        private static readonly object lockObj = new();
        private static readonly CounterEventSlim lockPendingRunners = new();
        private static ObjectPoolSlim<JNetRunner> runnersPool = JNetRunner.CreatePool();

        public static bool IsActive { get; private set; }
        public static JNetVirtualMachine VirtualMachine { get; private set; }

        public static void Initialize(JNetConfiguration configuration = null)
        {
            lock (lockObj)
            {
                // initialize the virtual machine
                var vm = JNetVirtualMachine.Initialize(configuration);

                // set the virtual machine
                VirtualMachine = vm;

                // activate the host
                IsActive = true;
            }
        }

        public static void Destroy()
        {
            lock (lockObj)
            {
                if (!IsActive)
                    return;

                // deactivate the host
                IsActive = false;

                // await all pending runners
                lockPendingRunners.WaitOne();

                // stop all available runners
                while (runnersPool.TryGet(out var runner))
                    runner.Stop();

                // destroy the virtual machine
                VirtualMachine.Destroy();
            }
        }

        public static void Run(JNetRunnable runnable)
            => Run((runtime, _) => runnable(runtime));

        public static void Run(JNetCancellableRunnable runnable)
        {
            lock (lockObj)
            {
                if (!IsActive)
                    throw new InvalidOperationException();

                lockPendingRunners.Increment();
            }

            var pool = runnersPool;
            var runner = pool.Get();

            try
            {
                runner.Run(runnable);
            }
            finally
            {
                if (runner.CanReuse)
                    pool.Return(runner);

                lockPendingRunners.Decrement();
            }
        }

        public static T Run<T>(JNetRunnable<T> runnable)
            => Run((runtime, _) => runnable(runtime));

        public static T Run<T>(JNetCancellableRunnable<T> runnable)
        {
            T result = default;

            Run((runtime, cancellationToken) =>
            {
                result = runnable(runtime, cancellationToken);
            });

            return result;
        }
    }
}
