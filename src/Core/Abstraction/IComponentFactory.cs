namespace CMSCore.Abstraction
{
    public interface IComponentFactory
    {
        ICMSComponent CreateComponent(CatCMSComponentType type);
        ICMSComponent CreateDefaultComponent();
    }
}