using CMSRepository.Models;

namespace CMSApi.Controllers
{
    public class RegisterResponse
    {
        public int Id { get; set; }

        public string Username { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public UserStatus Status { get; set; }
    }
}