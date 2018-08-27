using System;
using Domain.Customers;
using Domain.ValueObjects;

namespace Domain.Services
{
    public interface ICustomerService
    {

        Customer Register(IdentityId identityId, Name name);
    }
}
