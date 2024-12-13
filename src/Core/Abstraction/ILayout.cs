
using System.Collections;
using Core.Enums;

namespace Core.Abstraction
{
    public interface ILayout
    {
        Guid Id { get; }

        LayoutKind Kind { get; }

        string ArrangeComponents(IEnumerable<string> componentsMarkdown);
    }
}