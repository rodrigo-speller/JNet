// Copyright (c) Rodrigo Speller. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.

using System.Runtime.InteropServices;
using Xunit;

namespace JNet.Runtime.Test
{
    public class PrimitiveTypes_jint_Tests
    {
        [Fact]
        public void Check_jint_unmanaged_size()
        {
            var sz = Marshal.SizeOf<jint>();

            // must be an signed 32 bits data (4 bytes)
            Assert.Equal(4, sz);
        }

        [Fact]
        public void Check_jint_default_value()
        {
            jint ji_value = default;

            Assert.Equal<int>(0, ji_value);
        }

        [Theory]
        [InlineData(-2147483648)]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2147483647)]
        public void Cast_int_values_to_jint_and_vice_versa(int value)
        {
            jint ji_value = value;

            Assert.Equal<int>(value, ji_value);
        }
    }
}
