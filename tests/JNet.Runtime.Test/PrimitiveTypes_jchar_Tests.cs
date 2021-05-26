// Copyright (c) Rodrigo Speller. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.

using System.Runtime.InteropServices;
using Xunit;

namespace JNet.Runtime.Test
{
    public class PrimitiveTypes_jchar_Tests
    {
        [Fact]
        public void Check_jchar_unmanaged_size()
        {
            var sz = Marshal.SizeOf<jchar>();

            // must be an unsigned 16 bits data (2 bytes)
            Assert.Equal(2, sz);
        }

        [Fact]
        public void Check_jchar_default_value()
        {
            jchar jc_value = default;

            Assert.Equal<ushort>(0, jc_value);
        }

        [Theory]
        [InlineData('\0')]
        [InlineData('\t')]
        [InlineData('\n')]
        [InlineData(' ')]
        [InlineData('0')]
        [InlineData('A')]
        [InlineData('ÿ')]
        [InlineData('€')]
        [InlineData('☢')]
        public void Cast_char_values_to_jchar_and_vice_versa(char value)
        {
            jchar jc_value = value;

            Assert.Equal<char>(value, jc_value);
        }

        [Theory]
        [InlineData((ushort)'\0')]
        [InlineData((ushort)'\t')]
        [InlineData((ushort)'\n')]
        [InlineData((ushort)' ')]
        [InlineData((ushort)'0')]
        [InlineData((ushort)'A')]
        [InlineData((ushort)'ÿ')]
        [InlineData((ushort)'€')]
        [InlineData((ushort)'☢')]
        public void Cast_ushort_values_to_jchar_and_vice_versa(ushort value)
        {
            jchar jc_value = value;

            Assert.Equal<ushort>(value, jc_value);
        }
    }
}
