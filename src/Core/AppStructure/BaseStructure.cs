using System.Text;

namespace CMSCore
{
	public abstract class BaseStructure
    {
        public abstract StructureType Type { get; }

        public abstract BaseStructureDto ToDto();
	}
}