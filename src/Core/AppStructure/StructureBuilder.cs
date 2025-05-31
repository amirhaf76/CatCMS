namespace CMSCore
{
	public abstract class StructureBuilder
    {
        protected readonly string _directory;

        public StructureBuilder(string directory)
        {
            _directory = directory;
        }

        public abstract void Build();

        public static StructureBuilder CreateStructureBuilder(BaseStructure structure, string directory)
        {
            return structure.Type switch
            {
                StructureType.File => new FileStructureBuilder(directory, (FileStructure)structure),
                StructureType.Directory => new DirectoryStructureBuilder(directory, (DirectoryStructure)structure),
                StructureType.CopyFile => new CopyFileStructureBuilder(directory, (CopyFileStructure)structure),
                _ => throw new NotImplementedException(),
            };
        }
    }
}