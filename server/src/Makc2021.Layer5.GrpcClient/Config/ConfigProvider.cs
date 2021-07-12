// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2021.Layer1.Common;
using Makc2021.Layer1.Common.Config.Json;

namespace Makc2021.Layer5.GrpcClient.Config
{
    /// <summary>
    /// Поставщик конфигурации.
    /// </summary>
    internal class ConfigProvider : JsonCommonConfigProvider<ConfigSettings>
    {
        #region Constructors

        /// <inheritdoc/>
        public ConfigProvider(ConfigSettings settings, string filePath, CommonEnvironment environment)
            : base(settings, filePath, environment)
        {
        }

        #endregion Constructors
    }
}
