// Copyright (c) Rodrigo Speller. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.

using System.Runtime.InteropServices;
using Xunit;

namespace JNet.Runtime.Test
{
    public class PrimitiveTypes_jdouble_Tests
    {
        [Fact]
        public void Check_jdouble_unmanaged_size()
        {
            var sz = Marshal.SizeOf<jdouble>();

            // must be an 64 bits data (8 bytes)
            Assert.Equal(8, sz);
        }

        [Fact]
        public void Check_jdouble_default_value()
        {
            jdouble jd_value = default;

            Assert.Equal<double>(0d, jd_value);
        }

        [Theory]
        [InlineData(-1.5d)]
        [InlineData(-1d)]
        [InlineData(0d)]
        [InlineData(1d)]
        [InlineData(1.5d)]
        [InlineData(double.Epsilon)]
        [InlineData(double.MaxValue)]
        [InlineData(double.MinValue)]
        [InlineData(double.NaN)]
        [InlineData(double.NegativeInfinity)]
        [InlineData(double.PositiveInfinity)]
        public void Cast_double_values_to_jdouble_and_vice_versa(double value)
        {
            jdouble jd_value = value;

            Assert.Equal<double>(value, jd_value);
        }
    }
}
