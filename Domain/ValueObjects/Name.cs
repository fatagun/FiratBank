using System;
namespace Domain.ValueObjects
{
    public sealed class Name
    {
        private string _text;

        public Name(string text)
        {
            if(string.IsNullOrEmpty(text))
            {
                throw new NameCanNotBeNullOrEmptyException("The 'Name' field is required");
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
            if(ReferenceEquals(null, obj))
            {
                return false;
            }

            if(ReferenceEquals(this, obj))
            {
                return true;
            }

            if(obj is string)
            {
                return obj.ToString() == _text;
            }

            return ((Name)obj)._text == _text;
        }

        public static implicit operator Name(string text)
        {
            return new Name(text);
        }

        public static implicit operator string(Name name)
        {
            return name._text;
        }
    }
}
