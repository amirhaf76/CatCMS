namespace CMSCore
{
	public class FileStructureBuilder : StructureBuilder
    {
        private readonly FileStructure _structure;

        public FileStructureBuilder(string directory, FileStructure structure) : base(directory)
        {
            _structure = structure;
        }

        public override void Build()
        {
            var dto = (FileStructureDto)_structure.ToDto();

            using var aFile = File.CreateText(Path.Combine(_directory, dto.Name));

            aFile.Write(dto.Content);
            aFile.Flush();
        }
    }
}