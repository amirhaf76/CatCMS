using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

public class DBExceptionHandler : IExceptionHandler
{
    private readonly ILogger<DBExceptionHandler> _logger;

    public DBExceptionHandler(ILogger<DBExceptionHandler> logger)
    {
        _logger = logger;
    }

    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {


        if (exception is not NullReferenceException badRequestException)
        {
            return false;
        }
        _logger.LogError(
          badRequestException,
          "Exception occurred: {Message}",
          badRequestException.Message);

        var problemDetails = new ProblemDetails
        {
            Status = StatusCodes.Status400BadRequest,
            Title = "Bad Request",
            Detail = badRequestException.Message
        };

        await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

        return true;
    }
}