namespace CMSCore
{
	public class DirectoryStructureBuilder : StructureBuilder
    {
        private readonly DirectoryStructure _structure;
        public DirectoryStructureBuilder(string directory, DirectoryStructure structure) : base(directory)
        {
            _structure = structure;
        }

        public override void Build()
        {
			var structureDto = (DirectoryStructureDto)_structure.ToDto();

			Directory.CreateDirectory(Path.Combine(_directory, structureDto.Name));

            if (_structure.HasChildren())
            {
                _structure.ForEachChild(structure =>
                {
					CreateStructureBuilder(structure, Path.Combine(_directory, structureDto.Name)).Build();
                });
            }
        }
    }
}