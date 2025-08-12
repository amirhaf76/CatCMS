using System.Runtime.Serialization;

namespace CMSCore.Exceptions
{
    [Serializable]
    internal class HostNotFoundException : Exception
    {
        public HostNotFoundException()
        {
        }

        public HostNotFoundException(string? message) : base(message)
        {
        }

        public HostNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected HostNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}