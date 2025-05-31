using CMSCore.Component;

namespace CMSCore.Abstraction
{
	public class PageContentProvider : IPageContentProvider
	{
        public List<ICMSComponent> Components { get; set; } = new List<ICMSComponent>();

		public List<ICMSComponent> GetComponents()
		{
            return Components;
		}
	}
}