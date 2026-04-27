using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dtos.Requests
{
    public record LoginUserRequest(string Email,string Password);
}
