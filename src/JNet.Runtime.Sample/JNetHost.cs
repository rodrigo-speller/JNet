// Copyright (c) Rodrigo Speller. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.

using JNet.Runtime.Sample.Utils;

namespace JNet.Runtime.Sample
{
    internal static class JNetHost
    {
        private static ObjectPool<JNetRunner> runnersPool;

        public static void Initialize(JNetConfiguration configuration = null)
        {
            var vm = JNetVirtualMachine.Initialize(configuration);

            runnersPool = JNetRunner.CreatePool(vm);
        }

        public static void Run(JNetRunnable runnable)
        {
            var runner = runnersPool.Get();
            try
            {
                runner.Run(runnable);
            }
            finally
            {
                if (runner.CanReuse)
                    runnersPool.Return(runner);
            }
        }

        public static T Run<T>(JNetRunnable<T> runnable)
        {
            T result = default;

            Run(runtime =>
            {
                result = runnable(runtime);
            });

            return result;
        }
    }
}
