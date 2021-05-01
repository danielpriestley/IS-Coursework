using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Coursework2.Shared;
using ChinookService.Repositories;
using static System.Console;
using System.IO;
using Microsoft.EntityFrameworkCore;

namespace ChinookService
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

            string databasePath = Path.Combine("..", "Chinook.db");
            services.AddDbContext<ChinookDb>(options =>
                options.UseSqlite($"Data Source={databasePath}"));
            services.AddControllers(options =>
            {
                WriteLine("Default output formatters:");
                foreach (IOutputFormatter formatter in options.OutputFormatters)
                {
                    var mediaFormatter = formatter as OutputFormatter;
                    if (mediaFormatter == null)
                    {
                        WriteLine($" {formatter.GetType().Name}");
                    }
                    else // outputformatter has supported media types
                    {
                        WriteLine("  {0}, Media types: {1}",
                        arg0: mediaFormatter.GetType().Name,
                        arg1: string.Join(", ",
                             mediaFormatter.SupportedMediaTypes));
                    }
                }
            })
            .AddXmlDataContractSerializerFormatters()
            .AddXmlSerializerFormatters()
            .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddScoped<IAlbumsRepository, AlbumsRepository>();

            services.AddCors();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(configurePolicy: options =>
           {
               options.WithMethods("GET", "POST", "PUT", "DELETE");
               options.WithOrigins("https://localhost:5002");
           });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
