using CMSCore.AppStructure.Abstraction;
using CMSCore.AppStructure.Abstractions;

namespace CMSCore.AppStructure.DTOs
{
    public class DirectoryStructureDto : BaseStructureDto
    {
        public string? ParentName { get; set; }
        public IEnumerable<BaseStructureDto> Children { get; set; } = Enumerable.Empty<BaseStructureDto>(); // list or enumerable

        public override StructureType Type => StructureType.Directory;
    }


}