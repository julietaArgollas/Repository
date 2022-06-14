using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackingServices.Services;
using Database;
using Logic.Managers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace PracticeThree
{
    public class Startup
    {
        public Startup(IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                // .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ProductManager>();
            services.AddTransient<ListProductsManager>();
            services.AddTransient<CampaignService>();

            services.AddScoped<UnitOfWork>();

            services.AddDbContext<PracticeDbContext>();

            services.AddControllers();

            services.AddSwaggerGen(options =>
            {
                var groupName = "v1";

                options.SwaggerDoc(groupName, new OpenApiInfo
                {
                    Title = $"Practice 3",
                    Version = groupName,
                    Description = "Practice API",
                    Contact = new OpenApiContact
                    {
                        Name = "Foo Company",
                        Email = string.Empty,
                        Url = new Uri("https://foo.com/"),
                    }
                });
            });
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

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Practice 3 API V1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
