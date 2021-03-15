using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SampleClient = Makc2021.Layer3.Sample.Clients.SqlServer.EF;
using SampleMapper = Makc2021.Layer3.Sample.Mappers.EF;

namespace Makc2021.Layer6.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static string[] Summaries { get; } = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        private SampleClient::Config.IClientConfigSettings AppSampleClientConfigSettings { get; }

        private SampleMapper::Config.IMapperConfigSettings AppSampleMapperConfigSettings { get; }
             
        private SampleMapper::Db.IMapperDbFactory AppSampleMapperDbFactory { get; }

        public WeatherForecastController(
            ILogger<WeatherForecastController> logger,            
            SampleClient::Config.IClientConfigSettings appSampleClientConfigSettings,
            SampleMapper::Config.IMapperConfigSettings appSampleMapperConfigSettings,
            SampleMapper::Db.IMapperDbFactory appSampleMapperDbFactory
            )
        {
            _logger = logger;

            AppSampleClientConfigSettings = appSampleClientConfigSettings;
            AppSampleMapperConfigSettings = appSampleMapperConfigSettings;            
            AppSampleMapperDbFactory = appSampleMapperDbFactory;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            Random rng = new();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet, Route("test")]
        public object Test()
        {
            try
            {
                using var dbContext = AppSampleMapperDbFactory.CreateDbContext();

                return new
                {
                    AppSampleClientConfigSettings,
                    AppSampleMapperConfigSettings,
                    dbContext.Database.ProviderName,
                    AppSampleMapperDbFactory.EntitiesSettings
                };
            }
            catch (Exception ex)
            {
                string errorCode = Guid.NewGuid().ToString("N");

                string errorMessage = $"Error code: {errorCode}";

                _logger.LogError(ex, errorMessage);

                throw new Exception(errorMessage);
            }
        }
    }
}
