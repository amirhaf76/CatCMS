namespace CMSCore.Component
{
    public class NavigationItemComponent : BaseComponent
    {
        public bool HasDropDown { get; set; } = false;
        public string AspPage { get; set; } = string.Empty;
        public string HRef { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;

        public IEnumerable<NavigationItemComponent> Children { get; set; } = Enumerable.Empty<NavigationItemComponent>();


    }
}