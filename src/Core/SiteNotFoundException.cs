using System.Runtime.Serialization;

namespace CMSCore
{
    [Serializable]
    internal class SiteNotFoundException : Exception
    {
        public SiteNotFoundException()
        {
        }

        public SiteNotFoundException(string? message) : base(message)
        {
        }

        public SiteNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected SiteNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}