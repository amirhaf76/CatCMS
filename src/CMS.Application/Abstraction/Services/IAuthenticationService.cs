using CMS.Application.Abstraction.Services.DTOs;

namespace CMS.Application.Abstraction.Services
{
    
    public interface IAuthenticationService
    {
        Task<string> GetTokenAsync(TokenRequestDto userAccount);
        Task<string> GetRefreshToken(TokenRequestDto userAccount);
        Task<RegisterResult> RegisterAsync(RegisterRequestDto dto);


    }
}
