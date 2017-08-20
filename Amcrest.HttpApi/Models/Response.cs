using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Amcrest.HttpApi.Models
{
    public sealed class Response
    {

        public static async Task<T> CreateAsync<T>(HttpResponseMessage httpResponse)
        {
            var ex = new ResponseException
            {
                HttpResponseCode = httpResponse.StatusCode,
                ResponseBody = await httpResponse.Content.ReadAsStringAsync()
            };

            if (ex.ResponseBody.Trim().Equals("OK") && typeof(T) == typeof(bool))
                return (T)((object)true);

            // Handle an error scenario
            if (ex.ResponseBody.StartsWith("Error"))
            {
                if (typeof(T) == typeof(bool))
                    return (T)((object)false);

                var errorLines = ex.ResponseBody.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                if (errorLines.Length >= 2)
                {
                    var errorLine = errorLines[1];
                    var errorDataPoints = errorLine.Split(new char[] { '=', ',' }, StringSplitOptions.RemoveEmptyEntries);
                    var errorId = -1;
                    if (errorDataPoints.Length >= 2 && int.TryParse(errorDataPoints[1], out errorId))
                        ex.Error = (ErrorCode)errorId;

                    if (errorDataPoints.Length >= 4)
                        ex.ErrorMessage = errorDataPoints[3].Trim();

                    throw ex;
                }
            }

            if (typeof(T) == typeof(KeyValueResponse))
                return (T)(new KeyValueResponse(ex.ResponseBody) as object);
            else
                return Node.FromFormData<T>(ex.ResponseBody);
        }

    }

    public class ResponseException : Exception
    {
        public string ResponseBody { get; internal set; } = string.Empty;
        public HttpStatusCode HttpResponseCode { get; internal set; }
        public ErrorCode Error { get; internal set; } = ErrorCode.None;
        public string ErrorMessage { get; internal set; }
    }

}
