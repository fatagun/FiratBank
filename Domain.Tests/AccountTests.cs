using System;
using Xunit;
using Domain.ValueObjects;
using Shouldly;
using Domain.Accounts;
using Domain.Customers;

namespace Domain.Tests
{
    public class AccountTests
    {
        [Fact]
        public void New_Account_Should_Not_Allow_Withdraw()
        {
            var account = new Account(Guid.NewGuid());

            Assert.Throws<NotEnoughAmountException>(() => account.Withdraw(100));
        }

        [Fact]
        public void Account_With_Balance_Should_Not_Allow_Closing()
        {
            var account = new Account(Guid.NewGuid());
            account.Deposit(100);

            Assert.Throws<CannotCloseAccountException>(()=> account.CloseAccount());
        }

        [Fact]
        public void Accout_Should_Take_Deposit()
        {
            var account = new Account(Guid.NewGuid());

            account.Deposit(100);

            account.GetAccountBalance().ShouldBe(100);
        }

        [Fact]
        public void Account_Should_Allow_Withdraw()
        {
            var account = new Account(Guid.NewGuid());

            account.Deposit(100);
            account.Withdraw(20);

            account.GetAccountBalance().ShouldBe(80);
        }

        [Fact]
        public void Account_Should_Get_Last_Transaction()
        {
            var account = new Account(Guid.NewGuid());
            account.Deposit(100);
            account.Deposit(300);
            account.Deposit(80);
            account.Withdraw(200);

            account.GetLastTransaction().Amount.ShouldBe(200);
            account.GetAccountBalance().ShouldBe(280);
        }

        [Fact]
        public void Account_With_500_Balance_Should_Have_400_After_100_Withdraw()
        {
            //Arrange
            var account = new Account(Guid.NewGuid());

            account.Deposit(500);

            //Act
            account.Withdraw(100);

            //Assert
            account.GetAccountBalance().ShouldBe(400);

        }
    }
}
