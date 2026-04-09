using AuthService.API.Data;
using AuthService.API.Models;
using AuthService.API.Shared;
using AuthService.API.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IActionResult> Registration(User user)
        {
            try
            {
                _database.Users.Add(user);
                await _database.SaveChangesAsync();
                return Ok(ReturnResponse<string>.Success($"registered {user.Email}", Message.Create("User registered successfully")));
            }
            catch (DbUpdateException)
            {
                return BadRequest(ReturnResponse<string>.Failure(Message.Create("Email or Username already exists")));
            }
        }

        [HttpPost("login")]
        public IActionResult Login(Login login)
        {
            if (!login.IsValid())
                return BadRequest(ReturnResponse<LoginResponse>.Failure(Message.Create("Your login model should not null and must contain email or username and password")));

            var user = _database.Users.FirstOrDefault(
              u => (u.Email == login.Email || u.Username == login.Username)
              && u.Password == login.Password);
            if (user == null)
                        return BadRequest(ReturnResponse<LoginResponse>.Failure(Message.Create("Invalid username/email or password")));

            var result = new LoginResponse(user.Email, user.Username);
            return Ok(ReturnResponse<LoginResponse>.Success(result, Message.Success()));
        }

        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword(ChangePassword changePassword)
        {
            if (changePassword == null)
                return BadRequest(ReturnResponse<bool>.Failure(Message.Create("Your change password model should not null")));

            var user=_database.Users.SingleOrDefault(u => u.Email == changePassword.Email && u.Password == changePassword.OldPassword);
            if (user == null)
                return BadRequest(ReturnResponse<bool>.Failure(Message.Create("Invalid email or old password")));

           var isChange= user.ChangePassword(changePassword.OldPassword,changePassword.NewPassword);

            if (!isChange)
                return BadRequest(ReturnResponse<bool>.Failure(Message.Create("Failed to change password")));

            await _database.SaveChangesAsync();
            return Ok(ReturnResponse<bool>.Success(true, Message.Create("Password changed successfully")));
        }

        [HttpPost("get-all")]
        public  IActionResult GetAll() { 

            var result= _database.Users.Select(u=>new GetAllResponse(u.Email,u.Username,u.Id)).ToList();

            if (result.Count == 0)
                return BadRequest(ReturnResponse<List<GetAllResponse>>.Failure(Message.Create("No users found")));

            return Ok(ReturnResponse<List<GetAllResponse>>.Success(result,Message.Success()));
        }
    }
}
