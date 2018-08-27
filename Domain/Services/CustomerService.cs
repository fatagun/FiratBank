using System;
using Domain.Customers;
using Domain.Data;
using Domain.ValueObjects;

namespace Domain.Services
{
    public class CustomerService : ICustomerService
    {
        readonly ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public Customer Register(IdentityId identityId, Name name)
        {
            var customer = new Customer(identityId, name);
            _customerRepository.Add(customer);

            return customer;
        }
    }
}
