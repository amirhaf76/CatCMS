using CMSCore.Component;

namespace CMSCore.Abstraction
{

    public class Page
    {
        public string Title { get; set; } = string.Empty;

        public Guid Id { get; set; }

        public List<ICMSComponent> Components { get; set; } = new List<ICMSComponent>();

        public ILayout Layout { get; set; } = new StackLayout();
    }

}