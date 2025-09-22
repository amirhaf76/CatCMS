using CMS.Application.Abstraction.Services;
using CMS.Application.Services.Exceptions;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace CMS.WebApi.Authentication
{
    public class UserProvider : IUserProvider
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserProvider(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public int UserId => GetUserIdFromHttpContext();

        private int GetUserIdFromHttpContext()
        {
            var id = GetClaimsPrincipalFromHttpContext()?.FindFirst(JwtRegisteredClaimNames.NameId)?.Value;

            if (int.TryParse(id, out int result))
            {
                return result;
            }

            throw new UserNotFoundException();
        }

        private ClaimsPrincipal? GetClaimsPrincipalFromHttpContext()
        {
            return _httpContextAccessor?.HttpContext?.User;
        }
    }
}
