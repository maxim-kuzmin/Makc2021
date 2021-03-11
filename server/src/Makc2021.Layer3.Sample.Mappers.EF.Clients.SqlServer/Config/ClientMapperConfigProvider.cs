//Author Maxim Kuzmin//makc//

using Makc2021.Layer1;
using Makc2021.Layer1.Config.Providers;

namespace Makc2021.Layer3.Sample.Mappers.EF.Clients.SqlServer.Config
{
    /// <summary>
    /// Поставщик конфигурации ORM клиента.
    /// </summary>
    public class ClientMapperConfigProvider : JsonConfigProvider<ClientMapperConfigSettings>
    {
        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="settings">Настройки.</param>
        /// <param name="filePath">Путь к файлу.</param>
        /// <param name="environment">Окружение.</param>
        public ClientMapperConfigProvider(ClientMapperConfigSettings settings, string filePath, Environment environment)
            : base(settings, filePath, environment)
        {
        }

        #endregion Constructors
    }
}
