using CMSCore.AppStructure.Abstraction;
using CMSCore.AppStructure.Abstractions;

namespace CMSCore.AppStructure.DTOs
{
	public class CopyFileStructureDto : BaseStructureDto
	{
		public string Path { get; set; } = string.Empty;

        public override StructureType Type => StructureType.CopyFile;

    }
}