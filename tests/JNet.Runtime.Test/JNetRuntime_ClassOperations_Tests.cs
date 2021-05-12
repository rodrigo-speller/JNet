// Copyright (c) Rodrigo Speller. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE.txt in the project root for license information.

using Xunit;

namespace JNet.Runtime.Test
{
    public class JNetRuntime_ClassOperations_Tests : JNetRuntimeTestBase
    {
        public JNetRuntime_ClassOperations_Tests(JNetRuntimeFixture runtime)
            : base(runtime)
        { }

        [Fact]
        public void Find_system_class()
        {
            var clz_System = Runtime.FindClass("java/lang/System");

            // it must return the class in the value
            Assert.True(clz_System.HasValue);
        }

        [Fact]
        public void Find_unknown_class()
        {
            var clz_UnknownClass = Runtime.FindClass("invalid/package/UnknownClass");

            // it must not return a value
            Assert.False(clz_UnknownClass.HasValue);

            // it must throws an exception
            Assert.True(Runtime.ExceptionCheck());

            // get ocurred exception
            var jex_Exception = Runtime.ExceptionOccurred();
            Assert.True(jex_Exception.HasValue);

            // clear exception
            Runtime.ExceptionClear();

            // find the expected exception class (NoClassDefFoundError)
            var clz_NoClassDefFoundError = Runtime.FindClass("java/lang/NoClassDefFoundError");

            // check the type of the exception
            Assert.True(Runtime.IsInstanceOf(jex_Exception, clz_NoClassDefFoundError));
        }
    }
}
