using System.Runtime.Serialization;

namespace Core.Exceptions
{
    [Serializable]
    public class NullSiteConfigurationException : Exception
    {
        public NullSiteConfigurationException()
        {
        }

        public NullSiteConfigurationException(string? message) : base(message)
        {
        }

        public NullSiteConfigurationException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected NullSiteConfigurationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}