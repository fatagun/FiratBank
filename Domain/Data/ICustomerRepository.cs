using System;
using Domain.Customers;

namespace Domain.Data
{
    public interface ICustomerRepository
    {
        void Add(Customer customer);
    }
}
