// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2021.Layer1;
using Makc2021.Layer3.Sample.Clients.SqlServer.EF.Config;
using Makc2021.Layer3.Sample.Clients.SqlServer.EF.Db;
using Makc2021.Layer3.Sample.Mappers.EF.Db;

namespace Makc2021.Layer3.Sample.Clients.SqlServer.EF
{
    /// <summary>
    /// Контекст клиента.
    /// </summary>
    public class ClientContext
    {
        #region Properties

        /// <summary>
        /// Конфигурационные настройки.
        /// </summary>
        public IClientConfigSettings ConfigSettings { get; }

        /// <summary>
        /// Фабрика базы данных.
        /// </summary>
        public IMapperDbFactory DbFactory { get; }

        /// <summary>
        /// Настройки сущностей.
        /// </summary>
        public EntitiesSettings EntitiesSettings { get; } = ClientEntitiesSettings.Instance;

        #endregion Properties

        #region Constructor

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="configSettings">Конфигурационные настройки.</param>
        /// <param name="environment">Окружение.</param>
        public ClientContext(IClientConfigSettings configSettings, Environment environment)
        {
            ConfigSettings = configSettings;

            DbFactory = new ClientDbFactory(
                ConfigSettings.ConnectionString,
                EntitiesSettings,
                environment
                );
        }

        #endregion Constructo
    }
}
