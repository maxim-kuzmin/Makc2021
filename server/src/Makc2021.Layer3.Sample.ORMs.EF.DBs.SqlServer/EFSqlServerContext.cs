//Author Maxim Kuzmin//makc//

using Makc2021.Layer3.Sample.ORMs.EF.Db;
using Makc2021.Layer3.Sample.ORMs.EF.DBs.SqlServer.Db;

namespace Makc2021.Layer3.Sample.ORMs.EF.DBs.SqlServer
{
    public class EFSqlServerContext
    {
        #region Properties

        /// <summary>
        /// Конфигурация.
        /// </summary>
        public EFSqlServerConfig Config { get; private set; }

        /// <summary>
        /// Фабрика базы данных.
        /// </summary>
        public EFDbFactory DbFactory { get; private set; }

        /// <summary>
        /// Настройки.
        /// </summary>
        public Settings Settings { get; } = EFSqlServerSettings.Instance;

        #endregion Properties

        #region Constructor

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="config">Конфигурация.</param>
        /// <param name="externals">Внешнее.</param>
        public EFSqlServerContext(
            EFSqlServerConfig
            config,
            EFSqlServerExternals externals
            )
        {
            Config = config;

            DbFactory = new EFSqlServerDbFactory(
                Config.Settings.ConnectionString,
                Settings,
                externals.Environment
                );
        }

        #endregion Constructo
    }
}
