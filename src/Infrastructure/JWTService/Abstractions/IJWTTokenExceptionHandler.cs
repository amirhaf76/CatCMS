using System.Security.Claims;

namespace CMSHelper.JWTService.Abstractions
{
    public interface IJWTTokenExceptionHandler
    {
        ClaimsPrincipal OnException(Exception e);
    }
}
