using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common
{
    public record ApiResponse<T>(bool Success, T? Data=default, string? Message=null);
}
