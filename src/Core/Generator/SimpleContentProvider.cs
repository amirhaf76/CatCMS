using CMSCore.Abstraction;
using System.Text;

namespace CMSCore.Generator
{
    public class SimpleContentProvider : IPageContentProvider
    {
        private string _content;
        public SimpleContentProvider(string content)
        {
            _content = content;
        }

        public string GetContent()
        {
            var strBuilder = new StringBuilder();

            strBuilder.AppendLine(_content);

            return strBuilder.ToString();
           
        }
    }
}