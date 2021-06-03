// Copyright (c) Rodrigo Speller. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;

namespace JNet.Hosting.Utils
{
    /// <summary>
    /// Thread-safe object pool.
    /// </summary>
    /// <typeparam name="T">The item type.</typeparam>
    internal class ObjectPoolSlim<T>
    {

#if DEBUG
        public const int DefaultInitialCapacity = 2;
#else
        public const int DefaultInitialCapacity = 32;
#endif

        // thread sync object
        private readonly object lockObj = new();

        // item factory function
        private readonly Func<T> factory;

        // pool attributes

        private T[] pool;
        private int index = 0;
        private int capacity;

        /// <summary>
        /// Gets the number of remaining items that can be obtained from the pool without the pool creates a new item.
        /// </summary>
        public int CurrentCount => Math.Max(index, 0);

        /// <summary>
        /// Gets the number of current capacity of the pool.
        /// </summary>
        public int CurrentCapacity => capacity;

        /// <summary>
        /// Initializes a new object pool.
        /// </summary>
        /// <param name="factory">
        /// The factory function that will be called to create a new item if no item is available when
        /// /// <see cref="Get" /> is called.
        /// </param>
        public ObjectPoolSlim(Func<T> factory)
            : this(factory, DefaultInitialCapacity)
        { }

        /// <summary>
        /// Initializes a new object pool with an initial capacity.
        /// </summary>
        /// <param name="factory">
        /// The factory function that will be called to create a new item if no item is available when
        /// <see cref="Get" /> is called.
        /// </param>
        /// <param name="initialCapacity">
        /// The initial capacity of the pool. The pool capacity will automatically increase as needed.
        /// </param>
        public ObjectPoolSlim(Func<T> factory, int initialCapacity)
        {
            this.factory = factory
                ?? throw new ArgumentNullException(nameof(factory));

            if (initialCapacity <= 0)
                throw new ArgumentOutOfRangeException(nameof(initialCapacity));

            this.capacity = initialCapacity;
            this.pool = new T[initialCapacity];
        }

        /// <summary>
        /// Initializes a new object pool with a set of initial items.
        /// </summary>
        /// <param name="factory">
        /// The factory function that will be called to create a new item if no item is available when
        /// <see cref="Get" /> is called.
        /// </param>
        /// <param name="initialItems">
        /// The initial items of the pool. The pool capacity will automatically increase as needed.
        /// </param>
        public ObjectPoolSlim(Func<T> factory, IEnumerable<T> initialItems)
        {
            this.factory = factory
                ?? throw new ArgumentNullException(nameof(factory));

            if (initialItems is null)
                throw new ArgumentNullException(nameof(initialItems));

            var pool = initialItems.ToArray();

            if (pool.Length == 0)
                pool = new T[DefaultInitialCapacity];

            this.capacity = pool.Length;
            this.pool = pool;
        }

        /// <summary>
        /// Initializes a new object pool with a set of initial items.
        /// </summary>
        /// </param>
        /// <param name="items">
        /// The items of the pool.
        /// </param>
        public ObjectPoolSlim(IEnumerable<T> items)
        {
            if (items is null)
                throw new ArgumentNullException(nameof(items));

            var pool = items.ToArray();

            if (pool.Length == 0)
                throw new ArgumentException("The object pool cannot be initialized without items.", nameof(items));

            this.capacity = pool.Length;
            this.pool = pool;
            this.factory = NoFactory;
        }

        private static T NoFactory()
            => throw new InvalidOperationException("The object pool does not supports item creation.");

        /// <summary>
        /// Gets an available item from the pool.
        /// If no item is available, call the <see cref="factory" /> function to build one and return it.
        /// 
        /// If the <see cref="factory" /> throws an exception, that exception will bubble to the caller.
        /// </summary>
        /// <returns>An available item.</returns>
        public T Get() 
        {
            if (TryGet(out var item))
                return item;

            return factory();
        }

        /// <summary>
        /// Gets an available item from the pool.
        /// </summary>
        /// <param name="result">
        /// When this method returns, <paramref name="result" /> contains the available item or the default value of
        /// <see cref="T" /> if the pool is empty.
        /// </param>
        /// <returns>
        /// <see langword="true" /> if an available item was found, otherwise <see langword="false" />.
        /// </returns>
        public bool TryGet(out T result)
        {
            lock (lockObj)
            {
                var index = --this.index;

                if (index < 0)
                {
                    this.index = 0;

                    result = default;
                    return false;
                }

                result = pool[index];
    #if DEBUG
                // DEBUG vs PERFOMANCE!
                // Removes the current pool item only in debug mode.
                // In non-debug mode, it does not matter, for performance.
                pool[index] = default;
    #endif
                return true;
            }
        }

        /// <summary>
        /// Returns an item to the pool that can be obtained when <see cref="Get" /> is called.
        /// </summary>
        /// <param name="item">The item to be returned to the pool.</param>
        public void Return(T item) 
        {
            lock (lockObj)
            {
                var index = this.index++;

                if (index == capacity)
                {
                    capacity *= 2;
                    Array.Resize(ref pool, capacity);
                }

                pool[index] = item;
            }
        }
    }
}
