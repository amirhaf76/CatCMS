
namespace CMSApi.Services
{
    [Serializable]
    internal class HostExistenceException : Exception
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