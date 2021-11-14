using System;
using System.Runtime.Serialization;

namespace Otus2.Exceptions
{
    public class BreakInsertRow : Exception
    {
        public BreakInsertRow()
        {
        }

        public BreakInsertRow(string message) : base(message)
        {
        }

        public BreakInsertRow(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected BreakInsertRow(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}