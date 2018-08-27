using System;
using Domain.Accounts;
using Domain.Customers;
using Xunit;
using Shouldly;

namespace Domain.Tests
{
    public class CustomerTests
    {
        [Fact]
        public void Customer_Should_Have_One_Account()
        {
            //Arrange

            Customer customer = new Customer("12345678901", "firat");

            var account = new Account(customer.Id);

            //Act
            customer.RegisterAccount(account.Id);

            //Assert
            Assert.Single(customer.Accounts);
            
        }

        [Fact]
        public void Customer_Should_Have_Two_Accounts()
        {
            //Arrange
            Customer customer = new Customer("12345678901", "firat");

            var account1 = new Account(customer.Id);
            var account2 = new Account(customer.Id);

            //Act
            customer.RegisterAccount(account1.Id);
            customer.RegisterAccount(account2.Id);

            //Assert
            customer.Accounts.Count.ShouldBe(2);
            customer.Accounts.ShouldContain(account1.Id);
            customer.Accounts.ShouldContain(account2.Id);
        }


    }
}
