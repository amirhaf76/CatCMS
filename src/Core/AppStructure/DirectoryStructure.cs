namespace CMSCore
{
	public class DirectoryStructure : BaseStructure
	{
		private readonly string _name = string.Empty;
		private readonly List<BaseStructure> _children = new List<BaseStructure>();
		private DirectoryStructure? _parent;

		public DirectoryStructure(string name, DirectoryStructure? parent = null)
		{
			_name = name;
			_parent = parent;
		}

		public DirectoryStructure AddChild(BaseStructure structure)
		{
			_children.Add(structure);

			return this;
		}

		public DirectoryStructure AddChildren(IEnumerable<BaseStructure> structures)
		{
			_children.AddRange(structures);

			return this;
		}

		public bool HasParent()
		{
			return _parent is not null;
		}

		public bool HasChildren()
		{
			return _children.Any();
		}

		public void ForEachChild(Action<BaseStructure> action)
		{
			foreach (var child in _children)
			{
				action.Invoke(child);
			}
		}

		public override BaseStructureDto ToDto()
		{
			return new DirectoryStructureDto
			{
				Type = Type,
				Name = _name,
				ParentName = _parent?._name,
				Children = _children.Select(child => child.ToDto()).ToList(),
			};
		}

		public override StructureType Type => StructureType.Directory;

        public override BaseStructure Copy()
        {
			var newStructure = new DirectoryStructure(_name);

			var newChilderen = _children.Select(c =>
			{
				var copyInstance = c.Copy();

				if (GetType().IsInstanceOfType(c))
				{
					var dirCopyInstance = (DirectoryStructure)copyInstance;

					dirCopyInstance._parent = newStructure;
				}

				return copyInstance;
			}).ToList();

			return newStructure.AddChildren(newChilderen); ;
        }

	}


}