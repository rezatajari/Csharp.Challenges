using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dtos.Requests
{
    record class CreateUserRequest(string Username,string Email);
}
