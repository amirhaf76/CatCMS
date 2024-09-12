using Core.Abstraction;

namespace Core
{
    public class PageGenerator : IPageGenerator
    {
        public string Generate(Page page)
        {
            if (page is not null)
            {
                var componentsMarkDowns = page.Components.Select(c => c.Generate());

                return page.Layout.ArrangeComponents(componentsMarkDowns);
            }

            throw new Exception();
        }
    }




}