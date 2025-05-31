using CMSCore.Abstraction;
using Fluid;
using System.Text;

namespace CMSCore.Generator
{
    public class CodePageGenerator : IPageGenerator
    {
        private readonly FluidParser _parser;


        public CodePageGenerator()
        {
            _parser = new FluidParser();
        }

        public string GenerateCodePage(IPageContentProvider? contentProvider)
		{
            if (contentProvider is not null)
            {
				var strBuilder = new StringBuilder();

				foreach (var c in contentProvider.GetComponents())
				{
					var source = c.GenerateCode();
					var model = c;

					strBuilder.AppendLine(ParseLiquidFormat(source, model));
				}

                return strBuilder.ToString();
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