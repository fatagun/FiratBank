using System;
using System.Collections.Generic;
using Domain.Customers;

namespace Domain.Data
{
    public class CustomerRepository : ICustomerRepository
    {
        IList<Customer> _customers;

        public CustomerRepository()
        {
            _customers = new List<Customer>();
        }

        public void Add(Customer customer)
        {
            _customers.Add(customer);
        }
    }
}
