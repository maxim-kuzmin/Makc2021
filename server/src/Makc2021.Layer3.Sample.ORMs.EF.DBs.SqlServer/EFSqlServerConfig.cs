//Author Maxim Kuzmin//makc//

using Makc2021.Layer1;
using Makc2021.Layer3.Sample.ORMs.EF.DBs.SqlServer.Config;
using System.IO;

namespace Makc2021.Layer3.Sample.ORMs.EF.DBs.SqlServer
{
    /// <summary>
    /// ORM "Entity Framework". База данных "Microsoft SQL Server". Конфигурация.
    /// </summary>
    public class EFSqlServerConfig
    {
        #region Properties

        private Environment Environment { get; set; }

        private string FilePath { get; set; }

        /// <summary>
        /// Настройки.
        /// </summary>
        public IEFSqlServerConfigSettings Settings { get; private set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="environment">Окружение.</param>
        public EFSqlServerConfig(Environment environment)
        {
            Environment = environment;

            FilePath = CreateFilePath();

            Settings = EFSqlServerConfigSettings.Create(FilePath, Environment);
        }

        #endregion Constructors

        #region Internal methods

        /// <summary>
        /// Создать путь к файлу.
        /// </summary>
        /// <returns>Путь к файлу.</returns>
        internal static string CreateFilePath()
        {
            return Path.Combine("ConfigFiles", "Layer3.Sample.ORMs.EF.DBs.SqlServer.config");
        }

        #endregion Internal methods
    }
}
