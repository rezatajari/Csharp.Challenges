using AuthService.API.Data;
using AuthService.API.Models;
using AuthService.API.Shared;
using AuthService.API.ViewModels;
using BCrypt.Net;
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
                user.SetHashedPassword();
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

           var user=_database.Users
                .FirstOrDefault(u=>u.Email==login.Email || u.Username==login.Username);

            if (user== null || !BCrypt.Net.BCrypt.Verify(login.Password, user.Password))
                return BadRequest(ReturnResponse<LoginResponse>
                    .Failure(Message.Create("Invalid email/username or password")));

            var result = new LoginResponse(user.Email, user.Username);
            return Ok(ReturnResponse<LoginResponse>.Success(result, Message.Success()));
        }

        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword(ChangePassword changePassword)
        {
            if (changePassword == null)
                return BadRequest(ReturnResponse<bool>.Failure(
                    Message.Create("Your change password model should not null")));

            var user=_database.Users
                .FirstOrDefault(u => u.Email == changePassword.Email);

            if (user == null || !BCrypt.Net.BCrypt.Verify(changePassword.OldPassword,user.Password))
                return BadRequest(ReturnResponse<bool>.Failure(
                    Message.Create("Invalid email or old password")));

           var isChange= user.ChangePassword(changePassword.NewPassword);

            if (!isChange)
                return BadRequest(ReturnResponse<bool>.Failure(Message.Create("Failed to change password")));

            await _database.SaveChangesAsync();
            return Ok(ReturnResponse<bool>.Success(true, 
                Message.Create("Password changed successfully")));
        }

        [HttpPost("get-all")]
        public  IActionResult GetAll() { 

            var result= _database.Users.Select(u=>new GetAllResponse(u.Email,u.Username,u.Id)).ToList();

            if (result.Count == 0)
                return BadRequest(ReturnResponse<List<GetAllResponse>>.Failure(Message.Create("No users found")));

            return Ok(ReturnResponse<List<GetAllResponse>>.Success(result,Message.Success()));
        }

        [HttpGet("get-by-id")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var user = await _database.Users.FindAsync(id);
            if (user == null)
                return NotFound(ReturnResponse<UserById>.Failure(Message.Create("User not found")));

            return Ok(ReturnResponse<UserById>.Success(
                new UserById(user.Email,user.Username),Message.Success()));
        }

        [HttpDelete("delete")]
        public IActionResult Delete(Guid id)
        {
            var user=_database.Users.FirstOrDefault(u=>u.Id==id);
            if (user == null)
                return NotFound(ReturnResponse<bool>.Failure(Message.Create("User not found")));

            user.IsDeleted = true;
            _database.SaveChanges();

            return Ok(ReturnResponse<bool>.Success(true, Message.Success()));
        }

        [HttpPut("update")]
        public IActionResult Update(UserUpdate userUpdate)
        {
            if (userUpdate.id == Guid.Empty) 
                return BadRequest(ReturnResponse<bool>.Failure(Message.Create("User id should not be empty")));

            var user = _database.Users.FirstOrDefault(u => u.Id == userUpdate.id);

            if (user==null)
                return NotFound(ReturnResponse<bool>.Failure(Message.Create("User not found")));

            user.Update(userUpdate);
            _database.SaveChanges();

            return Ok(ReturnResponse<bool>.Success(true, Message.Success()));
        }
    }
}
