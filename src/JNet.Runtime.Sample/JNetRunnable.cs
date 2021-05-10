// Copyright (c) Rodrigo Speller. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.

namespace JNet.Runtime.Sample
{
    public delegate void JNetRunnable(JNetRuntime runtime);
    public delegate TResult JNetRunnable<out TResult>(JNetRuntime runtime);
}
