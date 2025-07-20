namespace CMSCore
{
	public class CopyFileStructureDto : BaseStructureDto
	{
		public string Path { get; set; } = string.Empty;

        public override StructureType Type => StructureType.CopyFile;

    }
}