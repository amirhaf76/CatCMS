namespace CMSCore
{
	public class CopyFileStructure : BaseStructure
	{
		private readonly string _path;
		private readonly string _name;

		public CopyFileStructure(string path, string name)
		{
			_path = path;
			_name = name;
		}

		public override StructureType Type => StructureType.CopyFile;

		public override BaseStructureDto ToDto()
		{
			return new CopyFileStructureDto
			{
				Path = _path,
				Name = _name,
				Type = Type
			};
		}

        public override BaseStructure Copy()
        {
			return new CopyFileStructure(_path, _name);
        }
    }
}