using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dtos.Requests
{
    public class LoginUserRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
