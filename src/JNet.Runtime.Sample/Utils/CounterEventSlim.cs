// Copyright (c) Rodrigo Speller. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.

using System.Threading;

namespace JNet.Runtime.Sample.Utils
{
    public class CounterEventSlim
    {
        private int counter = 0;
        private readonly EventWaitHandle handle = new(true, EventResetMode.ManualReset);

        public void Increment()
        {
            lock (handle)
            {
                if (counter++ == 0)
                {
                    handle.Reset();
                }
            }
        }

        public void Decrement()
        {
            lock (handle)
            {
                if (--counter > 0)
                    return;
                
                if (counter < 0)
                {
                    counter = 0;
                    return;
                }

                handle.Set();
            }
        }

        public bool WaitOne()
            => handle.WaitOne();
    }
}
