namespace CMSRepository.Models
{
    public class HostConfiguration
    {
        public Guid HostId { get; set; }

        public Host Host { get; set; }

        public string GeneratedCodesDirectory { get; set; } = string.Empty;

        public string DomainAddress { get; set; } = string.Empty;
    }
}
