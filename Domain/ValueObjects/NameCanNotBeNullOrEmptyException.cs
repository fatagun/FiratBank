using System;
namespace Domain.ValueObjects
{
    public class NameCanNotBeNullOrEmptyException : DomainException
    {
        public NameCanNotBeNullOrEmptyException(string message) : base(message)
        {
        }
    }
}
