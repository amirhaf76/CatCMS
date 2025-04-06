using System.Text;
using System.Text.Json;

namespace CMSCore.Abstraction
{
    public class StackLayout : ILayout, IStorable, IGeneratableToCode
    {

        public Guid Id { get; }

        public StackLayout(Guid id)
        {
            Id = id;
        }

        public StackLayout() : this(Guid.NewGuid())
        {
        }


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