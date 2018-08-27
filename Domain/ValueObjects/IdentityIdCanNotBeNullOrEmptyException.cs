using System;
namespace Domain.ValueObjects
{
    public class IdentityIdCanNotBeNullOrEmptyException : DomainException
    {
        public IdentityIdCanNotBeNullOrEmptyException(string message) : base(message)
        {
        }
    }
}
