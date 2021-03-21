// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2021.Layer1.Common;
using Makc2021.Layer1.Config.Json;

namespace Makc2021.Layer3.Sample.Mappers.EF.Config
{
    /// <summary>
    /// Поставщик конфигурации сопоставителя.
    /// </summary>
    internal class MapperConfigProvider : JsonConfigProvider<MapperConfigSettings>
    {
        #region Constructors

        /// <inheritdoc/>
        public MapperConfigProvider(MapperConfigSettings settings, string filePath, CommonEnvironment environment)
            : base(settings, filePath, environment)
        {
        }

        #endregion Constructors
    }
}
