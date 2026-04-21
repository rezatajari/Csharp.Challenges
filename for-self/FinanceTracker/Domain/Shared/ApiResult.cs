using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Shared
{
    public record ApiResult<T>(bool IsSuccess,T? Value,string ErrorMessage);
}
