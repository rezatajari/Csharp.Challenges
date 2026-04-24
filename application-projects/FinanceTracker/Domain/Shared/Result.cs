namespace Domain.Shared
{
    public class Result<T>
    {
        public bool IsSuccess { get; }
        public T? Value { get; }
        public string ErrorMessage { get; }

        protected Result(bool success, T? value, string errorMessage)
        {
            IsSuccess = success;
            Value = value;
            ErrorMessage = errorMessage;
        }

        public static Result<T> Success(T value) => new(true, value, string.Empty);
        public static Result<T> Failure(string errorMessage) => new(false, default, errorMessage);
    }
}
