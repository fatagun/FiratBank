using System;
using Domain.Interfaces;
using Domain.ValueObjects;

namespace Domain.Accounts
{
    public sealed class Credit : IEntity, ITransaction
    {
        public Guid Id { get; private set; }

        public Guid AccountId { get; private set; }

        public Amount Amount { get; private set; }

        public string Description => "Credit";

        public DateTime TransactionDate { get; private set; }

        private Credit(){}

        public Credit(Guid accountId, Amount amount)
        {
            Id = Guid.NewGuid();
            AccountId = accountId;
            Amount = amount;
            TransactionDate = DateTime.Now;
        }

        public static Credit Load(Guid id, Guid accountId, Amount amount, DateTime transactionDate)
        {
            Credit debit = new Credit();
            debit.Id = id;
            debit.AccountId = accountId;
            debit.Amount = amount;
            debit.TransactionDate = transactionDate;

            return debit;
        }
    }
}
