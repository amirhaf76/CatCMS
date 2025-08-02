using CMSCore.AppStructure.DTOs;
using CMSCore.AppStructure.Extensions;

namespace CMSCore
{
	public class DirectoryStructureBuilder : BaseStructureBuilder
    {
        private readonly DirectoryStructure _structure;
        public DirectoryStructureBuilder(string directory, DirectoryStructure structure) : base(directory)
        {
            _structure = structure;
        }


        public override IEnumerable<FileSystemInfo> BuildV2()
        {
            var structureDto = (DirectoryStructureDto)_structure.ToDto();

            var path = Path.Combine(_directory, structureDto.Name);

            var newFileDirectory = Directory.CreateDirectory(path);

            var newChildren = new List<FileSystemInfo>
            {
                newFileDirectory
            };

            if (_structure.HasChildren())
            {
                _structure.ForEachChild(structure =>
                {
                    var fileSystemInfos = structure.CreateStructureBuilder(path).BuildV2();

                    newChildren.AddRange(fileSystemInfos);
                });
            }

            return newChildren;
        }
    }
}