// Copyright (c) Rodrigo Speller. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.

using System.Runtime.InteropServices;
using Xunit;

namespace JNet.Runtime.Test
{
    public class PrimitiveTypes_jfloat_Tests
    {
        [Fact]
        public void Check_jfloat_unmanaged_size()
        {
            var sz = Marshal.SizeOf<jfloat>();

            // must be an 32 bits data (4 bytes)
            Assert.Equal(4, sz);
        }

        [Fact]
        public void Check_jfloat_default_value()
        {
            jfloat jf_value = default;

            Assert.Equal<float>(0f, jf_value);
        }

        [Theory]
        [InlineData(-1.5f)]
        [InlineData(-1f)]
        [InlineData(0f)]
        [InlineData(1f)]
        [InlineData(1.5f)]
        [InlineData(float.Epsilon)]
        [InlineData(float.MaxValue)]
        [InlineData(float.MinValue)]
        [InlineData(float.NaN)]
        [InlineData(float.NegativeInfinity)]
        [InlineData(float.PositiveInfinity)]
        public void Cast_float_values_to_jfloat_and_vice_versa(float value)
        {
            jfloat jf_value = value;

            Assert.Equal<float>(value, jf_value);
        }
    }
}
