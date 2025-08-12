namespace CMSApi.Services.Exceptions
{
    [Serializable]
    internal class UnauthorizedUserException : Exception
    {
        public UnauthorizedUserException()
        {
        }

        public UnauthorizedUserException(string? message) : base(message)
        {
        }

        public UnauthorizedUserException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}