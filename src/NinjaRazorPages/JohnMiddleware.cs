using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace NinjaRazorPages
{
    public class JohnMiddleware
    {
        private readonly RequestDelegate _next;

        public JohnMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context, ILogger<JohnMiddleware> logger)
        {
            var isUncleBranch = context.Request.Path.StartsWithSegments("/John");
            if (isUncleBranch)
            {
                await context.Response.WriteAsync("Salammm amooo!");
            }

            logger.LogInformation("salam");
        }
    }
}