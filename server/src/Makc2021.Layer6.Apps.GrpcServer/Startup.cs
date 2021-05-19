using Makc2021.Layer5.Apps.Server;
using Makc2021.Layer6.Apps.GrpcServer.Services.Pages.DummyMain.Item;
using Makc2021.Layer6.Apps.GrpcServer.Services.Pages.DummyMain.List;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Makc2021.Layer6.Apps.GrpcServer
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            Configurator.ConfigureServices(services);

            services.AddGrpc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(
            Layer3.Sample.Mappers.EF.IMapperService appSampleMapperService,
            IApplicationBuilder extAppBuilder,
            IWebHostEnvironment extEnvironment
            )
        {
            Configurator.Configure(appSampleMapperService);

            if (extEnvironment.IsDevelopment())
            {
                extAppBuilder.UseDeveloperExceptionPage();
            }

            extAppBuilder.UseRouting();

            extAppBuilder.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcService<DummyMainItemPageService>();
                endpoints.MapGrpcService<DummyMainListPageService>();

                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");
                });
            });
        }
    }
}
