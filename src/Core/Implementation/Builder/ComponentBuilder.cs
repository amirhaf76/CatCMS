using Core.Abstraction;
using Core.Enums;
using Core.Implementation.Component;

namespace Core.Implementation.Builder
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