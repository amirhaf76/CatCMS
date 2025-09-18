using CMS.Client.Services.Abstraction.DTOs;
using System.Security.Claims;

namespace CMS.Client.Services.Abstraction
{
    public interface IAccountManagement
    {
        Task<ClaimsPrincipal> LoginAsync(LoginDto loginDto);

        Task<string> RegisterAsync();

        void LogOut();
    }
}
