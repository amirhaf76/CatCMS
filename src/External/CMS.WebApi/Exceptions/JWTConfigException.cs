namespace CMS.WebApi.Exceptions
{
    [Serializable]
    internal class JWTConfigException : Exception
    {
        public JWTConfigException()
        {
        }

        public JWTConfigException(string? message) : base(message)
        {
        }

        public JWTConfigException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}