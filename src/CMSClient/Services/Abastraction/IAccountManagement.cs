using CMSClient.Services.Abstraction.DTOs;
using System.Security.Claims;

namespace CMSClient.Services.Abstraction
{
    public interface IAccountManagement
    {
        Task<ClaimsPrincipal> LoginAsync(LoginDto loginDto);

        Task<string> RegisterAsync();

        void LogOut();
    }
}
