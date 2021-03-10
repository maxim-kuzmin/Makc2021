//Author Maxim Kuzmin//makc//

using Makc2021.Layer1;
using Makc2021.Layer1.Config.Providers;

namespace Makc2021.Layer3.Sample.ORMs.EF.DBs.SqlServer.Config
{
    /// <summary>
    /// ORM "Entity Framework". База данных "Microsoft SQL Server". Конфигурация. Поставщик.
    /// </summary>
    public class EFSqlServerConfigProvider : JsonConfigProvider<EFSqlServerConfigSettings>
    {
        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="settings">Настройки.</param>
        /// <param name="filePath">Путь к файлу.</param>
        /// <param name="environment">Окружение.</param>
        public EFSqlServerConfigProvider(EFSqlServerConfigSettings settings, string filePath, Environment environment)
            : base(settings, filePath, environment)
        {
        }

        #endregion Constructors
    }
}
