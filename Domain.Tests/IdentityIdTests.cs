using System;
using Domain.ValueObjects;
using Xunit;

namespace Domain.Tests
{
    public class IdentityIdTests
    {
        [Fact]
        public void Valid_Identity_Id_Should_Be_Created()
        {
            //arrange
            string valid = "12345678901";

            //act
            IdentityId identityId = new IdentityId(valid);

            //Assert
            Assert.Equal(valid, identityId);
        }

        [Fact]
        public void Identity_Id_Can_Not_Be_Empty_or_Null()
        {
            //arrange
            string empty = string.Empty;

            //Act and assert

            Assert.Throws<IdentityIdCanNotBeNullOrEmptyException>(() => new IdentityId(empty));
        }

    }
}
