using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Infrastructure
{
    public class GenerateJwt
    {

        public static JWTTokenDto Generate()
        {
            var expirationTime = DateTimeOffset.UtcNow.AddHours(2);

            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, "public_key"),
                new Claim(JwtRegisteredClaimNames.Exp, expirationTime.ToUnixTimeSeconds().ToString()),
            };

            var sharedSecret = new byte[50];

            new Random().NextBytes(sharedSecret);

            var securityKey = new SymmetricSecurityKey(sharedSecret);
            var credential = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var securityToken = new JwtSecurityToken(issuer: null, audience: null, claims: claims, signingCredentials: credential);
            var securityTokenHandler = new JwtSecurityTokenHandler();

            return new JWTTokenDto
            {
                Token = securityTokenHandler.WriteToken(securityToken),
                SharedSecret = Encoding.UTF8.GetString(sharedSecret),
            };
        }

        public static RSAGeneratedDto GenerateRSA()
        {
            using var rsa = RSA.Create();

            return new RSAGeneratedDto
            {
                PublicKey = Convert.ToBase64String(rsa.ExportRSAPublicKey()),
                PrivateKey = Convert.ToBase64String(rsa.ExportRSAPrivateKey())
            };
        }

        public static string GenerateToken(string privateKey, string issuer, string audience, Claim[] claims)
        {
            using var rsa = RSA.Create();

            rsa.ImportRSAPrivateKey(Convert.FromBase64String(privateKey), out _);

            var securityKey = new RsaSecurityKey(rsa);
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

        public static ClaimsPrincipal? ValidateToken(string token, string publicKey, string issuer, string audience)
        {
            using var rsa = RSA.Create();

            rsa.ImportRSAPublicKey(Convert.FromBase64String(publicKey), out _);

            var securityKey = new RsaSecurityKey(rsa);

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
            catch (SecurityTokenException)
            {

                return null;
            }
        }
    }

    public class RSAGeneratedDto
    {
        public string PublicKey { get; set; } = string.Empty;
        public string PrivateKey { get; set; } = string.Empty;
    }

    public class JWTTokenDto
    {
        public string Token { get; set; } = string.Empty;
        public string SharedSecret { get; set; } = string.Empty;
    }
}
