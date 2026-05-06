using Application.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiControllerBase : ControllerBase
    {
        protected ActionResult HandleResult<T>(Result<T> result)
        {
            return (result.IsSuccess)
                ? Ok(result.Data)
                : Problem(detail:result.ErrorMessage,
                            statusCode: StatusCodes.Status500InternalServerError,
                            title: "Bad Request");
        }
    }
}
