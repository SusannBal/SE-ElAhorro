using System;
using System.Collections.Generic;
using System.Text;

namespace Tienda.Application.Wrappers
{
    public class Result<T>
    {
        public bool IsSuccess { get; }
        public T Value { get; }
        public string ErrorMessage { get; }
        public bool IsUnauthorized { get; }

        private Result(bool isSuccess, T value, string errorMessage, bool isUnauthorized = false)
        {
            IsSuccess = isSuccess;
            Value = value;
            ErrorMessage = errorMessage;
            IsUnauthorized = isUnauthorized;
        }

        public static Result<T> Success(T value) => new Result<T>(true, value, null);
        public static Result<T> Failure(string errorMessage) => new Result<T>(false, default, errorMessage);
        public static Result<T> Unauthorized(string errorMessage) => new Result<T>(false, default, errorMessage, true);
    }
}
