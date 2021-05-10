// Copyright (c) Rodrigo Speller. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.

using System;
using System.Threading;
using JNet.Runtime.Sample.Utils;

namespace JNet.Runtime.Sample
{
    internal class TaskExecutor
    {
        private const int DefaultLocalFrameCapacity = 16;

        private readonly JNetVirtualMachine vm;
        private readonly Thread thread;

        private readonly ValueAwaiter<Action<JNetRuntime>> taskAwaiter = new();
        private readonly ValueAwaiter<ITaskResult> resultAwaiter = new();

        public bool CanReuse { get; private set; } = true;

        public TaskExecutor(JNetVirtualMachine vm)
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
                    var task = taskAwaiter.Wait();
                    taskAwaiter.Reset();

                    var rc = runtime.PushLocalFrame(DefaultLocalFrameCapacity);
                    JNIResultException.Check(rc);

                    ITaskResult result;
                    try
                    {
                        task(runtime);
                        result = SuccessTaskResult.Instance;
                    }
                    catch (Exception e)
                    {
                        result = new ExceptionTaskResult(e);
                    }

                    runtime.PopLocalFrame(default);

                    resultAwaiter.Set(result);
                }
            }
            catch (Exception e)
            {
                CanReuse = false;
                resultAwaiter.Set(new ExceptionTaskResult(e));
                throw;
            }
            finally
            {
                vm.DetachCurrentThread();
            }
        }

        public void Run(Action<JNetRuntime> task)
        {
            taskAwaiter.Set(task);

            var result = resultAwaiter.Wait();
            resultAwaiter.Reset();

            result.Process();
        }

        private interface ITaskResult
        {
            public void Process() { }
        }

        private class SuccessTaskResult : ITaskResult
        {
            public static readonly ITaskResult Instance = new SuccessTaskResult();
        }

        private class ExceptionTaskResult : ITaskResult
        {
            private readonly Exception exception;
            
            public ExceptionTaskResult(Exception exception)
            {
                this.exception = exception;
            }

            public void Process()
            {
                throw new AggregateException(exception);
            }
        }
    }
}
