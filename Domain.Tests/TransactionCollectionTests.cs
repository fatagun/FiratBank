using System;
using System.Collections.Generic;
using Domain.Accounts;
using Xunit;
using Shouldly;

namespace Domain.Tests
{
    public class TransactionCollectionTests
    {
        [Fact]
        public void Multiple_Transactions_Should_Be_Supported()
        {
            TransactionCollection transactionCollection = new TransactionCollection();

            transactionCollection.Add(
                new List<ITransaction>()
                {
                    new Credit(Guid.NewGuid(), 50),
                    new Debit(Guid.NewGuid(), 30)
                }
            );

            // Using shouldly and lambda expression
            transactionCollection.GetTransactions().ShouldContain(transaction => transaction.Amount == 50);
            transactionCollection.GetTransactions().ShouldContain(transaction => transaction.Amount == 30);
        }
    }
}
