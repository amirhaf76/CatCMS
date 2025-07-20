namespace CMSCore
{
	public interface IFileStructureBuilder
    {
        IFileStructureBuilder AddDirectoryAndChangeWorkingDirectory(string name);
        IFileStructureBuilder AddDirectory(string name);
        IFileStructureBuilder SetWorkingDirectoryToRoot();
        IFileStructureBuilder SetWorkingDirectoryToFirstOccurrenceFromRoot(string directoryName);
        bool TrySetWorkingDirectoryToFirstOccurrenceFromRoot(string directoryName);

        IFileStructureBuilder AddFile(string name, string content);
        IFileStructureBuilder AddFile(FileStructureDto info);

        IFileStructureBuilder AddFiles(IEnumerable<FileStructureDto> infos);

        IFileStructureBuilder AddFileLike(string path);

        IFileStructureBuilder AddFilesLike(string path);
        IFileStructureBuilder AddFilesLike(IEnumerable<string> paths);
        IFileStructureBuilder AddFilesByNameFromPath(string path, IEnumerable<string> names);

        IFileStructureBuilder AddDirectoriesAndTheirFiles(string path, int maxRecursionDepth);


        AppFileStructure Build();
    }
}