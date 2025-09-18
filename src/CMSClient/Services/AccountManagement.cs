using CMS.Client.Services.Abstraction;
using CMS.Client.Services.Abstraction.DTOs;
using CMS.Client.Services.Exceptions;
using CMS.Client.Services.Extensions;
using Infrastructure.GeneratedAPIs.CMSAPI;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;

namespace CMS.Client.Services
{
    public class AccountManagement : IAccountManagement
    {
        private readonly IAuthenticationClient _authenticationClient;
        private readonly ILogger<AccountManagement> _logger;

        public AccountManagement(IAuthenticationClient authenticationClient, ILogger<AccountManagement> logger)
        {
            _authenticationClient = authenticationClient;
            _logger = logger;
        }

        public async Task<ClaimsPrincipal> LoginAsync(LoginDto loginDto)
        {
            var aBodyRequest = loginDto.ToRequest();

            _logger.LogInformation("login {0}, {1}", loginDto.Username, loginDto.Password);
            var theTokenResponse = await _authenticationClient.PostLoginAsync(aBodyRequest);

            if ((HttpStatusCode)theTokenResponse.StatusCode != HttpStatusCode.OK)
            {
                throw new UnsuccessfullAuthenticationException();
            }
            var aJwtTokenHandler = new JwtSecurityTokenHandler();

            var theJwtToken = aJwtTokenHandler.ReadJwtToken(theTokenResponse.Result);

            var id = new ClaimsIdentity(theJwtToken.Claims, "TokenBase", "name", ClaimTypes.Role);

            return new ClaimsPrincipal(id);
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
