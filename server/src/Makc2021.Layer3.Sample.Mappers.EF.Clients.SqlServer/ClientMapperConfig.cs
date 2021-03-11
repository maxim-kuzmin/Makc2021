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

        private Environment Environment { get; set; }

        private string FilePath { get; set; }

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
            Environment = environment;

            FilePath = CreateFilePath();

            Settings = ClientMapperConfigSettings.Create(FilePath, Environment);
        }

        #endregion Constructors

        #region Internal methods

        /// <summary>
        /// Создать путь к файлу.
        /// </summary>
        /// <returns>Путь к файлу.</returns>
        internal static string CreateFilePath()
        {
            return Path.Combine("ConfigFiles", "Layer3.Sample.Mappers.EF.Clients.SqlServer.config");
        }

        #endregion Internal methods
    }
}
