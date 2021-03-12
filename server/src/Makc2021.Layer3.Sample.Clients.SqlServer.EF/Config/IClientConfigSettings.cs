// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2021.Layer3.Sample.Clients.SqlServer.EF.Config
{
    /// <summary>
    /// Интерфейс настроек конфигурации клиента.
    /// </summary>
    public interface IClientConfigSettings
    {
        #region Properties

        /// <summary>
        /// Строка подключения.
        /// </summary>
        string ConnectionString { get; }

        #endregion Properties
    }
}