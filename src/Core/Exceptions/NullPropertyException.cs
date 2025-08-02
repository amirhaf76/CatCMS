using System.Runtime.Serialization;

namespace CMSCore.Exceptions
{
    [Serializable]
    internal class NullPropertyException : Exception
    {
        public NullPropertyException()
        {
        }

        public NullPropertyException(string? message) : base(message)
        {
        }

        public NullPropertyException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected NullPropertyException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}