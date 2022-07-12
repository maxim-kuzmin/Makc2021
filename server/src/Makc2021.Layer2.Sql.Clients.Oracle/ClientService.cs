// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2021.Layer2.Sql.Clients.Oracle.Config;
using Oracle.ManagedDataAccess.Client;

namespace Makc2021.Layer2.Sql.Clients.Oracle
{
    /// <summary>
    /// Сервис клиента.
    /// </summary>
    public class ClientService : IClientService
    {
        #region Properties

        private IClientConfigSettings ConfigSettings { get; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="configSettings">Настройки конфигурации.</param>
        public ClientService(IClientConfigSettings configSettings)
        {
            ConfigSettings = configSettings;
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public void Configure()
        {
            OracleConfiguration.TnsAdmin = ConfigSettings.TnsAdmin;
        }

        #endregion Public methods
    }
}
