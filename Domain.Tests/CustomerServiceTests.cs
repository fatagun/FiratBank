using System;
using Domain.Customers;
using Domain.Data;
using Domain.Services;
using NSubstitute;
using Xunit;

namespace Domain.Tests
{
    public class CustomerServiceTests
    {
        private ICustomerRepository _customerRepository;

        public CustomerServiceTests()
        {
            //Using nsubstitude
            _customerRepository = Substitute.For<ICustomerRepository>();
        }

        [Theory]
        [InlineData("12345678901","Firat")]
        [InlineData("12345678902", "Firat")]
        public void Customer_Registration_Should_Succeed(string identityId, string name)
        {
            //Arrange
            Customer customer = new Customer(identityId, name);

            var customerService = new CustomerService(_customerRepository);

            //Act
            var expectedCustomer = customerService.Register(identityId, name);

            //Assert
            Assert.Equal(expectedCustomer.IdentityId, customer.IdentityId);
            Assert.Equal(expectedCustomer.Name, customer.Name);

        }
    }
}
