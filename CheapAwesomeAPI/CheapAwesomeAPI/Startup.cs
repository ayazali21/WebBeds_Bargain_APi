using AutoMapper;
using CheapAwesome.API.Infrastructure.Filters;
using CheapAwesome.Domain.Settings;
using CheapAwesomeAPI.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Linq;
namespace CheapAwesomeAPI
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
            services.AddControllers();
            services.AddAutoMapper();

            SwaggerConfiguration(services);
            RegisterDependency(services);
        }
        
        private void RegisterDependency(IServiceCollection services)
        {
            
            var config = new BargainAPISettings();
            Configuration.Bind("BargainSupplier", config);      
            services.AddSingleton(config);

            services.AddSingleton<ApiExceptionFilter>();
            services.AddScoped<ISupplierHotelService, BargainsSupplierService>();
        }

        private static void SwaggerConfiguration(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Cheap Awesome API", Version = "v1" });
                // c.OperationFilter<SwaggerFileOperationFilter>();
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
                c.DescribeAllEnumsAsStrings();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            SwaggerSetup(app);

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        private static void SwaggerSetup(IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(url: "/swagger/v1/swagger.json", name: "Cheap Awesome Api");

            });
        }
    }
}
