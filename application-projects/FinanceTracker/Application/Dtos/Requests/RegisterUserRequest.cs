using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dtos.Requests
{
    public record RegisterUserRequest(
        string Username,
        string Email,
        string Password,
        string ConfirmPassword);
}
