using CMSCore.AppStructure.Abstraction;

namespace CMSCore.AppStructure.Extensions
{
    public static class BaseStructureExtension
    {
        public static BaseStructureBuilder CreateStructureBuilder(this BaseStructure structure, string directory)
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