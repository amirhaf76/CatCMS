using System.Security.Claims;

namespace CatCMS.Services
{
    public class AccountManagement : IAccountManagement
    {
        private readonly HttpClient _httpClient;

        public AccountManagement(HttpClient client)
        {
            _httpClient = client;
        }

        public Task<ClaimsPrincipal> LoginAsync()
        {
            throw new NotImplementedException();
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
