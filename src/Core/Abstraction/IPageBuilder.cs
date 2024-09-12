using Core.Enums;

namespace Core.Abstraction
{
    public interface IPageBuilder
    {
        IPageBuilder AddComponent(CatCMSComponentType carouselCatComponent);
        IPageBuilder AddLayout(ILayout layout);
    }
}