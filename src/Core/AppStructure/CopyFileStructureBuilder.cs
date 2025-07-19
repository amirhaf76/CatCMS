
namespace CMSCore
{
	public class CopyFileStructureBuilder : StructureBuilder
    {
        private readonly CopyFileStructure _structure;

        public CopyFileStructureBuilder(string directory, CopyFileStructure structure) : base(directory)
        {
            _structure = structure;
        }

        public override IEnumerable<FileSystemInfo> BuildV2()
        {
            var dto = (CopyFileStructureDto)_structure.ToDto();

            var path = Path.Combine(_directory, dto.Name);

            File.Copy(dto.Path, path, true);

            return new List<FileSystemInfo> { new FileInfo(path) };
        }
    }
}