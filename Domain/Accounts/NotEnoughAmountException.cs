using System;
namespace Domain.Accounts
{
    public class NotEnoughAmountException : DomainException
    {
        public NotEnoughAmountException(string message): base(message)
        {
        }
    }
}
