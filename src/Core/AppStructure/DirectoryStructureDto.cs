using System.Text.Json.Serialization;

namespace CMSCore
{
	public class DirectoryStructureDto : BaseStructureDto
	{
        
		public string Name { get; set; } = string.Empty;
		public string? ParentName { get; set; }
		public List<BaseStructureDto> Children { get; set; } = new(); // list or enumerable
	}


}