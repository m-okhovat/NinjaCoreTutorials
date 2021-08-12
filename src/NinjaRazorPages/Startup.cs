using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace NinjaRazorPages
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<CustomMiddleware>();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.Use(async (context, next) =>
            {
                var isUncleBranch = context.Request.Path.StartsWithSegments("/Amoo");
                if (isUncleBranch)
                {
                    await context.Response.WriteAsync("Farar!!!!");
                }

                else
                {
                    await next();
                }

            });

            app.UseRouting();

            app.Map("/ping", builder =>
            {
                builder.Run(async context => await context.Response.WriteAsync("Pong"));

            });

            app.UseMiddleware<CustomMiddleware>();
            app.UseMiddleware<JohnMiddleware>();
            // app.Run(async context => await context.Response
            //                         .WriteAsync("hello I am from Run method in application builder =>"));

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.Map("/test", async context =>
                   await context.Response.WriteAsync("this is test"));

                endpoints.MapRazorPages();
            });
        }
    }

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
