namespace CMSCore.Component
{
	public class ModalComponent : BaseComponent
	{
		public Guid ModalId { get; set; } = Guid.Empty;

		public string Content { get; set; } = string.Empty;

	}
}