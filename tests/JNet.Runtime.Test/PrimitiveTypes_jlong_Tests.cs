// Copyright (c) Rodrigo Speller. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.

using System.Runtime.InteropServices;
using Xunit;

namespace JNet.Runtime.Test
{
    public class PrimitiveTypes_jlong_Tests
    {
        [Fact]
        public void Check_jlong_unmanaged_size()
        {
            var sz = Marshal.SizeOf<jlong>();

            // must be an signed 64 bits data (8 bytes)
            Assert.Equal(8, sz);
        }

        [Fact]
        public void Check_jlong_default_value()
        {
            jlong jj_value = default;

            Assert.Equal<long>(0, jj_value);
        }

        [Theory]
        [InlineData(-9223372036854775808)]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(9223372036854775807)]
        public void Cast_long_values_to_jlong_and_vice_versa(long value)
        {
            jlong jl_value = value;

            Assert.Equal<long>(value, jl_value);
        }
    }
}
