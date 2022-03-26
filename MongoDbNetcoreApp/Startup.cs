using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MongoDbNetcoreApp.Data;
using MongoDbNetcoreApp.Helpers;
using MongoDbNetcoreApp.Interfaces;
using MongoDbNetcoreApp.Mappers;
using MongoDbNetcoreApp.Services;

namespace MongoDbNetcoreApp
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
            services.Configure<MongoDbConfig>(Configuration.GetSection(nameof(MongoDbConfig)));
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddSingleton<IDbClient, DbClient>();
            services.AddTransient<IFeedbackService, FeedbackService>();
            services.AddTransient<IWebsiteTableService, WebsiteTableService>();
            services.AddApiVersioning(options =>
            {
                options.ReportApiVersions = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.AssumeDefaultVersionWhenUnspecified = true;
            });
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.DescribeAllParametersInCamelCase();
                c.EnableAnnotations();
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MongoDbNetcoreApp", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MongoDbNetcoreApp v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
