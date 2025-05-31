using System.Text.Json.Serialization;

namespace CMSCore
{
	[JsonPolymorphic()]
	[JsonDerivedType(typeof(FileStructureDto), nameof(StructureType.File))]
	[JsonDerivedType(typeof(DirectoryStructureDto), nameof(StructureType.Directory))]
	[JsonDerivedType(typeof(CopyFileStructureDto), nameof(StructureType.CopyFile))]
	public class BaseStructureDto
	{
		public StructureType Type { get; set; }
	}


}