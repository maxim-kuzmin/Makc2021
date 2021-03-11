//Author Maxim Kuzmin//makc//

using Makc2021.Layer1;
using Makc2021.Layer3.Sample.Mappers.EF.Config;
using System.IO;

namespace Makc2021.Layer3.Sample.Mappers.EF
{
    /// <summary>
    /// Конфигурация ORM.
    /// </summary>
    public class MapperConfig
    {
        #region Properties

        /// <summary>
        /// Путь к файлу.
        /// </summary>
        internal static string FilePath { get; } = Path.Combine("ConfigFiles", "Layer3.Sample.Mappers.EF.config");

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
