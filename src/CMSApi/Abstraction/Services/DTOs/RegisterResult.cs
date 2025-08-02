using CMSRepository.Models;

namespace CMSApi.Abstraction.Services.DTOs
{
    public class RegisterResult
    {
        public int Id { get; set; }

        public string Username { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public UserStatus Status { get; set; }
    }
}