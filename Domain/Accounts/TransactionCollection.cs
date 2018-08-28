using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Domain.ValueObjects;

namespace Domain.Accounts
{
    
    public class TransactionCollection
    {
        private readonly IList<ITransaction> _transactions;

        public TransactionCollection()
        {
            _transactions = new List<ITransaction>();
        }

        public IReadOnlyCollection<ITransaction> GetTransactions()
        {
            IReadOnlyCollection<ITransaction> transactions = new ReadOnlyCollection<ITransaction>(_transactions);

            return transactions;
        }

        public ITransaction GetLastTransaction()
        {
            ITransaction transaction = _transactions.LastOrDefault();
            return transaction;
        }

        public void Add(ITransaction transaction)
        {
            _transactions.Add(transaction);
        }

        public void Add(IEnumerable<ITransaction> transactions)
        {
            foreach(var transaction in transactions)
            {
                _transactions.Add(transaction);
            }
        }

        public Amount GetBalance()
        {
            Amount totalAmount = new Amount(0);

            foreach(ITransaction transaction in _transactions)
            {
                if(transaction is Debit)
                {
                    totalAmount = totalAmount - transaction.Amount;
                }

                if(transaction is Credit)
                {
                    totalAmount = totalAmount + transaction.Amount;
                }
            }

            return totalAmount;
        }

    }
}
