namespace CMSCore.Component
{
    public interface IComponentFactory
    {
        ICMSComponent CreateComponent(CatCMSComponentType type);
        ICMSComponent CreateDefaultComponent();
    }
}