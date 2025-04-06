using CMSCore.Abstraction;
using Fluid;

namespace CMSCore.Generator
{
    public class CodePageGenerator : ICodePageGenerator
    {
        private readonly FluidParser _parser;


        public CodePageGenerator()
        {
            _parser = new FluidParser();
        }

        public string GenerateCodePage(Page page)
        {
            if (page is not null)
            {
                var componentsMarkDowns = page.Components.Select(c =>
                {
                    var source = c.GenerateCode();
                    var model = c;

                    return ParseLiquidFormat(source, model);
                });

                return page.Layout.ArrangeComponents(componentsMarkDowns);
            }

            throw new Exception();
        }

        public string ParseLiquidFormat(string source, object model)
        {
            var template = _parser.Parse(source);

            var context = new TemplateContext(model);

            return template.Render(context);
        }


    }

}