// Copyright (c) Rodrigo Speller. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.

using System;
using System.Threading;

namespace JNet.Runtime.Sample
{
    internal class TaskExecutor
    {
        private readonly Thread thread;
        private readonly ManualResetEventSlim daemonSync = new ManualResetEventSlim(false);
        private readonly ManualResetEventSlim taskSync = new ManualResetEventSlim(false);

        private Action<JNetRuntime> currentTask;
        private Exception lastException;

        public TaskExecutor()
        {
            var thread = new Thread(Daemon);

            thread.Start();

            this.thread = thread;
        }

        private void Daemon()
        {
            var vm = JNetVirtualMachine.CurrentInstance;
            var rt = vm.AttachCurrentThreadAsDaemon();

            while (true)
            {
                daemonSync.Wait();

                try
                {
                    currentTask(rt);
                }
                catch (Exception e)
                {
                    lastException = e;
                }
                finally
                {
                    daemonSync.Reset();
                    taskSync.Set();
                }
            }

            vm.DetachCurrentThread();
        }

        public void Run(Action<JNetRuntime> task)
        {
            taskSync.Reset();

            currentTask = task;
            lastException = null;

            daemonSync.Set();
            taskSync.Wait();

            if (lastException is not null)
            {
                throw new AggregateException(lastException);
            }

        }
    }
}
