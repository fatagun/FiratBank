using System;
using System.Collections.Generic;
using Domain.Interfaces;
using Domain.ValueObjects;

namespace Domain.Customers
{
    public sealed class Customer : IEntity
    {
        public Guid Id { get; private set; }
        public Name Name { get; private set; }
        public IdentityId IdentityId { get; private set; }

        private AccountCollection _accounts;


        public IReadOnlyCollection<Guid> Accounts
        {
            get
            {
                return _accounts.GetAccountIds();    
            }
        }

        public Customer(IdentityId identityId, Name name)
        {
            Id = Guid.NewGuid();
            Name = name;
            IdentityId = identityId;
            _accounts = new AccountCollection();
        }

        //Why ? Immutability.
        private Customer(){}

        public void RegisterAccount(Guid accountId)
        {
            _accounts.AddAccount(accountId);
        }

        public static Customer Load(Guid id, Name name, IdentityId identityId, AccountCollection accounts)
        {
            Customer customer = new Customer();
            customer.Id = id;
            customer.Name = name;
            customer.IdentityId = identityId;
            customer._accounts = accounts;

            return customer;
        }

    }
}
