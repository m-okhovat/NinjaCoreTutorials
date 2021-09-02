using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

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

            // var orderServiceDescriptor =  new ServiceDescriptor(typeof(IOrderService), typeof(OrderService), ServiceLifetime.Scoped);
            // services.Add(orderServiceDescriptor);


            services.AddSingleton<Settings>();
            services.AddSingleton<IIdGenerator, IdGenerator>();
            services.AddScoped<IOrderService>(provider =>
            {
                var id = string.Empty;
                var settings = provider.GetService<Settings>();
                if (settings.IsProduction)
                    id = $"production{Guid.NewGuid()}";
                else
                {
                    id = $"test{Guid.NewGuid()}";

                }

                return new OrderService(id);

            });

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


    public class ScopeService : IDisposable
    {
        public IServiceProvider Provider { get; }

        public IServiceProvider CreateProvider()
        {
            return Provider;
        }

        public void Dispose()
        {
            // disposing provider....
        }
    }

    // IServiceScopeFactory => IServiceScope
}


