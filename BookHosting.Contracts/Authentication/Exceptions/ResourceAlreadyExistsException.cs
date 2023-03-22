using System;
namespace BookHosting.Domain.Exceptions
{
    public class ResourceAlreadyExistsException : Exception
    {
        public ResourceAlreadyExistsException(string message) : base(message)
        {
        }
        public ResourceAlreadyExistsException(string message, Exception ex) : base(message, ex)
        {
        }
    }
}

