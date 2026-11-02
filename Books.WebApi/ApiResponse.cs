using System.Net;

namespace Books.WebApi
{
    public class ApiResponse<T>
    {
        public HttpStatusCode Code { get; set; }
        public string? Message { get; set; }
        public T? Value { get; set; }
        public List<string>? Errors { get; set; }

        public ApiResponse(T value, string message = "Success")
        {
            Code = HttpStatusCode.OK;
            Message = message;
            Value = value;
            Errors = new List<string>();
        }

        public ApiResponse(string message, List<string> errors)
        {
            Code = HttpStatusCode.BadRequest;
            Message = message;
            Value = default;
            Errors = errors ?? new List<string>();
        }

        public ApiResponse(string message, Exception exception)
        {
            Code = HttpStatusCode.InternalServerError;
            Message = message;
            Value = default;
            Errors = new List<string>
            {
                exception.Message
            };
        }
    }
}
