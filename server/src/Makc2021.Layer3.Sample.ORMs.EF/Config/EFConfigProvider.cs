//Author Maxim Kuzmin//makc//

using Makc2021.Layer1;
using Makc2021.Layer1.Config.Providers;

namespace Makc2021.Layer3.Sample.ORMs.EF.Config
{
    /// <summary>
    /// ORM "Entity Framework". Конфигурация. Поставщик.
    /// </summary>
    public class EFConfigProvider : JsonConfigProvider<EFConfigSettings>
    {
        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="settings">Настройки.</param>
        /// <param name="filePath">Путь к файлу.</param>
        /// <param name="environment">Окружение.</param>
        public EFConfigProvider(EFConfigSettings settings, string filePath, Environment environment)
            : base(settings, filePath, environment)
        {
        }

        #endregion Constructors
    }
}
