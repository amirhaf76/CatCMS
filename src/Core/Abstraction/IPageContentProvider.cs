using CMSCore.Component;

namespace CMSCore.Abstraction
{
	public interface IPageContentProvider
    {
        List<ICMSComponent> GetComponents();
	}
}