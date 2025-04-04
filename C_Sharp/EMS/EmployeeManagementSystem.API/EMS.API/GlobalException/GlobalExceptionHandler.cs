using EMS.API.DTOs.ErrorDTOs;
using System.Net;
using System.Text.Json;

namespace EMS.API.GlobalException
{
    public class GlobalExceptionHandler
    {
        private readonly RequestDelegate _requestNextDelegate;
        private readonly ILogger<GlobalExceptionHandler> _logger;

        public GlobalExceptionHandler(RequestDelegate requestDelegate, ILogger<GlobalExceptionHandler> logger)
        {
            this._requestNextDelegate = requestDelegate;
            this._logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await this._requestNextDelegate(httpContext);
            }
            catch (Exception exception)
            {
                var id = Guid.NewGuid();

                this._logger.LogInformation(exception, $"{id} - {exception.Message}");

                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                httpContext.Response.ContentType = "application/json";

                ErrorDto errorDto = new()
                {
                    ErrorId = id.ToString(),
                    ErrorDate = DateTimeOffset.UtcNow.ToString("dd-mm-yyyy HH:mm:ss"),
                    ErrorStatusCode = HttpStatusCode.InternalServerError.ToString(),
                    ErrorMessage = exception.Message,
                    StackTrace = exception?.StackTrace ?? string.Empty,
                    InnerException = exception?.InnerException?.Message ?? string.Empty,
                };

                var error = new
                {
                    ID = id,
                    Message = "Something Bad happened!",
                };

                //this._logger.LogError(exception, $"Error Id: {id} - {errorDto}");
                await httpContext.Response.WriteAsJsonAsync(error);
            }
        }
    }
}
