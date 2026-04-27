using Application.Dtos.Requests;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    public interface IAuthService
    {
        Task<bool> Register(RegisterUserRequest request);
        Task<string> Logn(LoginUserRequest request);
    }
}
