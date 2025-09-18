namespace CMS.Application.Services.Exceptions
{
    [Serializable]
    public class HostNotFoundException : Exception
    {
        public HostNotFoundException()
        {
        }

        public HostNotFoundException(string? message) : base(message)
        {
        }

        public HostNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}