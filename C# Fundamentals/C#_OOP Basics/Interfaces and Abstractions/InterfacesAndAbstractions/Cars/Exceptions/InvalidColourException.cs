using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Cars.Exceptions
{
    [Serializable]
    internal class InvalidColourException : Exception
    {
        public InvalidColourException()
        {
        }

        public InvalidColourException(string message) : base(message)
        {
        }

        public InvalidColourException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidColourException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}

