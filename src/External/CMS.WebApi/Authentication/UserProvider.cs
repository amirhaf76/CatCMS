using CMS.Application.Abstraction.Services;
using CMS.Application.Services.Exceptions;
using CMS.Domain.ValueObjects;
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

        public int UserId => GetUserIdFromHttpContext().Value;

        public UserId UserIdV2 => GetUserIdFromHttpContext();

        private UserId GetUserIdFromHttpContext()
        {
            var id = GetClaimsPrincipalFromHttpContext()?.FindFirst(JwtRegisteredClaimNames.NameId)?.Value;

            if (int.TryParse(id, out int result))
            {
                return Domain.ValueObjects.UserId.Create(result);
            }

            throw new UserNotFoundException();
        }

        private ClaimsPrincipal? GetClaimsPrincipalFromHttpContext()
        {
            return _httpContextAccessor?.HttpContext?.User;
        }
    }
}
