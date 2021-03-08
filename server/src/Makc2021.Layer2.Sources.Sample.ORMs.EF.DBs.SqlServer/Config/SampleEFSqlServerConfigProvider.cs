//Author Maxim Kuzmin//makc//

using Makc2021.Layer1;
using Makc2021.Layer1.Config.Providers;

namespace Makc2021.Layer2.Sources.Sample.ORMs.EF.DBs.SqlServer.Config
{
    /// <summary>
    /// Источник "Sample". ORM "Entity Framework". База данных "Microsoft SQL Server". Конфигурация. Поставщик.
    /// </summary>
    public class SampleEFSqlServerConfigProvider : JsonConfigProvider<SampleEFSqlServerConfigSettings>
    {
        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="settings">Настройки.</param>
        /// <param name="filePath">Путь к файлу.</param>
        /// <param name="environment">Окружение.</param>
        public SampleEFSqlServerConfigProvider(
            SampleEFSqlServerConfigSettings settings,
            string filePath,
            Environment environment
            )
            : base(settings, filePath, environment)
        {
        }

        #endregion Constructors
    }
}
