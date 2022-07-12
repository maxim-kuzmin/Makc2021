using Makc2021.Layer5.Sql.GrpcClient;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.IISIntegration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Makc2021.Layer6.Sql.WebGrpcClient
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
            Configurator.ConfigureServices(services);

            services.AddControllers();

            services.AddAuthentication(IISDefaults.AuthenticationScheme);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Makc2021.Layer6.Sql.WebGrpcClient", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(
            IApplicationBuilder appBuilder,
            IWebHostEnvironment hostEnvironment
            )
        {
            Configurator.Configure();

            if (hostEnvironment.IsDevelopment())
            {
                appBuilder.UseDeveloperExceptionPage();
                appBuilder.UseSwagger();
                appBuilder.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Makc2021.Layer6.Sql.WebGrpcClient v1"));
            }

            appBuilder.UseHttpsRedirection();

            appBuilder.UseRouting();

            appBuilder.UseAuthorization();

            appBuilder.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
