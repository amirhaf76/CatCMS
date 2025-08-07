namespace CMSClient.Services.Exceptions
{
    [Serializable]
    internal class UnsuccessfullAuthenticationException : Exception
    {
        public UnsuccessfullAuthenticationException()
        {
        }

        public UnsuccessfullAuthenticationException(string? message) : base(message)
        {
        }

        public UnsuccessfullAuthenticationException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}