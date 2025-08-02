using System.Security.Claims;

namespace CatCMS.Services
{
    public interface IAccountManagement
    {
        Task<ClaimsPrincipal> LoginAsync();

        Task<string> RegisterAsync();

        void LogOut();
    }
}
