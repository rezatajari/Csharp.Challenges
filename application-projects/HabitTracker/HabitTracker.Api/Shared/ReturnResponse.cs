namespace HabitTracker.Api.Shared
{
    public class ReturnResponse<T>
    {
        public bool IsSuccess { get; }
        public T? Value { get; }
        public string ErrorMessage { get; }

        protected ReturnResponse(bool success, T? value, string errorMessage)
        {
            IsSuccess = success;
            Value = value;
            ErrorMessage = errorMessage;
        }

        public static ReturnResponse<T> Success(T value) => new(true, value, string.Empty);
        public static ReturnResponse<T> Failure(string errorMessage) => new(false, default, errorMessage);
    }
}
