using System.Runtime.Serialization;

namespace CMSCore
{
    [Serializable]
    internal class InvalidPathCharException : Exception
    {
        public InvalidPathCharException()
        {
        }

        public InvalidPathCharException(string? message) : base(message)
        {
        }

        public InvalidPathCharException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}