using System.Runtime.Serialization;

namespace CMSCore
{
    [Serializable]
    internal class PageNotFoundException : Exception
    {
        public PageNotFoundException()
        {
        }

        public PageNotFoundException(string? message) : base(message)
        {
        }

        public PageNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected PageNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}