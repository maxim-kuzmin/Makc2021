using Makc2021.Layer3.Sample.ORMs.EF.Config;
using Makc2021.Layer3.Sample.ORMs.EF.Db;
using Makc2021.Layer3.Sample.ORMs.EF.DBs.SqlServer.Config;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

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

        private IEFConfigSettings ConfigSettingsOfEF { get; }
        private IEFSqlServerConfigSettings ConfigSettingsOfEFSqlServer { get; }        
        private IEFDbFactory DbFactory { get; }

        public WeatherForecastController(
            ILogger<WeatherForecastController> logger,
            IEFConfigSettings configSettingsOfEF,
            IEFSqlServerConfigSettings configSettingsOfEFSqlServer,
            IEFDbFactory dbFactory
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
            var rng = new Random();
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
            using var dbContext = DbFactory.CreateDbContext();

            return new
            {
                ConfigSettingsOfEF,
                ConfigSettingsOfEFSqlServer,
                DbFactory.Settings,
                dbContext.Database.ProviderName
            };
        }
    }
}
