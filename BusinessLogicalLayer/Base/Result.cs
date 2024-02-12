using System.Net.Http;

namespace BusinessLogicalLayer.Base
{
    public class Result<T>
    {
        public T Data { get; }
        
        public Error Error { get; }
        public bool IsSuccess => Error is null;
        public bool IsFailure => !IsSuccess;
        private Result(Error error)
        {
            Error = error;
            Data = default;
        }

        private Result(T data)
        {
            Data = data;
            Error = default;
        }

        public static implicit operator Result<T>(Error error) => new Result<T>(error);
        public static implicit operator Result<T>(T data) => new Result<T>(data);
        public static Result<T> Success() => new Result<T>(null);
    }
}
