using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dtos.Requests
{
    public class RegisterUserRequest
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
