using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Shared
{
    public record ApiResult<T>(bool IsSuccess, T? Value, string? ErrorMessage)
    {
        public static ApiResult<T> Success(T value)
            => new ApiResult<T>(true, value, null);

        public static ApiResult<T> Failure(string errorMessage)
            => new ApiResult<T>(false, default, errorMessage);
    }
}
