namespace CMSCore.Abstraction
{
    // todo: changing namespace because it is useed in Abstraction.
    public interface ILayout
    {
        Guid Id { get; }

        string ArrangeComponents(IEnumerable<string> componentsMarkdown);
    }
}