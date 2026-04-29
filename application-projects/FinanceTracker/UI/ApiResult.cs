namespace UI
{
    public class ApiResult<T>
    {
        public bool Success { get; private set; }
        public T? Data { get; private set; }
        public string ErrorMessage { get; private set; }

        public ApiResult(bool success, T? data = default, string errorMessage)
        {
            Success = success;
            Data = data;
            ErrorMessage = errorMessage;
        }
        public static ApiResult<T> Sucess(T data) => new ApiResult<T>(true, data, string.Empty);
        public static ApiResult<T> Failure(string errorMessage) => new ApiResult<T>(false, default, errorMessage);
    }
}
