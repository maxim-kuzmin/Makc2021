//Author Maxim Kuzmin//makc//

using Makc2021.Layer3.Sample.ORMs.EF.Db;
using Makc2021.Layer3.Sample.ORMs.EF.DBs.SqlServer.Config;
using Makc2021.Layer3.Sample.ORMs.EF.DBs.SqlServer.Db;

namespace Makc2021.Layer3.Sample.ORMs.EF.DBs.SqlServer
{
    /// <summary>
    /// ORM "Entity Framework". База данных "Microsoft SQL Server". Контекст.
    /// </summary>
    public class EFSqlServerContext
    {
        #region Properties

        /// <summary>
        /// Конфигурационные настройки.
        /// </summary>
        public IEFSqlServerConfigSettings ConfigSettings { get; private set; }

        /// <summary>
        /// Фабрика базы данных.
        /// </summary>
        public IEFDbFactory DbFactory { get; private set; }

        /// <summary>
        /// Настройки сущностей.
        /// </summary>
        public EntitiesSettings EntitiesSettings { get; } = EFSqlServerEntitiesSettings.Instance;

        #endregion Properties

        #region Constructor

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="configSettings">Конфигурационные настройки.</param>
        /// <param name="externals">Внешнее.</param>
        public EFSqlServerContext(IEFSqlServerConfigSettings configSettings, EFSqlServerExternals externals)
        {
            ConfigSettings = configSettings;

            DbFactory = new EFSqlServerDbFactory(
                ConfigSettings.ConnectionString,
                EntitiesSettings,
                externals.Environment
                );
        }

        #endregion Constructo
    }
}
