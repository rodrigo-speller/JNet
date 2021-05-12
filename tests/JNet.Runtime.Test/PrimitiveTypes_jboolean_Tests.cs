// Copyright (c) Rodrigo Speller. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.

using System.Runtime.InteropServices;
using Xunit;

namespace JNet.Runtime.Test
{
    public class PrimitiveTypes_jboolean_Tests
    {
        [Fact]
        public void Check_jboolean_unmanaged_size()
        {
            var sz = Marshal.SizeOf<jboolean>();

            // must be an unsigned 8 bits data (1 byte)
            Assert.Equal(1, sz);
        }

        [Fact]
        public void Check_jboolean_default_value()
        {
            jboolean jz_value = default;

            Assert.False(jz_value);
        }

        [Fact]
        public void Cast_boolean_true_to_jboolean()
        {
            jboolean jz_true = true;

            Assert.Equal(jboolean.True, jz_true);
        }

        [Fact]
        public void Cast_boolean_false_to_jboolean()
        {
            jboolean jz_false = false;

            Assert.Equal(jboolean.False, jz_false);
        }

        [Fact]
        public void Cast_jboolean_true_to_boolean()
        {
            var jz_true = jboolean.True;

            Assert.True(jz_true);
        }

        [Fact]
        public void Cast_jboolean_false_to_boolean()
        {
            var jz_false = jboolean.False;

            Assert.False(jz_false);
        }
    }
}
