namespace CMSCore
{
	public class CopyFileStructureBuilder : StructureBuilder
    {
        private readonly CopyFileStructure _structure;

        public CopyFileStructureBuilder(string directory, CopyFileStructure structure) : base(directory)
        {
            _structure = structure;
        }

        public override void Build()
        {
            var dto = (CopyFileStructureDto)_structure.ToDto();

            File.Copy(dto.Path, Path.Combine(_directory, dto.Name), true);
        }
    }
}