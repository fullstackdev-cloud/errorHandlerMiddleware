using System.Net;
using errorHandlerMiddleware.Exceptions;

namespace errorHandlerMiddleware.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlerMiddleware> _logger;

        public ErrorHandlerMiddleware(
            RequestDelegate next,
            ILogger<ErrorHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                switch (ex)
                {
                    case YouDidSomethingStupidException:
                        _logger.LogError(ex, "Something stupid happened");
                        response.StatusCode = (int)HttpStatusCode.Forbidden; // or whatever status you want...
                        await response.WriteAsync("You are not allowed to do stupid things!");
                        return;
                    default:
                        _logger.LogError(ex, "An unexpected error occurred");
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        return;
                }
            }
        }
    }
}