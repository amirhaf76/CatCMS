
using CMSCore.AppStructure.DTOs;

namespace CMSCore
{
    public class FileStructureBuilder : BaseStructureBuilder
    {
        private readonly FileStructure _structure;

        public FileStructureBuilder(string directory, FileStructure structure) : base(directory)
        {
            _structure = structure;
        }
        public override IEnumerable<FileSystemInfo> Build()
        {
            var dto = (FileStructureDto)_structure.ToDto();

            var path = Path.Combine(_directory, dto.Name);

            using var aFile = File.CreateText(path);

            aFile.Write(dto.Content);

            aFile.Flush();

            return new List<FileSystemInfo> { new FileInfo(path) };
        }
    }
}