using System.Net;
using System.Text.Json;

namespace Api.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate request;
        private readonly ILogger<ExceptionHandlingMiddleware> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExceptionHandlingMiddleware"/> class.
        /// </summary>
        public ExceptionHandlingMiddleware(RequestDelegate request, ILogger<ExceptionHandlingMiddleware> logger)
        {
            this.request = request;
            this.logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await this.request(context);
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, "An unexpected error occurred");

                await this.HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            HttpResponse response = context.Response;
            response.ContentType = "application/json";

            int statusCode = exception switch
            {
                ArgumentException => (int)HttpStatusCode.BadRequest,
                UnauthorizedAccessException => (int)HttpStatusCode.Unauthorized,
                KeyNotFoundException => (int)HttpStatusCode.NotFound,
                _ => (int)HttpStatusCode.InternalServerError
            };

            response.StatusCode = statusCode;

            var errorResponse = new
            {
                StatusCode = statusCode,
                Message = exception.Message,
                Details = exception.InnerException?.Message
            };

            return response.WriteAsync(JsonSerializer.Serialize(errorResponse));
        }
    }
}
