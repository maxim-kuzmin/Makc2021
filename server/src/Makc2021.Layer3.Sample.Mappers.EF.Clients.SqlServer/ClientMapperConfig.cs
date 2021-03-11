//Author Maxim Kuzmin//makc//

using Makc2021.Layer1;
using Makc2021.Layer3.Sample.Mappers.EF.Clients.SqlServer.Config;
using System.IO;

namespace Makc2021.Layer3.Sample.Mappers.EF.Clients.SqlServer
{
    /// <summary>
    /// Конфигурация ORM клиента.
    /// </summary>
    public class ClientMapperConfig
    {
        #region Properties

        /// <summary>
        /// Путь к файлу.
        /// </summary>
        internal static string FilePath { get; } = Path.Combine("ConfigFiles", "Layer3.Sample.Mappers.EF.Clients.SqlServer.config");

        /// <summary>
        /// Настройки.
        /// </summary>
        public IClientMapperConfigSettings Settings { get; private set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="environment">Окружение.</param>
        public ClientMapperConfig(Environment environment)
        {
            Settings = ClientMapperConfigSettings.Create(FilePath, environment);
        }

        #endregion Constructors
    }
}
