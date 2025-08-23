using System.Runtime.Serialization;

namespace CMSCore.Exceptions
{
    [Serializable]
    internal class UnqualifiedPathException : Exception
    {
        public UnqualifiedPathException()
        {
        }

        public UnqualifiedPathException(string? message) : base(message)
        {
        }

        public UnqualifiedPathException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}