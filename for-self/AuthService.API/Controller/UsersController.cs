using AuthService.API.Data;
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
        private readonly AppDbContext _database;

        public UsersController(AppDbContext database)
        {
            _database = database;
        }

        [HttpPost("registration")]
        public IActionResult Registration(User user)
        {
            if (_database.Users.Any(u => u.Email == user.Email))
                return BadRequest(ReturnResponse<string>.Failure(Message.Create("Email already exists")));
            if (_database.Users.Any(u => u.Username == user.Username))
                return BadRequest(ReturnResponse<string>.Failure(Message.Create("Username already exists")));

            _database.Users.Add(user);
            _database.SaveChanges();
            return Ok(ReturnResponse<string>.Success($"registered {user.Email}", Message.Create("User registered successfully")));
        }

        [HttpPost("login")]
        public IActionResult Login(Login login)
        {
            if (login == null)
                return BadRequest(ReturnResponse<LoginResponse>.Failure(Message.Create("Your login model should not null")));

            var user = _database.Users.FirstOrDefault(
                u => (u.Email == login.email || u.Username == login.username) 
                && u.Password == login.password);
            if (user == null)
                return BadRequest(ReturnResponse<LoginResponse>.Failure(Message.Create("Invalid username/email or password")));

            var result = new LoginResponse(user.Email, user.Username);
            return Ok(ReturnResponse<LoginResponse>.Success(result, Message.Success()));
        }

        [HttpPost("change-password")]
        public IActionResult ChangePassword(ChangePassword changePassword)
        {
            if (changePassword == null)
                return BadRequest(ReturnResponse<bool>.Failure(Message.Create("Your change password model should not null")));

            var user=_database.Users.SingleOrDefault(u => u.Email == changePassword.Email && u.Password == changePassword.OldPassword);
            if (user == null)
                return BadRequest(ReturnResponse<bool>.Failure(Message.Create("Invalid email or old password")));

           var isChange= user.ChangePassword(changePassword.OldPassword,changePassword.NewPassword);

            if (!isChange)
                return BadRequest(ReturnResponse<bool>.Failure(Message.Create("Failed to change password")));
            return Ok(ReturnResponse<bool>.Success(true, Message.Create("Password changed successfully")));
        }

        [HttpPost("get-all")]
        public IActionResult GetAll() { 

            var result=_database.Users.Select(u=>new GetAllResponse(u.Email,u.Username,u.Id)).ToList();

            if (result.Count == 0)
                return BadRequest(ReturnResponse<List<GetAllResponse>>.Failure(Message.Create("No users found")));

            return Ok(ReturnResponse<List<GetAllResponse>>.Success(result,Message.Success()));
        }
    }
}
