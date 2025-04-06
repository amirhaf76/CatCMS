using System.Runtime.Serialization;

namespace CMSCore.Abstraction
{
    [Serializable]
    internal class NullPassingException : Exception
    {
        public NullPassingException()
        {
        }

        public NullPassingException(string? message) : base(message)
        {
        }

        public NullPassingException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected NullPassingException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}