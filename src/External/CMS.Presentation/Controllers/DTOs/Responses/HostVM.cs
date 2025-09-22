namespace CMS.Presentation.Controllers.DTOs.Responses
{
    public class HostVM
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string GeneratedCodesDirectory { get; set; } = string.Empty;

        public string DomainAddress { get; set; } = string.Empty;

    }
}