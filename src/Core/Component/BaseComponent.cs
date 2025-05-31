
namespace CMSCore.Component
{
	public class BaseComponent : ICMSComponent
	{
		public Guid Id { get; set; }

		public string GenerateCode()
		{
			throw new NotImplementedException();
		}
	}
}