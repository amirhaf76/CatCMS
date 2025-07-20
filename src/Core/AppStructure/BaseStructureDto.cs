using System.Text.Json.Serialization;

namespace CMSCore
{
	[JsonPolymorphic()]
	[JsonDerivedType(typeof(FileStructureDto), nameof(StructureType.File))]
	[JsonDerivedType(typeof(DirectoryStructureDto), nameof(StructureType.Directory))]
	[JsonDerivedType(typeof(CopyFileStructureDto), nameof(StructureType.CopyFile))]
	public abstract class BaseStructureDto
	{
		// Todo: A big Bug can occur
		public abstract StructureType Type { get; }

        public string Name { get; set; } = string.Empty;
    }
}