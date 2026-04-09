namespace AuthService.API.Shared
{
    public class ReturnResponse<T> 
    {
        private ReturnResponse(bool isSuccess,T? data=default,string? message=null) { 
            Data = data;
            IsSuccess = isSuccess;
            Message = message;
        }
        public bool IsSuccess { get; }
        public T? Data { get; }
        public string? Message { get;  }

        public static ReturnResponse<T> Success(T? data,string? message) => new ReturnResponse<T>(true,data,message);
        public static ReturnResponse<T> Failure(string? message) => new ReturnResponse<T>(false, message: message);
    }
}
