namespace Application.Common
{
    public class ReturnResponse<T>
    {
        public bool Success { get; private set; }
        public string? Message { get; private set; }
        public T? Data { get; private set; }
        public List<string>? Errors { get; private set; }

        private ReturnResponse() { }

        public static ReturnResponse<T> Ok(T data)
        {
            return new ReturnResponse<T>
            {
                Success = true,
                Data = data,
                Errors = null
            };
        }

        public static ReturnResponse<T> Fail(string message, List<string>? errors = null)
        {
            return new ReturnResponse<T>
            {
                Success = false,
                Data = default,
                Message = message,
                Errors = errors
            };
        }

        public static ReturnResponse<T> Fail(List<string> errors, string? message = null)
        {
            return new ReturnResponse<T>
            {
                Success = false,
                Data = default,
                Message = message,
                Errors = errors
            };
        }
    }
}
