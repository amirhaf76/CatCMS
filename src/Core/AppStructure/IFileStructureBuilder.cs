namespace CMSCore
{
	public interface IFileStructureBuilder
    {
        IFileStructureBuilder AddDirectoryAndChangeWorkingDirectory(string name);
        IFileStructureBuilder AddDirectory(string name);
        IFileStructureBuilder SetWorkingDirectoryToRoot();

        IFileStructureBuilder AddFile(string name, string content);
        IFileStructureBuilder AddFile(FileStructureDto info);

        IFileStructureBuilder AddFiles(IEnumerable<FileStructureDto> infos);

        IFileStructureBuilder AddFileLike(string path);

        IFileStructureBuilder AddFilesLike(string directory);
        IFileStructureBuilder AddFilesLike(IEnumerable<string> paths);
        IFileStructureBuilder AddFilesByNameFromDirectory(string directory, IEnumerable<string> names);
    }
}