namespace CMSCore
{
	public class FileStructure : BaseStructure
	{
		public const int CONTENT_PRESENTATION_LIMIT = 300;

		private readonly string _name;
		private readonly string _content;

		public FileStructure(string name, string content)
		{
			_name = name;
			_content = content;
		}

		public override StructureType Type => StructureType.File;

		public override BaseStructureDto ToDto()
		{
			return new FileStructureDto
			{
				Type = Type,
				Name = _name,
				Content = _content,
			};
		}
	}
}