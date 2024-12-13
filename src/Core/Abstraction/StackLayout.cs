using System.Text;
using System.Text.Json;
using Core.Enums;

namespace Core.Abstraction
{
    public class StackLayout : ILayout, IStorable, IGeneratableToCode
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

        public JsonElement Store()
        {
            throw new NotImplementedException();
        }

        public string GenerateCode()
        {
            throw new NotImplementedException();
        }
    }
}