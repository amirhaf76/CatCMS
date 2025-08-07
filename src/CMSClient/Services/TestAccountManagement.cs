using CMSClient.Services.Abstraction;
using CMSClient.Services.Abstraction.DTOs;
using System.Security.Claims;

namespace CMSClient.Services
{
    public class TestAccountManagement : IAccountManagement
    {
        public Task<ClaimsPrincipal> LoginAsync(LoginDto loginDto)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, "User number 1"),
                new Claim(ClaimTypes.NameIdentifier, "1"),
                new Claim(ClaimTypes.Role, "admin"),
            };
            var id = new ClaimsIdentity(claims, nameof(TestAccountManagement), ClaimTypes.Name, ClaimTypes.Role);

            return Task.FromResult(new ClaimsPrincipal(id));
        }

        public void LogOut()
        {
            throw new NotImplementedException();
        }

        public Task<string> RegisterAsync()
        {
            throw new NotImplementedException();
        }
    }
}
