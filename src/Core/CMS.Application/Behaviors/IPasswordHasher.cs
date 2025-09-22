
using System.Security.Claims;

namespace CMS.Application.Behaviors
{
    public interface IPasswordHasher
    {
        string HashPassword(string password);

        PasswordVerificationResult VerifyHashedPassword(string hashedPassword, string providedPassword);
    }

    public interface IClaimProvider
    {
        Claim[] GetClaims();
    }
}
