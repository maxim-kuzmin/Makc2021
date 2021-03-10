//Author Maxim Kuzmin//makc//

using Makc2021.Layer1;

namespace Makc2021.Layer3.Sample.ORMs.EF.Config
{
    /// <summary>
    /// ORM "Entity Framework". Конфигурация. Настройки.
    /// </summary>
    public class EFConfigSettings : IEFConfigSettings
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
        internal static IEFConfigSettings Create(string configFilePath, Environment environment)
        {
            var result = new EFConfigSettings();

            var configProvider = new EFConfigProvider(result, configFilePath, environment);

            configProvider.Load();

            return result;
        }

        #endregion Internal methods
    }
}