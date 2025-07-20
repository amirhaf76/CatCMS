using CMSCore.Abstraction;
using Fluid;
using System.Text;

namespace CMSCore.Generator
{
    public class FluidContentProvider : IPageContentProvider
    {
        private readonly FluidParser _parser;
        private string _source;
        private object _model;
        
        public FluidContentProvider()
        {
            _parser = new FluidParser();
            _source = string.Empty;
            _model = new object();
        }

        public FluidContentProvider Set(string source, object model)
        {
            _source = source;
            _model = model;
            return this;
        }

        public string GetContent()
        {
            var strBuilder = new StringBuilder();

            strBuilder.AppendLine(ParseLiquidFormat(_source, _model));


            return strBuilder.ToString();
        }

        public string ParseLiquidFormat(string source, object model)
        {
            var template = _parser.Parse(source);

            var context = new TemplateContext(model);

            return template.Render(context);
        }


    }

}