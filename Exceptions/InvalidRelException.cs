using System;
using System.Runtime.Serialization;

namespace Otus2.Exceptions
{
    public class InvalidRelException : Exception
    {
        public InvalidRelException()
        {
        }

        public InvalidRelException(string message) : base(message)
        {
        }

        public InvalidRelException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidRelException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}