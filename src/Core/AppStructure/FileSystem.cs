namespace CMSCore
{
    public class FileSystem : IFileSystem
    {
		public IEnumerable<string> AddFilesLike(string path, IEnumerable<string> names)
		{
			return Directory.GetFiles(path).Intersect(names);
		}

		public IEnumerable<string> GetFiles(string path)
		{
			return Directory.GetFiles(path);
		}

		public IEnumerable<string> GetFilesByName(string path, IEnumerable<string> names)
		{
			return Directory.GetFiles(path).Intersect(names);
		}

		public string GetFileName(string path)
		{
			return Path.GetFileName(path);
		}

		public string CombinePath(params string[] paths)
		{
			return Path.Combine(paths);
		}

        public IEnumerable<string> GetDirectories(string path, int maxRecursionDepth)
        {
            return Directory
                .EnumerateDirectories(path, "*", new EnumerationOptions { RecurseSubdirectories = true, MaxRecursionDepth = maxRecursionDepth });
        }
    }

}