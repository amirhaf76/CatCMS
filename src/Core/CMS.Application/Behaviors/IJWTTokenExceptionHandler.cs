using System.Security.Claims;

namespace CMS.Application.Behaviors
{
    public interface IJWTTokenExceptionHandler
    {
        ClaimsPrincipal OnException(Exception e);
    }
}
