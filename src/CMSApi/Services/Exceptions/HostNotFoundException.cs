namespace CMSApi.Services.Exceptions
{
    [Serializable]
    internal class HostNotFoundException : Exception
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