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

        /// <summary>
        /// Конфигурация.
        /// </summary>
        public EFSqlServerConfig Config { get; private set; }

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
            services.AddTransient(x => Config);
            services.AddTransient(x => Config.Settings);
            services.AddTransient(x => Context.DbFactory);
            services.AddTransient(x => Context.Settings);
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
            Context = new EFSqlServerContext(Config, externals);
        }

        #endregion Public methods
    }
}
