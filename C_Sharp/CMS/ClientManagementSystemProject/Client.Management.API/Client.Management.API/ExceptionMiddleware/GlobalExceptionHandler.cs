using System.Net;

namespace Client.Management.API.ExceptionMiddleware
{
    public class GlobalExceptionHandler
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionHandler> _logger;

        public GlobalExceptionHandler(RequestDelegate next, ILogger<GlobalExceptionHandler> logger)
        {
            this._next = next;
            this._logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await this._next(httpContext);
            }
            catch(Exception exception)
            {
                /* Create New ID For Error */
                var errorId = Guid.NewGuid();

                /* Log this exception */
                Console.WriteLine($"Exception - {errorId} - {exception.Message}");
                this._logger.LogError(exception, $"Exception - {errorId} - {exception.Message} \n\n");

                /* Return A Custom Error Response */
                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                httpContext.Response.ContentType = "application/json";

                /* Need to return a response back */
                /* Creating a new custom error model object with two properties */
                var error = new
                {
                    Id = errorId,
                    ErrorMessage = "Something went Wrong!",
                };

                await httpContext.Response.WriteAsJsonAsync(error);
            }
        }
    }
}
