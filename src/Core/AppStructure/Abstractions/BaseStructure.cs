using CMSCore.AppStructure.Abstractions;
using System.Text;

namespace CMSCore.AppStructure.Abstraction
{
	public abstract class BaseStructure
    {
        protected BaseStructure(string name)
        {
            Name = name;
        }



        public string Name { get; private set; } 



        public abstract StructureType Type { get; }



        public abstract BaseStructureDto ToDto();

        public abstract BaseStructure Copy();
	}
}