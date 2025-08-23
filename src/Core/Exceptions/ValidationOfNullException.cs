using System.Runtime.Serialization;

namespace CMSCore.Exceptions
{
    [Serializable]
    internal class ValidationOfNullException : Exception
    {
        public ValidationOfNullException()
        {
        }

        public ValidationOfNullException(string? message) : base(message)
        {
        }

        public ValidationOfNullException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}