using Application.Dtos.Requests;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthService authService) : ApiControllerBase
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserRequest request,CancellationToken ct)
        {
            var result= await authService.Register(request,ct);
            return HandleResult(result);
        }

        [HttpGet("login")]
        public async Task<IActionResult> Login(LoginUserRequest request,CancellationToken ct)
        {
            var result = await authService.Logn(request, ct);
            return HandleResult(result);
        }
    }
}
