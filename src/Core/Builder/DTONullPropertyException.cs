using System.Runtime.Serialization;

namespace CMSCore.Builder
{
    [Serializable]
    internal class DTONullPropertyException : Exception
    {
        public DTONullPropertyException()
        {
        }

        public DTONullPropertyException(string? message) : base(message)
        {
        }

        public DTONullPropertyException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected DTONullPropertyException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}