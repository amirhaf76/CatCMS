namespace CMSCore
{
	public class DirectoryStructure : BaseStructure
	{
		private readonly List<BaseStructure> _children = new List<BaseStructure>();
		private DirectoryStructure? _parent;

		public DirectoryStructure(string name, DirectoryStructure? parent = null) : base(name)
		{
			_parent = parent;
		}


		// Todo: clean it.
        public static BaseStructure FindFirstOccurrenceFrom(BaseStructureDto targetStructureDto, DirectoryStructure theDirectory)
		{
            var directoriesInTheDirectory = new List<DirectoryStructure>();

			foreach (var theStructure in theDirectory._children)
			{
                if (targetStructureDto.Type == theStructure.Type && targetStructureDto.Name == theStructure.Name)
                {
                    return theStructure;
                }

                if (theStructure.Type == StructureType.Directory)
                {
					directoriesInTheDirectory.Add((DirectoryStructure)theStructure);
                }
            }

			foreach (var theSubDirectory in directoriesInTheDirectory)
			{
				if (FindFirstOccurrenceFrom(targetStructureDto, theSubDirectory) is BaseStructure foundStructure)
				{
					return foundStructure;
				}
			}

			throw new FileSystemStructureNotFound();
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
				Name = Name,
				ParentName = _parent?.Name,
				Children = _children.Select(child => child.ToDto()).ToList(),
			};
		}

		public override StructureType Type => StructureType.Directory;

        public override BaseStructure Copy()
        {
			var newStructure = new DirectoryStructure(Name);

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