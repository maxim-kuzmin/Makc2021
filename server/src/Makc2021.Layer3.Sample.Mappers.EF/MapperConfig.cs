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

        private Environment Environment { get; set; }

        private string FilePath { get; set; }

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
            Environment = environment;

            FilePath = CreateFilePath();

            Settings = MapperConfigSettings.Create(FilePath, Environment);
        }

        #endregion Constructors

        #region Internal methods

        /// <summary>
        /// Создать путь к файлу.
        /// </summary>
        /// <returns>Путь к файлу.</returns>
        internal static string CreateFilePath()
        {
            return Path.Combine("ConfigFiles", "Layer3.Sample.Mappers.EF.config");
        }

        #endregion Internal methods
    }
}
