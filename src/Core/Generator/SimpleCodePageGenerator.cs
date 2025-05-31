using CMSCore.Abstraction;
using System.Text;

namespace CMSCore.Generator
{
    public class SimpleCodePageGenerator : IPageGenerator
    {
        public string GenerateCodePage(IPageContentProvider contentProvider)
		{
            if (contentProvider is not null)
            {
                var strBuilder = new StringBuilder();
                foreach (var c in contentProvider.GetComponents())
                {
                    strBuilder.AppendLine(c.GenerateCode());
                }

				return strBuilder.ToString();
            }

            throw new Exception();
        }
    }

}