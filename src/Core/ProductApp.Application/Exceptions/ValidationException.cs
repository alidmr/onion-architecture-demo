using System;

namespace ProductApp.Application.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException() : this("Validaton error occured")
        {

        }

        public ValidationException(string message) : base(message)
        {

        }

        public ValidationException(Exception exception) : this(exception.Message)
        {

        }
    }
}
