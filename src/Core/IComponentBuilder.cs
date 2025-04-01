using CMSCore.Abstraction;

namespace CMSCore
{
    public interface IComponentBuilder
    {
        ICatCMSComponent CreateComponent(CatCMSComponentType type);
    }
}