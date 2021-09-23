using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace NinjaAspNetCore
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
            // var @default =  Configuration["LoggingAmoo:LogLevelAmoo:Default"];
            // var isActive =  bool.Parse(Configuration["LoggingAmoo:LogLevelAmoo:IsActive"]);

            // var logSection  = Configuration.GetSection("LoggingAmoo:LogLevelAmoo"); //TODO: how has GetSection implemented?
            // var microsoft =  logSection["Microsoft"];

            services.Configure<LoggingAmoo>(options => Configuration.GetSection("LoggingAmoo").Bind(options));
            services.Configure<LoggingAmoo>(options =>
            {
                options.LogLevelAmoo.MicrosoftHostingLifetime = Configuration["LoggingAmoo:LogLevelAmoo:Microsoft.Hosting.Lifetime"];
            });


            // Second way for registering configuration:
            //1) step 1
            var loggingAmoo = new LoggingAmoo();
            Configuration.GetSection("LoggingAmoo").Bind(loggingAmoo);

            //2) step 2:
            services.AddSingleton(loggingAmoo);


            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            // DOTNET_Environment
            // ASPDOTNET_Environment

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }

    public class LoggingAmoo
    {
            public LogLevel LogLevelAmoo { get; set; }
    }

    public class LogLevel
    {
        public string Default { get; set; }
        public bool IsActive { get; set; }
        public string Microsoft { get; set; }
        
        [BindProperty(Name = "Microsoft.Hosting.Lifetime")]
        public string MicrosoftHostingLifetime { get; set; }
    }

    public class FakeSettings
    {
        public string  S { get; set; }
    }
}
