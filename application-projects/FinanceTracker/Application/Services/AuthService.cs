using Application.Dtos.Requests;
using Application.Interfaces;
using Application.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public class AuthService(IJwtProvider jwtProvider) : IAuthService
    {
        public Task<Result<string>> Logn(LoginUserRequest request)
        {

        }

        public Task<Result<bool>> Register(RegisterUserRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
