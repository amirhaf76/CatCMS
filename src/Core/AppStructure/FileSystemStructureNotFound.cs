using System.Runtime.Serialization;

namespace CMSCore
{
    [Serializable]
    internal class FileSystemStructureNotFound : Exception
    {
        public FileSystemStructureNotFound()
        {
        }

        public FileSystemStructureNotFound(string? message) : base(message)
        {
        }

        public FileSystemStructureNotFound(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected FileSystemStructureNotFound(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}