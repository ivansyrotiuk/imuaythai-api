using System;

namespace IMuaythai.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message)
        {
        }
    }

    public class AuthException : Exception
    {
        public AuthException(string message) : base(message)
        {
        }
    }
}
