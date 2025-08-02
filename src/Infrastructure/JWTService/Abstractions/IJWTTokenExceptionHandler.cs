using System.Security.Claims;

namespace Infrastructure.JWTService.Abstractions
{
    public interface IJWTTokenExceptionHandler
    {
        ClaimsPrincipal OnException(Exception e);
    }
}
