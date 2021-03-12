using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SampleClient = Makc2021.Layer3.Sample.Clients.SqlServer.EF;
using SampleMapper = Makc2021.Layer3.Sample.Mappers.EF;

namespace Makc2021.Layer0.WebAPI.Controllers
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

        private SampleClient::Config.IClientConfigSettings ConfigSettingsOfSampleClient { get; }

        private SampleMapper::Config.IMapperConfigSettings ConfigSettingsOfSampleMapper { get; }
             
        private SampleMapper::Db.IMapperDbFactory DbFactoryOfSampleMapper { get; }

        public WeatherForecastController(
            ILogger<WeatherForecastController> logger,            
            SampleClient::Config.IClientConfigSettings configSettingsOfSampleClient,
            SampleMapper::Config.IMapperConfigSettings configSettingsOfSampleMapper,
            SampleMapper::Db.IMapperDbFactory dbFactoryOfSampleMapper
            )
        {
            _logger = logger;

            ConfigSettingsOfSampleClient = configSettingsOfSampleClient;
            ConfigSettingsOfSampleMapper = configSettingsOfSampleMapper;            
            DbFactoryOfSampleMapper = dbFactoryOfSampleMapper;
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
                using var dbContext = DbFactoryOfSampleMapper.CreateDbContext();

                return new
                {
                    ConfigSettingsOfSampleClient,
                    ConfigSettingsOfSampleMapper,
                    dbContext.Database.ProviderName,
                    DbFactoryOfSampleMapper.EntitiesSettings
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
