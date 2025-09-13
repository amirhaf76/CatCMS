namespace CMS.Persistence.Models
{
    public class Host
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public User Creator { get; set; } = new User();

        public string GeneratedCodesDirectory { get; set; } = string.Empty;

        public string DomainAddress { get; set; } = string.Empty;

    }
}
