using System;
using System.Collections.Generic;
using System.Linq;
using Makc2021.Layer3.Sample.Clients.SqlServer.EF.Config;
using Makc2021.Layer3.Sample.Mappers.EF.Config;
using Makc2021.Layer3.Sample.Mappers.EF.Db;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Makc2021.Layer0.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        private IMapperConfigSettings ConfigSettingsOfEF { get; }
        private IClientConfigSettings ConfigSettingsOfEFSqlServer { get; }
        private IMapperDbFactory DbFactory { get; }

        public WeatherForecastController(
            ILogger<WeatherForecastController> logger,
            IMapperConfigSettings configSettingsOfEF,
            IClientConfigSettings configSettingsOfEFSqlServer,
            IMapperDbFactory dbFactory
            )
        {
            _logger = logger;

            ConfigSettingsOfEF = configSettingsOfEF;
            ConfigSettingsOfEFSqlServer = configSettingsOfEFSqlServer;
            DbFactory = dbFactory;
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
            using MapperDbContext dbContext = DbFactory.CreateDbContext();

            return new
            {
                ConfigSettingsOfEF,
                ConfigSettingsOfEFSqlServer,
                DbFactory.EntitiesSettings,
                dbContext.Database.ProviderName
            };
        }
    }
}
