namespace CMSApi
{
    public class UserVM
    {
        public int Id { get; set; }

        public string Username { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public UserStatusVM Status { get; set; }
    }
}