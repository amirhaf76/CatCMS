namespace CMSCore
{
	public class FileSystem : IFileSystem
	{
		public IEnumerable<string> AddFilesLike(string directory, IEnumerable<string> names)
		{
			return Directory.GetFiles(directory).Intersect(names);
		}

		public IEnumerable<string> GetFiles(string directory)
		{
			return Directory.GetFiles(directory);
		}

		public IEnumerable<string> GetFilesByName(string directory, IEnumerable<string> names)
		{
			return Directory.GetFiles(directory).Intersect(names);
		}

		public string GetFileName(string path)
		{
			return Path.GetFileName(path);
		}

		public string CombinePath(params string[] paths)
		{
			return Path.Combine(paths);
		}
	}

}