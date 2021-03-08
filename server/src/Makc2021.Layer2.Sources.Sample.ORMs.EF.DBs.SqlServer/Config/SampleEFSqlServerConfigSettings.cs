//Author Maxim Kuzmin//makc//

using Makc2021.Layer1;

namespace Makc2021.Layer2.Sources.Sample.ORMs.EF.DBs.SqlServer.Config
{
    /// <summary>
    /// Источник "Sample". ORM "Entity Framework". База данных "Microsoft SQL Server". Конфигурация. Настройки.
    /// </summary>
    public class SampleEFSqlServerConfigSettings : ISampleEFSqlServerConfigSettings
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
        internal static ISampleEFSqlServerConfigSettings Create(
            string configFilePath,
            Environment environment
            )
        {
            var result = new SampleEFSqlServerConfigSettings();

            var configProvider = new SampleEFSqlServerConfigProvider(result, configFilePath, environment);

            configProvider.Load();

            return result;
        }

        #endregion Internal methods
    }
}