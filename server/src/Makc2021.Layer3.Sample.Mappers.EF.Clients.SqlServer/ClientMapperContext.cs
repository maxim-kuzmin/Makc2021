//Author Maxim Kuzmin//makc//

using Makc2021.Layer3.Sample.Mappers.EF.Db;
using Makc2021.Layer3.Sample.Mappers.EF.Clients.SqlServer.Config;
using Makc2021.Layer3.Sample.Mappers.EF.Clients.SqlServer.Db;

namespace Makc2021.Layer3.Sample.Mappers.EF.Clients.SqlServer
{
    /// <summary>
    /// Контекст ORM клиента.
    /// </summary>
    public class ClientMapperContext
    {
        #region Properties

        /// <summary>
        /// Конфигурационные настройки.
        /// </summary>
        public IClientMapperConfigSettings ConfigSettings { get; private set; }

        /// <summary>
        /// Фабрика базы данных.
        /// </summary>
        public IMapperDbFactory DbFactory { get; private set; }

        /// <summary>
        /// Настройки сущностей.
        /// </summary>
        public EntitiesSettings EntitiesSettings { get; } = ClientMapperEntitiesSettings.Instance;

        #endregion Properties

        #region Constructor

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="configSettings">Конфигурационные настройки.</param>
        /// <param name="externals">Внешние зависимости.</param>
        public ClientMapperContext(IClientMapperConfigSettings configSettings, ClientMapperExternals externals)
        {
            ConfigSettings = configSettings;

            DbFactory = new ClientMapperDbFactory(
                ConfigSettings.ConnectionString,
                EntitiesSettings,
                externals.Environment
                );
        }

        #endregion Constructo
    }
}
