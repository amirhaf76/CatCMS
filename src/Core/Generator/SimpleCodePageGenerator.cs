using CMSCore.Abstraction;

namespace CMSCore.Generator
{
    public class SimpleCodePageGenerator : ICodePageGenerator
    {
        public string GenerateCodePage(Page page)
        {
            if (page is not null)
            {
                var componentsMarkDowns = page.Components.Select(c => c.GenerateCode());

                return page.Layout.ArrangeComponents(componentsMarkDowns);
            }

            throw new Exception();
        }
    }

}