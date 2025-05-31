namespace CMSCore.Component
{
	public class NavigationComponent : BaseComponent
	{
		public string Logo { get; set; } = string.Empty;

		public string LogoHRef { get; set; } = string.Empty;

		public List<BaseComponent> NavbarStart { get; set; } = new List<BaseComponent>();

		public List<BaseComponent> NavbarEnd { get; set; } = new List<BaseComponent>();

	}
}