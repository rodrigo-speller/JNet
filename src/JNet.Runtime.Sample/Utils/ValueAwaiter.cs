// Copyright (c) Rodrigo Speller. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.

using System.Threading;

namespace JNet.Runtime.Sample.Utils
{
    internal class ValueAwaiter<T>
    {
        private readonly ManualResetEventSlim signal = new ManualResetEventSlim(false);
        public T value;

        public ValueAwaiter()
        {
            signal = new(false);
        }

        public ValueAwaiter(T value)
        {
            this.value = value;
            signal = new(true);
        }

        public void Reset()
        {
            this.value = default;
            signal.Reset();
        }

        public void Set(T value)
        {
            this.value = value;
            signal.Set();
        }

        public T Wait()
        {
            signal.Wait();
            return value;
        }

        public T Wait(CancellationToken cancellationToken)
        {
            signal.Wait(cancellationToken);
            return value;
        }

        public T WaitAndReset()
        {
            var value = Wait();
            Reset();
            return value;
        }

        public T WaitAndReset(CancellationToken cancellationToken)
        {
            var value = Wait(cancellationToken);
            Reset();
            return value;
        }
    }
}
