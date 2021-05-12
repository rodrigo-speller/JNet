// Copyright (c) Rodrigo Speller. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.

using System.ComponentModel;
using System.Runtime.InteropServices;
using Xunit;

namespace JNet.Runtime.Test
{
    public class PrimitiveTypes_jboolean_Tests
    {
        [Fact]
        [Description("Checking the size of the unmanaged type of jboolean")]
        public void JBooleanDataSize()
        {
            var sz = Marshal.SizeOf<jboolean>();

            // must be an unsigned 8 bits data (1 byte)
            Assert.Equal(1, sz);
        }

        [Fact]
        [Description("Casting the CLR boolean 'true' value to jboolean.")]
        public void CastsBooleanTrueToJBoolean()
        {
            jboolean jz_true = true;

            Assert.Equal(jboolean.True, jz_true);
        }

        [Fact]
        [Description("Casting the CLR boolean 'false' value to jboolean.")]
        public void CastsBooleanFalseToJBoolean()
        {
            jboolean jz_false = false;

            Assert.Equal(jboolean.False, jz_false);
        }

        [Fact]
        [Description("Casting the jboolean 'true' value to CLR boolean.")]
        public void CastsJBooleanTrueToBoolean()
        {
            var jz_true = jboolean.True;

            Assert.True(jz_true);
        }

        [Fact]
        [Description("Casting the jboolean 'false' value to CLR boolean.")]
        public void CastsJBooleanFalseToBoolean()
        {
            var jz_false = jboolean.False;

            Assert.False(jz_false);
        }
    }
}
