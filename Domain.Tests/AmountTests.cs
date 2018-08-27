using System;
using Domain.ValueObjects;
using Shouldly;
using Xunit;

namespace Domain.Tests
{
    public class AmountTests
    {
        [Fact]
        public void Positive_Amount_Should_Be_Created()
        {
            //arrange
            double positiveAmount = 100;

            Amount amount = new Amount(positiveAmount);

            Assert.Equal<double>(positiveAmount, amount);
        }

        [Fact]
        public void Amount_Subtraction_With_500_Minus_100_Should_Be_400()
        {
            //Arrange
            Amount fiveHundred = new Amount(500);
            Amount hundred = new Amount(100);


            //Act
            Amount fourHundred = fiveHundred - hundred;

            //Assert
            Assert.Equal(400, fourHundred);
        }

        [Fact]
        public void Amount_Addition_With_100_And_200_Should_Be_300()
        {
            //Arrange
            Amount hundred = new Amount(100);
            Amount twoHundred = new Amount(200);

            //Act
            Amount threeHundred = hundred+ twoHundred;

            //Assert
            Assert.Equal(threeHundred, 300);
            Assert.Equal(threeHundred, new Amount(300));
        }

        // Using shouldly for readibility
        [Fact]
        public void Amount_10_Is_Smaller_Than_20()
        {
            //Arrange
            Amount ten = new Amount(10);
            Amount twenty = new Amount(20);

            //Act
            bool result = ten < twenty;

            //Assert
            result.ShouldBeTrue();
        }

        // Using Shouldly again
        [Fact]
        public void Amount_2_Is_Greater_Than_1()
        {
            //Arrange
            Amount two = new Amount(2);
            Amount one = new Amount(1);

            //Act
            bool result = two > one;

            //Assert
            result.ShouldBe(true);
        }
    }
}
