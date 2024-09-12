using Core.Enums;

namespace Core.Abstraction
{
    public interface IComponentBuilder
    {
        ICatCMSComponent CreateComponent(CatCMSComponentType type);
    }
}