using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace AuthService
{
    public class LogMiddleware
    {
        private readonly ILogger _logger;
        private readonly RequestDelegate _next;

        public LogMiddleware(RequestDelegate next, ILogger logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var ip = httpContext.Connection.LocalIpAddress;
            _logger.WriteEvent("Я твой Middleware " + ip);
            await _next(httpContext);
        }
    }
}
