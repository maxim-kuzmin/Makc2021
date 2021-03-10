//Author Maxim Kuzmin//makc//

using Microsoft.Extensions.DependencyInjection;

namespace Makc2021.Layer3.Sample.ORMs.EF.DBs.SqlServer
{
    using Makc2021.Layer1;

    /// <summary>
    /// ORM "Entity Framework". База данных "Microsoft SQL Server". Модуль.
    /// </summary>
    public class EFSqlServerModule
    {
        #region Properties

        private EFSqlServerConfig Config { get; set; }

        /// <summary>
        /// Контекст.
        /// </summary>
        public EFSqlServerContext Context { get; private set; }

        #endregion Properties

        #region Public methods

        /// <summary>
        /// Настроить сервисы.
        /// </summary>
        /// <param name="services">Сервисы.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient(x => Context.ConfigSettings);
            services.AddTransient(x => Context.DbFactory);
            services.AddTransient(x => Context.EntitiesSettings);
        }

        /// <summary>
        /// Инициализировать конфигурацию.
        /// </summary>
        /// <param name="environment">Окружение.</param>
        public void InitConfig(Environment environment)
        {
            Config = new EFSqlServerConfig(environment);
        }

        /// <summary>
        /// Инициализировать контекст.
        /// </summary>
        /// <param name="externals">Внешнее.</param>
        public void InitContext(EFSqlServerExternals externals)
        {
            Context = new EFSqlServerContext(Config.Settings, externals);

            Config = null;
        }

        #endregion Public methods
    }
}
