using Core.Abstraction;
using Core.Enums;

namespace Core
{
    internal class ComponentBuilder : IComponentBuilder
    {
        public ICatCMSComponent CreateComponent(CatCMSComponentType type) => type switch
        {
            CatCMSComponentType.CarouselCatComponent => new CarouselCatComponent(),
            _ => throw new Exception($"This \"{type}\" type is not valid"),
        };
    }
}