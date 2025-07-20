namespace CMSCore
{
	public class FileStructureDto : BaseStructureDto
	{
		public string Content { get; set; } = string.Empty;

		public override StructureType Type => StructureType.File;
    }
}