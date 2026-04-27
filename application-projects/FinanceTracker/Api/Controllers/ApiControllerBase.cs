using Application.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiControllerBase : ControllerBase
    {
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
