using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WBizTrip.Services.Exceptions
{
    [Serializable]
    public class NoCredentialsException : Exception
    {
        public NoCredentialsException()
        {
        }

        public NoCredentialsException(string? message) : base(message)
        {
        }

        public NoCredentialsException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected NoCredentialsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
