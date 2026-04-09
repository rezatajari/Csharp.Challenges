namespace AuthService.API.Shared
{
    public class ReturnResponse<T> where T : class
    {
        private ReturnResponse(bool isSuccess,T? data=default,string? message=null) { 
            Data = data;
            IsSuccess = isSuccess;
            Message = message;
        }
        public bool IsSuccess { get; }
        public T? Data { get; }
        public string? Message { get;  }

        public static ReturnResponse<T> Success(T? data) => new ReturnResponse<T>(true,data);
        public static ReturnResponse<T> Failure(string? message) => new ReturnResponse<T>(false, message: message);
    }
}
