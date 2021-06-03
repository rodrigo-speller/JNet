// Copyright (c) Rodrigo Speller. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.

using System.Threading;
using JNet.Runtime;

namespace JNet.Hosting
{
    public delegate void JNetRunnable(JNetRuntime runtime);
    public delegate TResult JNetRunnable<out TResult>(JNetRuntime runtime);
    public delegate void JNetCancellableRunnable(JNetRuntime runtime, CancellationToken cancellationToken);
    public delegate TResult JNetCancellableRunnable<out TResult>(JNetRuntime runtime, CancellationToken cancellationToken);
}
