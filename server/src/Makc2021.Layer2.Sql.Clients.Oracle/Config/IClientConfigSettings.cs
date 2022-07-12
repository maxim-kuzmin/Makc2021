// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2021.Layer2.Sql.Clients.Oracle.Config
{
    /// <summary>
    /// Интерфейс настроек конфигурации клиента.
    /// </summary>
    public interface IClientConfigSettings
    {
        #region Properties

        /// <summary>
        /// Путь к файлу tnsnames.ora.
        /// </summary>
        string TnsAdmin { get; }

        #endregion Properties
    }
}