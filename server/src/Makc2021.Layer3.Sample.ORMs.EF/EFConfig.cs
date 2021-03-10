//Author Maxim Kuzmin//makc//

using Makc2021.Layer1;
using Makc2021.Layer3.Sample.ORMs.EF.Config;
using System.IO;

namespace Makc2021.Layer3.Sample.ORMs.EF
{
    /// <summary>
    /// ORM "Entity Framework". Конфигурация.
    /// </summary>
    public class EFConfig
    {
        #region Properties

        private Environment Environment { get; set; }

        private string FilePath { get; set; }

        /// <summary>
        /// Настройки.
        /// </summary>
        public IEFConfigSettings Settings { get; private set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="environment">Окружение.</param>
        public EFConfig(Environment environment)
        {
            Environment = environment;

            FilePath = CreateFilePath();

            Settings = EFConfigSettings.Create(FilePath, Environment);
        }

        #endregion Constructors

        #region Internal methods

        /// <summary>
        /// Создать путь к файлу.
        /// </summary>
        /// <returns>Путь к файлу.</returns>
        internal static string CreateFilePath()
        {
            return Path.Combine("ConfigFiles", "Layer3.Sample.ORMs.EF.config");
        }

        #endregion Internal methods
    }
}
