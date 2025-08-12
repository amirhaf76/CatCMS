using CMSCore.AppStructure.Abstraction;
using CMSCore.AppStructure.DTOs;

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

        public IFileStructureBuilder SetWorkingDirectoryToFirstOccurrenceFromRoot(string name)
        {
            var foundDirectory = FindFirstOccurrenceFromRoot(name);

            _workingDirectory = foundDirectory;

            return this;
        }

        public bool TrySetWorkingDirectoryToFirstOccurrenceFromRoot(string directoryName)
        {
            try
            {
                FindFirstOccurrenceFromRoot(directoryName);

                return true;
            }
            catch (FileSystemStructureNotFoundException)
            {

                return false;
            }
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


        public IFileStructureBuilder AddFilesLike(string path)
        {
            var structures = _fileSystem
                .GetFiles(path)
                .Select(filePath => new CopyFileStructure(filePath, _fileSystem.GetFileName(filePath)));

            _workingDirectory.AddChildren(structures);

            return this;
        }

        public IFileStructureBuilder AddFilesLike(IEnumerable<string> paths)
        {
            _workingDirectory.AddChildren(paths.Select(path => new CopyFileStructure(path, _fileSystem.GetFileName(path))));


            return this;
        }

        public IFileStructureBuilder AddFilesByNameFromPath(string path, IEnumerable<string> names)
        {
            var structures = _fileSystem.GetFilesByName(path, names)
                .Select(filePath => new CopyFileStructure(filePath, _fileSystem.GetFileName(filePath)));

            _workingDirectory.AddChildren(structures);

            return this;
        }


        public IFileStructureBuilder AddDirectoriesAndTheirFiles(string path, int maxRecursionDepth)
        {
            AddFilesLike(path);

            if (maxRecursionDepth > 0)
            {
                var subDirectories = _fileSystem.GetDirectories(path, 0);
                var nextRecursionDepth = maxRecursionDepth - 1;
                var currentWorkingDirectory = _workingDirectory;

                foreach (var subDirectory in subDirectories)
                {
                    AddDirectoryAndChangeWorkingDirectory(_fileSystem.GetFileName(subDirectory));

                    AddDirectoriesAndTheirFiles(subDirectory, nextRecursionDepth);

                    _workingDirectory = currentWorkingDirectory;
                }
            }

            return this;
        }


        public DirectoryStructureDto GetStructuresDto()
        {
            return (DirectoryStructureDto)_rootDirectory.ToDto();
        }


        public AppFileStructure Build()
        {
            return new AppFileStructure((DirectoryStructure)_rootDirectory.Copy());
        }



        private DirectoryStructure FindFirstOccurrenceFromRoot(string directoryName)
        {
            return FindFirstOccurrenceFrom(directoryName, _rootDirectory);
        }

        private static DirectoryStructure FindFirstOccurrenceFrom(string directoryName, DirectoryStructure theDirectory)
        {
            var targetStructure = new DirectoryStructureDto
            {
                Name = directoryName,
            };

            var fileStructure = (DirectoryStructure)DirectoryStructure.FindFirstOccurrenceFrom(targetStructure, theDirectory);

            return fileStructure;
        }
    }

}