using AuthService.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private static  List<User> users=new List<User>();

        public  IActionResult Registration(User user)
        {
            if (users.Any(u=>u.Email==user.Email))
            {
                return BadRequest("Email already exists");
            }

            users.Add(user);
            return Ok("User registered successfully");
        }

        public IActionResult Login(Login login)
        {
            if (login == null)
                return BadRequest("Your login model should not null");

            var user = users.FirstOrDefault(u => u.Email == login.email && u.Password == login.password);
            if (user == null)
                return BadRequest("Invalid email or password");

               
        }

    }
}
