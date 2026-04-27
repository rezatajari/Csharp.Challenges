using Application.Dtos.Requests;
using Application.Interfaces;
using Application.Interfaces.IRepositories;
using Application.Shared;
using Domain.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public class AuthService(IBaseRepository<User> authRepo,ILogger<AuthService> logger, IJwtProvider jwtProvider) : IAuthService
    {
        public Task<Result<string>> Logn(LoginUserRequest request)
        {

        }

        public Task<Result<bool>> Register(RegisterUserRequest request)
        {

        }
    }
}
