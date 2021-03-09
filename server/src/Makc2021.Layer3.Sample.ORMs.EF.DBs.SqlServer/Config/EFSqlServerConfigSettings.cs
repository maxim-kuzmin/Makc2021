//Author Maxim Kuzmin//makc//

using Makc2021.Layer1;

namespace Makc2021.Layer3.Sample.ORMs.EF.DBs.SqlServer.Config
{
    /// <summary>
    /// ORM "Entity Framework". База данных "Microsoft SQL Server". Конфигурация. Настройки.
    /// </summary>
    public class EFSqlServerConfigSettings : IEFSqlServerConfigSettings
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
        internal static IEFSqlServerConfigSettings Create(
            string configFilePath,
            Environment environment
            )
        {
            var result = new EFSqlServerConfigSettings();

            var configProvider = new EFSqlServerConfigProvider(result, configFilePath, environment);

            configProvider.Load();

            return result;
        }

        #endregion Internal methods
    }
}