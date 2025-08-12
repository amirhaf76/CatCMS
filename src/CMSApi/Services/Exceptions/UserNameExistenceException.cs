namespace CMSApi.Services.Exceptions
{
    [Serializable]
    internal class UserNameExistenceException : Exception
    {
        public UserNameExistenceException()
        {
        }

        public UserNameExistenceException(string? message) : base(message)
        {
        }

        public UserNameExistenceException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}