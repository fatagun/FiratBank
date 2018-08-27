using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Domain.Customers
{
    public class AccountCollection
    {
        readonly IList<Guid> _accountIds;

        public AccountCollection()
        {
            _accountIds = new List<Guid>();
        }

        public IReadOnlyCollection<Guid> GetAccountIds()
        {
            IReadOnlyCollection<Guid> accountIds = new ReadOnlyCollection<Guid>(_accountIds);

            return accountIds;
        }

        public void AddAccount(Guid accountId)
        {
            _accountIds.Add(accountId);
        }
    }
}
