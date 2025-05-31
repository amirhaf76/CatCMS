namespace CMSCore
{

	public class AppFileStructureBuilder : IFileStructureBuilder
	{
		private readonly DirectoryStructure _rootDirectory;
		private readonly IFileSystem _fileSystem;
		private DirectoryStructure _workingDirectory;

		public AppFileStructureBuilder(string directoryName, IFileSystem fileSystem)
		{
			_rootDirectory = new DirectoryStructure(directoryName);
			_workingDirectory = _rootDirectory;
			_fileSystem = fileSystem;
		}

		public AppFileStructureBuilder(string directoryName, IFileSystem fileSystem, AppFileStructureBuilder builder) : this(directoryName, fileSystem)
		{
			var children = new List<BaseStructure>();

			builder._rootDirectory.ForEachChild(children.Add);

			_rootDirectory.AddChildren(children);
		}

		public IFileStructureBuilder AddDirectory(string name)
		{
			var aDirectoryStructure = new DirectoryStructure(name, _workingDirectory);

			_workingDirectory.AddChild(aDirectoryStructure);

			return this;
		}

		public IFileStructureBuilder AddDirectoryAndChangeWorkingDirectory(string name)
		{
			var aDirectoryStructure = new DirectoryStructure(name, _workingDirectory);

			_workingDirectory.AddChild(aDirectoryStructure);

			_workingDirectory = aDirectoryStructure;

			return this;
		}

		public IFileStructureBuilder SetWorkingDirectoryToRoot()
		{
			_workingDirectory = _rootDirectory;

			return this;
		}

		public IFileStructureBuilder AddFile(string name, string content)
		{
			_workingDirectory.AddChild(new FileStructure(name, content));

			return this;
		}
		public IFileStructureBuilder AddFile(FileStructureDto info)
		{
			return AddFile(info.Name, info.Content);
		}

		public IFileStructureBuilder AddFiles(IEnumerable<FileStructureDto> infos)
		{
			_workingDirectory.AddChildren(infos.Select(info => new FileStructure(info.Name, info.Content)));

			return this;
		}

		public IFileStructureBuilder AddFileLike(string path)
		{

			_workingDirectory.AddChild(new CopyFileStructure(path, _fileSystem.GetFileName(path)));

			return this;
		}

		public IFileStructureBuilder AddFilesLike(string directory)
		{
			var structures = _fileSystem
				.GetFiles(directory)
				.Select(fileName => new CopyFileStructure(_fileSystem.CombinePath(directory, fileName), _fileSystem.GetFileName(fileName)));


			_workingDirectory.AddChildren(structures);

			return this;
		}
		public IFileStructureBuilder AddFilesLike(IEnumerable<string> paths)
		{
			_workingDirectory.AddChildren(paths.Select(path => new CopyFileStructure(path, _fileSystem.GetFileName(path))));


			return this;
		}
		public IFileStructureBuilder AddFilesByNameFromDirectory(string directory, IEnumerable<string> names)
		{
			var structures = _fileSystem.GetFilesByName(directory, names)
				.Select(fileName => new CopyFileStructure(_fileSystem.CombinePath(directory, fileName), _fileSystem.GetFileName(fileName)));

			_workingDirectory.AddChildren(structures);

			return this;
		}

		public DirectoryStructureDto GetStructuresDto()
		{
			return (DirectoryStructureDto)_rootDirectory.ToDto();
		}

		public void Build(string path)
		{
			new DirectoryStructureBuilder(path, _rootDirectory).Build();
		}
	}

}