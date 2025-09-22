using System.Security.Claims;

namespace CMS.Application.Behaviors
{
    public interface IJWTTokenProvider
    {
        string GenerateToken(string privateKey, string issuer, string audience, IEnumerable<Claim> claims);

        ClaimsPrincipal ValidateToken(string token, string publicKey, string issuer, string audience);
        ClaimsPrincipal ValidateToken(string token,
                                      string publicKey,
                                      string issuer,
                                      string audience,
                                      IJWTTokenExceptionHandler handler);


    }
}
