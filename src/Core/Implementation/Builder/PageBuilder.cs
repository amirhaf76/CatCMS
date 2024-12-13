using Core.Abstraction;
using Core.Enums;
using System.Text;

namespace Core.Implementation.Builder
{
    public class PageBuilder : IPageBuilder
    {
        private readonly Page _page;
        private readonly IComponentBuilder _componentBuilder;

        public PageBuilder(Page page, IComponentBuilder componentBuilder)
        {
            _page = page;
            _componentBuilder = componentBuilder;
        }

        public IPageBuilder AddComponent(CatCMSComponentType type)
        {
            var aComponent = _componentBuilder.CreateComponent(type);

            _page.AddComponent(aComponent);

            return this;
        }

        public IPageBuilder AddLayout(ILayout layout)
        {
            _page.SetLayout(layout);

            return this;
        }
    }
}