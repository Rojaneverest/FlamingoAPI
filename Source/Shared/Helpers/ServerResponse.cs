using System.Net;

namespace ecommerce.Shared.Helpers
{
        public class ServerResponse<T>
        {
            public T? Data { get; set; }
            public string Message { get; set; } = string.Empty;
            public int StatusCode { get; set; } 

            public static ServerResponse<T> Success(HttpResponse httpResponse, T data, string message = "", HttpStatusCode statusCode = HttpStatusCode.OK )
            {
                httpResponse.StatusCode =  (int)HttpStatusCode.OK;
                return new ServerResponse<T> { Data=data, Message = message, StatusCode = (int)statusCode };
            }

        public static ServerResponse<T> Error(HttpResponse httpResponse,Exception e)
        {

            if (e is BadHttpRequestException badHttpRequestException)
            {  
                var statusCode = badHttpRequestException.StatusCode;
                httpResponse.StatusCode = statusCode;
                return new ServerResponse<T> { Message = e.Message, StatusCode = statusCode };
            }
            else if (e is HttpRequestException httpRequestException)
            {
                var statusCode = (int)(httpRequestException.StatusCode ?? HttpStatusCode.BadRequest);
                httpResponse.StatusCode = statusCode;
                return new ServerResponse<T> { Message = e.Message, StatusCode = statusCode };
            }

            var defaultStatusCode = (int)HttpStatusCode.InternalServerError;
            httpResponse.StatusCode = defaultStatusCode;
            return new ServerResponse<T> { Message = "Internal Server Error", StatusCode = defaultStatusCode };
        }
    }

}
