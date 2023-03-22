using System;
namespace BookHosting.Application.Exceptions
{
    public class ResourceNotFoundException : Exception
    {
        public ResourceNotFoundException(string Message) : base(Message) { }
        public ResourceNotFoundException(string Message, Exception ex) : base(Message, ex) { }


    }
}

