using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace Infrastructure.JWTService.Abstractions
{
    public interface IJWTTokenService
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
