using AuthService.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private static  List<User> users=new List<User>();

        public async Task<IActionResult> Registration(User user)
        {
            if (users.Any(u=>u.Email==user.Email))
            {
                return BadRequest("Email already exists");
            }

            users.Add(user);
            return Ok("User registered successfully");
        }
    }
}
