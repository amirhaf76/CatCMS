using System.Runtime.Serialization;

namespace CMSCore.Abstraction
{
    [Serializable]
    public class NullTitleException : Exception
    {
        public NullTitleException()
        {
        }

        public NullTitleException(string? message) : base(message)
        {
        }

        public NullTitleException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected NullTitleException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}