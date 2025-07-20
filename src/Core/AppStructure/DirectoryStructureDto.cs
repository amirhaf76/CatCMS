using System.Text.Json.Serialization;

namespace CMSCore
{
	public class DirectoryStructureDto : BaseStructureDto
	{
		public string? ParentName { get; set; }
		public IEnumerable<BaseStructureDto> Children { get; set; } = Enumerable.Empty<BaseStructureDto>(); // list or enumerable

        public override StructureType Type => StructureType.Directory;
    }


}