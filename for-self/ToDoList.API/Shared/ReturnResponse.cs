namespace ToDoList.API.Shared
{
    public class ReturnResponse<T>
    {
        public T? Data { get; private set; }
        public bool IsSuccess { get; private set; }
        public string? Message { get;private set; }

        private ReturnResponse(bool isSuccess, T? data,string? message)
        {
            IsSuccess = isSuccess;
            Data = data;
            Message = message;
        }

        public static ReturnResponse<T> Success(T? data,string? message)
            => new ReturnResponse<T>(true,data,message);

        public static ReturnResponse<T> Failure(string? message)
            => new ReturnResponse<T>(false, default, message);
    }
}
