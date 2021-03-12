// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2021.Layer1;

namespace Makc2021.Layer3.Sample.Mappers.EF.Config
{
    /// <summary>
    /// Настройки конфигурации ORM.
    /// </summary>
    internal class MapperConfigSettings : IMapperConfigSettings
    {
        #region Properties

        /// <inheritdoc/>
        public int DbCommandTimeout { get; set; }

        #endregion Properties

        #region Public methods

        /// <summary>
        /// Создать.
        /// </summary>
        /// <param name="configFilePath">Путь к файлу конфигурации.</param>
        /// <param name="environment">Окружение.</param>
        /// <returns>Конфигурационные настройки.</returns>
        internal static IMapperConfigSettings Create(string configFilePath, Environment environment)
        {
            MapperConfigSettings result = new();

            MapperConfigProvider configProvider = new(result, configFilePath, environment);

            configProvider.Load();

            return result;
        }

        #endregion Public methods
    }
}