//Author Maxim Kuzmin//makc//

using Makc2021.Layer1;
using Makc2021.Layer2.Sources.Sample.ORMs.EF.DBs.SqlServer.Config;
using System.IO;

namespace Makc2021.Layer2.Sources.Sample.ORMs.EF.DBs.SqlServer
{
    /// <summary>
    /// Источник "Sample". ORM "Entity Framework". База данных "Microsoft SQL Server". Конфигурация.
    /// </summary>
    public class SampleEFSqlServerConfig
    {
        #region Properties

        private Environment Environment { get; set; }

        private string FilePath { get; set; }

        /// <summary>
        /// Настройки.
        /// </summary>
        public ISampleEFSqlServerConfigSettings Settings { get; private set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="environment">Окружение.</param>
        public SampleEFSqlServerConfig(Environment environment)
        {
            Environment = environment;

            FilePath = CreateFilePath();

            Settings = SampleEFSqlServerConfigSettings.Create(FilePath, Environment);
        }

        #endregion Constructors

        #region Internal methods

        /// <summary>
        /// Создать путь к файлу.
        /// </summary>
        /// <returns>Путь к файлу.</returns>
        internal static string CreateFilePath()
        {
            return Path.Combine("ConfigFiles", "Layer2.Sources.Sample.ORMs.EF.DBs.SqlServer.config");
        }

        #endregion Internal methods

        #region Рublic methods

        /// <summary>
        /// Создать поставщика.
        /// </summary>
        /// <param name="settings">Настройки.</param>
        public SampleEFSqlServerConfigProvider CreateProvider(SampleEFSqlServerConfigSettings settings)
        {
            return new SampleEFSqlServerConfigProvider(settings, FilePath, Environment);
        }

        #endregion Рublic methods
    }
}
