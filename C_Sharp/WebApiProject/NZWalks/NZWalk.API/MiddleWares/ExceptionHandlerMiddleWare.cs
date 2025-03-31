using System.Net;

namespace NZWalk.API.MiddleWares
{
    public class ExceptionHandlerMiddleWare
    {
        private readonly ILogger<ExceptionHandlerMiddleWare> _logger;
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleWare(ILogger<ExceptionHandlerMiddleWare> logger, RequestDelegate next)
        {
            this._logger = logger;
            this._next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception exception)
            {
                /* Create New ID For Error */
                var errorId = Guid.NewGuid();

                /* Log this exception */
                this._logger.LogError(exception, $"{errorId} - {exception.Message}");

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
