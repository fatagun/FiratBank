using System;
namespace Domain.Accounts
{
    public class CannotCloseAccountException : DomainException
    {
        public CannotCloseAccountException(string message) : base(message)
        {
        }
    }
}
