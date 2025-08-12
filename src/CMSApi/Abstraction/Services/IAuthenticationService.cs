using CMSApi.Abstraction.Services.DTOs;

namespace CMSApi.Abstraction.Services
{

    public interface IAuthenticationService
    {
        Task<string> GetTokenAsync(TokenDto userAccount);
        Task<string> GetRefreshToken(TokenDto userAccount);
        Task<RegisterResult> RegisterAsync(RegisterDto dto);


    }
}
