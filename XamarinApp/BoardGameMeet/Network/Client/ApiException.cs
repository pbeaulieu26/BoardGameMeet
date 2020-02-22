using System;
using System.Runtime.Serialization;

namespace BoardGameMeet.Network.Client
{
    internal class ApiException : Exception
    {
        public ApiException()
        {
        }

        public ApiException(string message) : base(message)
        {
        }

        public ApiException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ApiException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public ApiStatus StatusCode { get; set; }

        public string Content { get; set; }
    }
}