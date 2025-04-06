using CMSCore.Abstraction;

namespace CMSCore.Component
{
    public class ComponentFactory : IComponentFactory
    {
        public ICMSComponent CreateComponent(CatCMSComponentType type) => type switch
        {
            CatCMSComponentType.CarouselCatComponent => new CarouselCatComponent(),
            _ => throw new Exception($"This \"{type}\" type is not valid"),
        };

        public ICMSComponent CreateDefaultComponent()
        {
            return new DefaultComponent();
        }
    }
}