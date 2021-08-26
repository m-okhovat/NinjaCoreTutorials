using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace NinjaRazorPages
{
    public class CustomMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {

            var isUncleBranch = context.Request.Path.StartsWithSegments("/Uncle");
            if (isUncleBranch)
            {
                await context.Response.WriteAsync("bad gheleghi nakon amoo he!");
            }

            else
            {
                await next(context);
            }
        }
    }
}