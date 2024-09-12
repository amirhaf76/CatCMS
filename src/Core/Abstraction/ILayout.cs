
using System.Collections;
using System.Text;
using Core.Enums;

namespace Core.Abstraction
{
    public interface ILayout
    {
        Guid Id { get; }

        LayoutKind Kind { get; }

        string ArrangeComponents(IEnumerable<string> componentsMarkdown);
    }

    public class StackLayout : ILayout
    {
        private List<ICatCMSComponent> _components;

        public Guid Id { get; }

        public StackLayout(Guid id)
        {
            Id = id;

            _components = new List<ICatCMSComponent>();
        }

        public StackLayout() : this(Guid.NewGuid())
        {
        }

        public LayoutKind Kind => LayoutKind.Stack;

        public string ArrangeComponents(IEnumerable<string> componentMarkdowns)
        {
            var strBuilder = new StringBuilder();

            foreach (var c in componentMarkdowns.Reverse())
            {
                strBuilder.Append(c);
            }

            return strBuilder.ToString();
        }
    }
}