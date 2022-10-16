using System;
using System.Runtime.Serialization;

namespace Demo.SQLCLR.ApiCall.Exceptions
{
    [Serializable]
    public class NationalizeReponseException : Exception
    {
        public NationalizeReponseException()
        {
        }

        public NationalizeReponseException(string message) : base(message)
        {
        }

        public NationalizeReponseException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NationalizeReponseException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}