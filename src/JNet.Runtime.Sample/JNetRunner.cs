// Copyright (c) Rodrigo Speller. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.

using System;
using System.Threading;
using JNet.Runtime.Sample.Utils;

namespace JNet.Runtime.Sample
{
    internal class JNetRunner
    {
        private const int DefaultLocalFrameCapacity = 16;

        private readonly JNetVirtualMachine vm;
        private readonly Thread thread;

        private readonly ValueAwaiter<JNetRunnable> taskAwaiter = new();
        private readonly ValueAwaiter<Action> resultAwaiter = new();

        public bool CanReuse { get; private set; } = true;

        private JNetRunner(JNetVirtualMachine vm)
        {
            var thread = new Thread(Daemon);

            thread.Start();

            this.vm = vm;
            this.thread = thread;
        }

        private void Daemon()
        {
            var runtime = vm.AttachCurrentThreadAsDaemon();

            try
            {
                while (true)
                {
                    var runnable = taskAwaiter.WaitAndReset();

                    var rc = runtime.PushLocalFrame(DefaultLocalFrameCapacity);
                    JNIResultException.Check(rc);

                    Action result;
                    try
                    {
                        runnable(runtime);
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
            catch (Exception e)
            {
                CanReuse = false;
                resultAwaiter.Set(ExceptionResult(e));
                throw;
            }
            finally
            {
                vm.DetachCurrentThread();
            }
        }

        public void Run(JNetRunnable runnable)
        {
            taskAwaiter.Set(runnable);

            var result = resultAwaiter.WaitAndReset();

            result();
        }

        private static void SuccessResult() { }

        private static Action ExceptionResult(Exception ex)
            => () => throw new AggregateException(ex);

        public static ObjectPool<JNetRunner> CreatePool(JNetVirtualMachine vm)
        {
            if (vm is null)
                throw new ArgumentNullException(nameof(vm));

            return new ObjectPool<JNetRunner>(() => new JNetRunner(vm));
        }
    }
}
