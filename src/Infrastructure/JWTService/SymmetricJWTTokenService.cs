using Infrastructure.JWTService.Abstractions;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Infrastructure.JWTService
{
    public class SymmetricJWTTokenService : IJWTTokenService
    {
        public string GenerateToken(string privateKey, string issuer, string audience, IEnumerable<Claim> claims)
        {
            var securityKey = new SymmetricSecurityKey(Convert.FromBase64String(privateKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = issuer,
                Audience = audience,
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = credentials,
            };

            var jwtTokenHandler = new JwtSecurityTokenHandler();

            var token = jwtTokenHandler.CreateToken(tokenDescriptor);

            return jwtTokenHandler.WriteToken(token);
        }

        public ClaimsPrincipal ValidateToken(string token, string publicKey, string issuer, string audience)
        {
            return ValidateToken(token, publicKey, issuer, audience, null);
        }

        public ClaimsPrincipal ValidateToken(string token, string publicKey, string issuer, string audience, IJWTTokenExceptionHandler? handler)
        {
            var key = Convert.FromBase64String(publicKey);

            var securityKey = new SymmetricSecurityKey(key);

            var tokenValidationParameter = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = securityKey,
                ValidateIssuer = true,
                ValidIssuer = issuer,
                ValidateAudience = true,
                ValidAudience = audience,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero,
            };

            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();

                var claimsPrincipal = tokenHandler.ValidateToken(token, tokenValidationParameter, out _);

                return claimsPrincipal;
            }
            catch (Exception e)
            {
                if (handler is not null)
                {
                    return handler.OnException(e);
                }

                throw;
            }
        }

    }
}
