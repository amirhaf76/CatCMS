using CMSCore.AppStructure.Abstraction;
using CMSCore.AppStructure.Abstractions;
using CMSCore.AppStructure.DTOs;

namespace CMSCore
{
    public class FileStructure : BaseStructure
    {
        public const int CONTENT_PRESENTATION_LIMIT = 300;

        private readonly string _content;

        public FileStructure(string name, string content) : base(name)
        {
            _content = content;
        }

        public override StructureType Type => StructureType.File;

        public override BaseStructureDto ToDto()
        {
            return new FileStructureDto
            {
                Name = Name,
                Content = _content,
            };
        }

        public override BaseStructure Copy()
        {
            return new FileStructure(Name, _content);
        }
    }
}