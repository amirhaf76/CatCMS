namespace CMSClient.Services.Abstraction.DTOs
{
    public class LoginDto
    {
        public string Password { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
    }
}