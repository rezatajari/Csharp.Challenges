using Application.Dtos.Requests;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthService authService) : ApiControllerBase
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register(CreateUserRequest request)
        {

        }
    }
}
