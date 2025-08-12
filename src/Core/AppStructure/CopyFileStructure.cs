using CMSCore.AppStructure.Abstraction;
using CMSCore.AppStructure.Abstractions;
using CMSCore.AppStructure.DTOs;

namespace CMSCore
{
    public class CopyFileStructure : BaseStructure
    {
        private readonly string _path;

        public CopyFileStructure(string path, string name) : base(name)
        {
            _path = path;
        }

        public override StructureType Type => StructureType.CopyFile;

        public override BaseStructureDto ToDto()
        {
            return new CopyFileStructureDto
            {
                Path = _path,
                Name = Name,
            };
        }

        public override BaseStructure Copy()
        {
            return new CopyFileStructure(_path, Name);
        }
    }
}