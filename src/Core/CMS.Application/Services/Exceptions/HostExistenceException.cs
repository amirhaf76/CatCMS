namespace CMS.Application.Services.Exceptions
{
    [Serializable]
    public class HostExistenceException : Exception
    {
        public HostExistenceException()
        {
        }

        public HostExistenceException(string? message) : base(message)
        {
        }

        public HostExistenceException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}