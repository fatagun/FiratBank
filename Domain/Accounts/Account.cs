using System;
using System.Collections.Generic;
using Domain.Interfaces;
using Domain.ValueObjects;

namespace Domain.Accounts
{
    public sealed class Account : IEntity
    {
        public Guid Id { get; private set; }

        public Guid CustomerId { get; private set; }

        private TransactionCollection _transactions;

        public IReadOnlyCollection<ITransaction> GetTransactions()
        {
            IReadOnlyCollection<ITransaction> transactions = _transactions.GetTransactions();

            return transactions;
        }

        public Account(Guid customerId)
        {
            CustomerId = customerId;
            Id = Guid.NewGuid();
            _transactions = new TransactionCollection();
        }

        private Account() {}

        public static Account Load(Guid id, Guid customerId, TransactionCollection transactionCollection)
        {
            Account account = new Account();
            account.Id = id;
            account.CustomerId = customerId;
            account._transactions = transactionCollection;

            return account;
        }

        public void Deposit(Amount amount)
        {
            Credit credit = new Credit(Id, amount);
            _transactions.Add(credit);
        }

        public void Withdraw(Amount amount)
        {
            if(_transactions.GetBalance() < amount)
            {
                throw new NotEnoughAmountException("Account does not have enough amount of funds. Try again!");
            }
            // withdraw from debit
            Debit debit = new Debit(Id, amount);
            _transactions.Add(debit);
        }

        public void CloseAccount()
        {
            if(_transactions.GetBalance() > 0)
            {
                throw new CannotCloseAccountException("There is balance in the account. Can not be closed!");
            }

        }

        public Amount GetAccountBalance()
        {
            Amount balance = _transactions.GetBalance();

            return balance;
        }

        public ITransaction GetLastTransaction()
        {
            return _transactions.GetLastTransaction();
        }

    }
}
