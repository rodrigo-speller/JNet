// Copyright (c) Rodrigo Speller. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.

using System;
using System.Collections.Concurrent;

namespace JNet.Runtime.Sample.Utils
{
    public class ObjectPool<T>
    {
        private readonly ConcurrentBag<T> bag = new ConcurrentBag<T>();
        private readonly Func<T> factory;

        public ObjectPool(Func<T> factory)
        {
            this.factory = factory
                ?? throw new ArgumentNullException(nameof(factory));
        }

        public T Get() => bag.TryTake(out T item)
            ? item
            : factory();

        public void Return(T item) => bag.Add(item);
    }
}
