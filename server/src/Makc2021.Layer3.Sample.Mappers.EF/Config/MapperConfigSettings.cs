//Author Maxim Kuzmin//makc//

using Makc2021.Layer1;

namespace Makc2021.Layer3.Sample.Mappers.EF.Config
{
    /// <summary>
    /// Настройки конфигурации ORM.
    /// </summary>
    public class MapperConfigSettings : IMapperConfigSettings
    {
        #region Properties

        /// <inheritdoc/>
        public int DbCommandTimeout { get; set; }

        #endregion Properties

        #region Internal methods

        /// <summary>
        /// Создать.
        /// </summary>
        /// <param name="configFilePath">Путь к файлу конфигурации.</param>
        /// <param name="environment">Окружение.</param>
        /// <returns>Конфигурационные настройки.</returns>
        internal static IMapperConfigSettings Create(string configFilePath, Environment environment)
        {
            var result = new MapperConfigSettings();

            var configProvider = new MapperConfigProvider(result, configFilePath, environment);

            configProvider.Load();

            return result;
        }

        #endregion Internal methods
    }
}