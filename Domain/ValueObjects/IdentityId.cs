using System;
namespace Domain.ValueObjects
{
    public sealed class IdentityId
    {
        private string _text;

        public IdentityId(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                throw new IdentityIdCanNotBeNullOrEmptyException("Identity Id Can not be null or empty");
            }

            _text = text;
        }

        public override string ToString()
        {
            return _text;
        }

        public override int GetHashCode()
        {
            return _text.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj is string)
            {
                return obj.ToString() == _text;
            }

            return ((IdentityId)obj)._text == _text;
        }

        //operator overloading
        public static implicit operator IdentityId(string text)
        {
            return new IdentityId(text);
        }

        public static implicit operator string(IdentityId identityId)
        {
            return identityId._text;
        }
    }
}
