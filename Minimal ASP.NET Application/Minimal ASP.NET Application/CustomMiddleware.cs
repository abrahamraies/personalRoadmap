namespace Minimal_ASP.NET_Application
{
    public class CustomMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
    {
        private readonly RequestDelegate _next = next;
        private readonly ILogger _logger = loggerFactory.CreateLogger<CustomMiddleware>();

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            finally
            {
                _logger.LogInformation(
                    "Request {method} {url} => {statusCode}",
                    context.Request?.Method,
                    context.Request?.Path.Value,
                    context.Response?.StatusCode);
            }
        }
    }
}
