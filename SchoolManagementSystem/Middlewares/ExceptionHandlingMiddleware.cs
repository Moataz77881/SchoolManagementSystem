using SchoolManagementSystem.Infrastructure.Response;
using System.Net;
using System.Text.Json;

namespace SchoolManagementSystem.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                // Log error
                _logger.LogError(ex, "Unhandled exception occurred");

                // Prepare response
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                var response = new ServiceResponse
                {
                    StatusCode = context.Response.StatusCode,
                    Message = ex.Message,
                    Data = null,
                    Success = false
                };

                var json = JsonSerializer.Serialize(response);

                await context.Response.WriteAsync(json);
            }
        }
    }
}
