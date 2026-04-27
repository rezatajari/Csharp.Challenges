using Application.Dtos.Requests;
using Application.Interfaces;
using Application.Interfaces.IRepositories;
using Application.Shared;
using Domain.Entities;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace Application.Services
{
    public class AuthService(IAuthRepository authRepo, ILogger<AuthService> logger, IJwtProvider jwtProvider) : IAuthService
    {
        public async Task<Result<string>> Logn(LoginUserRequest request,CancellationToken ct)
        {
            logger.LogInformation("Login attempt started for email: {Email}", request.Email);

            var user=await authRepo.GetByEmailAsync(request.Email,ct);
            if (user == null)
            {
                logger.LogWarning("Login failed: User with email {Email} not found.", request.Email);
                return Result<string>.Failure("The user is not exist");
            }

            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash);
            if (!isPasswordValid)
            {
                logger.LogWarning("Login failed: Invalid password for user {Email}.", request.Email);
                return Result<string>.Failure("Invalid credentials");
            }

            try
            {
                string token = jwtProvider.Generate(user);
                logger.LogInformation("User {Email} logged in successfully. Token generated.", request.Email);
                return Result<string>.Success(token);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred during token generation for user {Email}.", request.Email);
                throw; 
            }
        }

        public async Task<Result<bool>> Register(RegisterUserRequest request,CancellationToken ct)
        {

            logger.LogInformation("Registering new user with email: {Email}", request.Email);

            var existingUser = await authRepo.GetByEmailAsync(request.Email, ct);
            if (existingUser != null)
            {
                logger.LogWarning("Registration failed: Email {Email} is already taken.", request.Email);
                return Result<bool>.Failure("Email is already in use.");
            }

            string salt = BCrypt.Net.BCrypt.GenerateSalt();
            string hashed = BCrypt.Net.BCrypt.HashPassword(request.Password, salt);
            var user = User.Create(request.Username, request.Email, hashed);
            try
            {
                await authRepo.AddAsync(user, ct);
                await authRepo.SaveChangesAsync(ct);

                logger.LogInformation("User {Email} registered successfully with ID {UserId}.", user.Email, user.Id);
                return Result<bool>.Success(true);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Database error during registration for email {Email}.", request.Email);
                return Result<bool>.Failure("An error occurred while creating your account.");
            }
        }
    }
}
