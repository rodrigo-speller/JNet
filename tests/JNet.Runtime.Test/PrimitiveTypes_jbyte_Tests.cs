// Copyright (c) Rodrigo Speller. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.

using System.Runtime.InteropServices;
using Xunit;

namespace JNet.Runtime.Test
{
    public class PrimitiveTypes_jbyte_Tests
    {
        [Fact]
        public void Check_jbyte_unmanaged_size()
        {
            var sz = Marshal.SizeOf<jbyte>();

            // must be an signed 8 bits data (1 byte)
            Assert.Equal(1, sz);
        }

        [Fact]
        public void Check_jbyte_default_value()
        {
            jbyte jb_value = default;

            Assert.Equal<byte>(0, jb_value);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(127)]
        [InlineData(128)]
        [InlineData(255)]
        public void Cast_byte_values_to_jbyte_and_vice_versa(byte value)
        {
            jbyte jb_value = value;

            Assert.Equal<byte>(value, jb_value);
        }
    }
}
