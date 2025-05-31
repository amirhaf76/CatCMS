namespace CMSCore.Component
{
	public class HtmlPage
	{
		public Guid Id { get; set; }

		public string Title { get; set; } = string.Empty;
		public string JsFile { get; set; } = string.Empty;
		public NavigationComponent? Navbar { get; set; }
		public IEnumerable<BaseComponent> PageContent { get; set; } = Enumerable.Empty<BaseComponent>();
		public FooterComponent? Footer { get; set; }
		public IEnumerable<ModalComponent> Modals { get; set; } = Enumerable.Empty<ModalComponent>();


	}
}