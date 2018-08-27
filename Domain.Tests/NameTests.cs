using System;
using Domain.ValueObjects;
using Xunit;

namespace Domain.Tests
{
    public class NameTests
    {
        [Fact]
        public void Name_Should_Not_Be_Empty()
        {
            string name = string.Empty;

            Assert.Throws<NameCanNotBeNullOrEmptyException>(()=> new Name(name));
        }

        [Fact]
        public void Name_Should_Have_Value()
        {
            Name name = new Name("firat");

            Assert.Equal(name, new Name(name));
        }

    }
}
