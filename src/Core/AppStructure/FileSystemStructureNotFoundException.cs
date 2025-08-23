using System.Runtime.Serialization;

namespace CMSCore
{
    [Serializable]
    internal class FileSystemStructureNotFoundException : Exception
    {
        public FileSystemStructureNotFoundException()
        {
        }

        public FileSystemStructureNotFoundException(string? message) : base(message)
        {
        }

        public FileSystemStructureNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}