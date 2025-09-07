using System.Security.Claims;

namespace Infrastructure.JWTProviders.Abstractions
{
    public interface IJWTTokenExceptionHandler
    {
        ClaimsPrincipal OnException(Exception e);
    }
}
