// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System.IO;
using Makc2021.Layer1;
using Makc2021.Layer3.Sample.Mappers.EF.Config;

namespace Makc2021.Layer3.Sample.Mappers.EF
{
    /// <summary>
    /// Конфигурация сопоставителя.
    /// </summary>
    internal class MapperConfig
    {
        #region Properties

        /// <summary>
        /// Путь к файлу.
        /// </summary>
        public static string FilePath { get; } = Path.Combine("ConfigFiles", "Layer3.Sample.Mappers.EF.config");

        /// <summary>
        /// Настройки.
        /// </summary>
        public IMapperConfigSettings Settings { get; private set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="environment">Окружение.</param>
        public MapperConfig(Environment environment)
        {
            Settings = MapperConfigSettings.Create(FilePath, environment);
        }

        #endregion Constructors
    }
}
