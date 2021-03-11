//Author Maxim Kuzmin//makc//

using Makc2021.Layer1;

namespace Makc2021.Layer3.Sample.Mappers.EF.Clients.SqlServer.Config
{
    /// <summary>
    /// Настройки конфигурации ORM клиента.
    /// </summary>
    public class ClientMapperConfigSettings : IClientMapperConfigSettings
    {
        #region Properties

        /// <inheritdoc/>
        public string ConnectionString { get; set; }

        #endregion Properties

        #region Internal methods

        /// <summary>
        /// Создать.
        /// </summary>
        /// <param name="configFilePath">Путь к файлу конфигурации.</param>
        /// <param name="environment">Окружение.</param>
        /// <returns>Конфигурационные настройки.</returns>
        internal static IClientMapperConfigSettings Create(
            string configFilePath,
            Environment environment
            )
        {
            var result = new ClientMapperConfigSettings();

            var configProvider = new ClientMapperConfigProvider(result, configFilePath, environment);

            configProvider.Load();

            return result;
        }

        #endregion Internal methods
    }
}