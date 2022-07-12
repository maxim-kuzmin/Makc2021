// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2021.Layer5.Sql.GrpcClient.Config
{
    /// <summary>
    /// Интерфейс настроек конфигурации.
    /// </summary>
    public interface IConfigSettings
    {
        #region Properties

        /// <summary>
        /// URL сервера.
        /// </summary>
        string ServerUrl { get; }

        #endregion Properties
    }
}