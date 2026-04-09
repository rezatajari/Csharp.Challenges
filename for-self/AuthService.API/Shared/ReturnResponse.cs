namespace AuthService.API.Shared
{
    public class ReturnResponse<T> 
    {
        private ReturnResponse(bool isSuccess,T? data=default,Message? message=null) { 
            Data = data;
            IsSuccess = isSuccess;
            Message = message;
        }
        public bool IsSuccess { get; }
        public T? Data { get; }
        public Message? Message { get; }
        public static ReturnResponse<T> Success(T? data,Message? message) => new ReturnResponse<T>(true,data,message);
        public static ReturnResponse<T> Failure(Message? message) => new ReturnResponse<T>(false, message: message);
    }

    public record Message
    {
        public string? Value { get; init; }
        private Message(string? value) => Value = value;

        public static Message Create(string? value) => new Message(value);

        public static Message Success()=> new Message("Operation successful");
        public static Message Failure() => new Message("Operation failed");
    }
}
