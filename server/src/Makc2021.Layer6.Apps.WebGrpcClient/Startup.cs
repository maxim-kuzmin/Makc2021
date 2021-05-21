using Makc2021.Layer5.Apps.GrpcClient;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.IISIntegration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Makc2021.Layer6.Apps.WebGrpcClient
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
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Makc2021.Layer6.Apps.WebGrpcClient", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(
            IApplicationBuilder extAppBuilder,
            IWebHostEnvironment extEnvironment
            )
        {
            Configurator.Configure();

            if (extEnvironment.IsDevelopment())
            {
                extAppBuilder.UseDeveloperExceptionPage();
                extAppBuilder.UseSwagger();
                extAppBuilder.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Makc2021.Layer6.Apps.WebGrpcClient v1"));
            }

            extAppBuilder.UseHttpsRedirection();

            extAppBuilder.UseRouting();

            extAppBuilder.UseAuthorization();

            extAppBuilder.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}