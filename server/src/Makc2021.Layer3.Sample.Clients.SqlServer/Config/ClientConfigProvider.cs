﻿// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2021.Layer1.Common;
using Makc2021.Layer1.Common.Config.Json;

namespace Makc2021.Layer3.Sample.Clients.SqlServer.Config
{
    /// <summary>
    /// Поставщик конфигурации клиента.
    /// </summary>
    internal class ClientConfigProvider : JsonCommonConfigProvider<ClientConfigSettings>
    {
        #region Constructors

        /// <inheritdoc/>
        public ClientConfigProvider(ClientConfigSettings settings, string filePath, CommonEnvironment environment
            )
            : base(settings, filePath, environment)
        {
        }

        #endregion Constructors
    }
}
