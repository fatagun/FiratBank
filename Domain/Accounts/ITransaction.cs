using System;
using Domain.ValueObjects;

namespace Domain.Accounts
{
    public interface ITransaction
    {
        Amount Amount { get; }
        string Description { get; }
        DateTime TransactionDate { get; }

        Amount Contrib(Amount totalAmount);
    }
}
