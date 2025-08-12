namespace CMSApi
{
    public class HostVM
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public UserVM Creator { get; set; } = new UserVM();
    }
}