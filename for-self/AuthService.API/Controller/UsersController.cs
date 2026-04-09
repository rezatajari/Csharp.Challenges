using AuthService.API.Models;
using AuthService.API.Shared;
using AuthService.API.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private static List<User> users = new List<User>();

        [HttpPost("registration")]
        public IActionResult Registration(User user)
        {
            if (users.Any(u => u.Email == user.Email))
                return BadRequest(ReturnResponse<string>.Failure("Email already exists"));
            if (users.Any(u => u.Username == user.Username))
                return BadRequest(ReturnResponse<string>.Failure("Username already exists"));

            users.Add(user);
            return Ok(ReturnResponse<string>.Success($"registered {user.Email}", "User registered successfully"));
        }

        [HttpPost("login")]
        public IActionResult Login(Login login)
        {
            if (login == null)
                return BadRequest(ReturnResponse<LoginResponse>.Failure("Your login model should not null"));

            var user = users.FirstOrDefault(
                u => (u.Email == login.email || u.Username == login.username) 
                && u.Password == login.password);
            if (user == null)
                return BadRequest(ReturnResponse<LoginResponse>.Failure("Invalid username/email or password"));

            var result = new LoginResponse(user.Email, user.Username);
            return Ok(ReturnResponse<LoginResponse>.Success(result, "Login successful"));
        }

    }
}
