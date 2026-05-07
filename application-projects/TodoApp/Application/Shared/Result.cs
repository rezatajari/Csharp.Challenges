using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Shared
{
    public class Result<T>
    {
        public T? Data { get; }
        public string? ErrorMessage { get; }
        public bool IsSuccess { get; };

        private Result(bool isSuccess,T? data, string? errorMessage)
        {
            IsSuccess = isSuccess;
            Data = data;
            ErrorMessage = errorMessage;
        }

        public static Result<T> Success(T Data) => new(true, Data, string.Empty);
        public static Result<T> Failure(string errorMessage) => new(false,default, errorMessage);


    }
    public static class ErrorMessages
    {
        public const string NotFound = "The item is not found";
        public const string DbError = "Don't save in database";
    }
}
