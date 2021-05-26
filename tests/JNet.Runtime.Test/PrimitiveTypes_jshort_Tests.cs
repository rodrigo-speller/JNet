// Copyright (c) Rodrigo Speller. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.

using System.Runtime.InteropServices;
using Xunit;

namespace JNet.Runtime.Test
{
    public class PrimitiveTypes_jshort_Tests
    {
        [Fact]
        public void Check_jshort_unmanaged_size()
        {
            var sz = Marshal.SizeOf<jshort>();

            // must be an signed 16 bits data (2 bytes)
            Assert.Equal(2, sz);
        }

        [Fact]
        public void Check_jshort_default_value()
        {
            jshort js_value = default;

            Assert.Equal<short>(0, js_value);
        }

        [Theory]
        [InlineData(-32768)]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(32767)]
        public void Cast_short_values_to_jshort_and_vice_versa(short value)
        {
            jshort js_value = value;

            Assert.Equal<short>(value, js_value);
        }
    }
}
