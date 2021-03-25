using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Makc2021.Layer6.Apps.WebAPI.Controllers
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

        private Layer3.Sample.Clients.SqlServer.EF.Config.IClientConfigSettings AppSampleClientConfigSettings { get; }

        private Layer2.Config.IConfigSettings Layer2ConfigSettings { get; }
             
        private Layer3.Sample.Mappers.EF.Db.IMapperDbFactory AppSampleDbFactory { get; }

        public WeatherForecastController(
            ILogger<WeatherForecastController> logger,
            Layer3.Sample.Clients.SqlServer.EF.Config.IClientConfigSettings appSampleClientConfigSettings,
            Layer2.Config.IConfigSettings appDataConfigSettings,
            Layer3.Sample.Mappers.EF.Db.IMapperDbFactory appSampleDbFactory
            )
        {
            _logger = logger;

            AppSampleClientConfigSettings = appSampleClientConfigSettings;
            Layer2ConfigSettings = appDataConfigSettings;            
            AppSampleDbFactory = appSampleDbFactory;
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
                using var dbContext = AppSampleDbFactory.CreateDbContext();

                return new
                {
                    AppSampleClientConfigSettings,
                    Layer2ConfigSettings,
                    dbContext.Database.ProviderName,
                    AppSampleDbFactory.EntitiesSettings
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
