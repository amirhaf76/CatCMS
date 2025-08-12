using Infrastructure.JWTService.Abstractions;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace Infrastructure.JWTService
{
    public class AsymmetricJWTTokenService : IJWTTokenService
    {
        private readonly RSA _rsa;

        public AsymmetricJWTTokenService(RSA rsa)
        {
            _rsa = rsa;
        }

        public string GenerateToken(string privateKey, string issuer, string audience, IEnumerable<Claim> claims)
        {
            var key = Convert.FromBase64String(privateKey);

            _rsa.ImportRSAPrivateKey(key, out _);

            var securityKey = new RsaSecurityKey(_rsa);
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.RsaSha256);

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

            _rsa.ImportRSAPublicKey(key, out _);

            var securityKey = new RsaSecurityKey(_rsa);

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
