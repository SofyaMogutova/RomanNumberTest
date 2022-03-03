using System;

namespace RomanNumberTest
{
    internal class RomanNumberException : Exception
    {
        public RomanNumberException(string message) : base(message) { }
    }
}