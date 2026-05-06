using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Net.Security;

namespace API
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {

            var (statusCode, title) = exception switch
            {
                KeyNotFoundException => (StatusCodes.Status404NotFound, "Resource Not Found"),
                InvalidOperationException => (StatusCodes.Status400BadRequest, "Invalid Operation"),
                _ => (StatusCodes.Status500InternalServerError, "Server Error")
            };

            ProblemDetails problemDetails = new()
            {
                Status = statusCode,
                Title = title,
                Detail = exception.Message
            };


            httpContext.Response.StatusCode = statusCode;
            await httpContext.Response.WriteAsJsonAsync(problemDetails,cancellationToken);
            return true;
        }
    }
}
