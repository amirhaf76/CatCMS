namespace CMSRepository.Models
{
    public class Host
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public User Creator { get; set; } = new User();

        public HostConfiguration Configuration { get; set; } = new HostConfiguration();
    }
}
