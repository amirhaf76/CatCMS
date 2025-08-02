using CMSCore.AppStructure.Abstraction;
using CMSCore.AppStructure.Abstractions;

namespace CMSCore.AppStructure.DTOs
{
    public class FileStructureDto : BaseStructureDto
    {
        public string Content { get; set; } = string.Empty;

        public override StructureType Type => StructureType.File;
    }
}