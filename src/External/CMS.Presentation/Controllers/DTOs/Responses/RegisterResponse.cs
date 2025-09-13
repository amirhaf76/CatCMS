using CMS.Domain.ValueObjects;

namespace CMS.Presentation.Controllers.DTOs.Responses.Controllers.DTOs.Responses
{
    public class RegisterResponse
    {
        public int Id { get; set; }

        public string Username { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public UserStatus Status { get; set; }
    }
}