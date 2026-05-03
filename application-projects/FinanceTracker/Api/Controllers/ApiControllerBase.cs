using Application.Shared;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiControllerBase : ControllerBase
    {
       protected int UserId
        {
            get
            {
                var claim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (!int.TryParse(claim, out var userId))
                    throw new UnauthorizedAccessException("Invalid UserId");

                return userId;
            }
        }

        protected ActionResult HandleResult<T>(Result<T> result,int statusCode=400)
        {
            if (result.IsSuccess) return Ok(result.Value);
            return Problem(
                detail: result.ErrorMessage,
                statusCode: statusCode,
                title: GetTitleForStatus(statusCode));
        }

        private string GetTitleForStatus(int statusCode)
            => statusCode switch
            {
                400 => "Bad Request",
                404 => "Not Found",
                401 => "Unauthorized",
                _ => "Server Error"
            };
    }
}
