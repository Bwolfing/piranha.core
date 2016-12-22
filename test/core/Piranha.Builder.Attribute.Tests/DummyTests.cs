/*
 * Copyright (c) 2016 Håkan Edling
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 * 
 * https://github.com/piranhacms/piranha.core
 * 
 */

using Xunit;

namespace Piranha.Builder.Attribute.Tests
{
    public class DummyTests
    {
        [Fact]
        public void DummyTest() {
            Assert.Equal(3, 1 + 2);
        }
    }
}