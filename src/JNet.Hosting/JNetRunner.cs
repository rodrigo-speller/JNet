// Copyright (c) Rodrigo Speller. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.

using System;
using System.Threading;
using JNet.Hosting.Utils;
using JNet.Runtime;

namespace JNet.Hosting
{
    internal class JNetRunner
    {
        private const int DefaultLocalFrameCapacity = 16;

        private readonly JNetVirtualMachine vm;

        private readonly Thread thread;
        private readonly EventWaitHandle threadWait = new(false, EventResetMode.ManualReset);
        private readonly CancellationTokenSource threadCancellation = new();

        private readonly ValueAwaiter<JNetCancellableRunnable> taskAwaiter = new();
        private readonly ValueAwaiter<Action> resultAwaiter = new();

        public bool CanReuse { get; private set; } = true;

        private JNetRunner(JNetVirtualMachine vm)
        {
            var thread = new Thread(Daemon);
            this.vm = vm;
            this.thread = thread;
        }

        private void Daemon()
        {
            var runtime = vm.AttachCurrentThreadAsDaemon();
            var cancellationToken = this.threadCancellation.Token;

            try
            {
                while (true)
                {
                    var runnable = taskAwaiter.WaitAndReset(cancellationToken);

                    var rc = runtime.PushLocalFrame(DefaultLocalFrameCapacity);
                    JNIResultException.Check(rc);

                    Action result;
                    try
                    {
                        runnable(runtime, cancellationToken);
                        result = SuccessResult;
                    }
                    catch (Exception e)
                    {
                        result = ExceptionResult(e);
                    }

                    runtime.PopLocalFrame(default);

                    resultAwaiter.Set(result);
                }
            }
            catch (OperationCanceledException e) when (e.CancellationToken == cancellationToken)
            {
                CanReuse = false;
            }
            catch (Exception e)
            {
                CanReuse = false;
                resultAwaiter.Set(ExceptionResult(e));
                throw;
            }
            finally
            {
                vm.DetachCurrentThread();
                threadWait.Set();
            }
        }

        public void Run(JNetCancellableRunnable runnable)
        {
            taskAwaiter.Set(runnable);

            var result = resultAwaiter.WaitAndReset();

            result();
        }

        private static void SuccessResult() { }

        private static Action ExceptionResult(Exception ex)
            => () => throw new AggregateException(ex);

        public static ObjectPoolSlim<JNetRunner> CreatePool()
        {
            return new ObjectPoolSlim<JNetRunner>(() => {
                var runner = new JNetRunner(JNetHost.VirtualMachine);
                runner.thread.Start();
                return runner;
            });
        }

        public void Stop()
        {
            threadCancellation.Cancel();
            threadWait.WaitOne();
        }
    }
}
