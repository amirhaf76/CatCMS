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

			using var destination = File.CreateText(Path.Combine(_directory, dto.Name));
            using var source = File.OpenText(dto.Path);

            destination.Write(source.ReadToEnd());
            destination.Flush();
        }
    }
}