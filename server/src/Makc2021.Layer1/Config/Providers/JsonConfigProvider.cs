//Author Maxim Kuzmin//makc//

using Makc2021.Layer1.Serializations;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Makc2021.Layer1.Config.Providers
{
    /// <summary>
    /// Конфигурация. Поставщик JSON.
    /// </summary>
    /// <typeparam name="TSettings">Тип настроек.</typeparam>
    public class JsonConfigProvider<TSettings> : ConfigProvider<TSettings>
    {
        #region Properties

        private Environment Environment { get; set; }

        private string FilePath { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="settings">Настройки.</param>
        /// <param name="filePath">Путь к файлу.</param>
        /// <param name="environment">Окружение.</param>
        public JsonConfigProvider(TSettings settings, string filePath, Environment environment)
            : base(settings)
        {
            FilePath = filePath;
            Environment = environment;            
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override void Load()
        {
            var configurationBuilder = new ConfigurationBuilder();

            var isAbsolutePath = FilePath.StartsWith(
                Environment.BasePath,
                StringComparison.InvariantCultureIgnoreCase
                );

            var absolutePathToFile = isAbsolutePath
                ? FilePath
                : Path.Combine(Environment.BasePath, FilePath);

            var isPathToFileWithExtension = FilePath.EndsWith(
                ".json",
                StringComparison.InvariantCultureIgnoreCase
                );

            if (isPathToFileWithExtension)
            {
                configurationBuilder.AddJsonFile(absolutePathToFile);
            }
            else
            {
                configurationBuilder.AddFromJsonFile(
                    absolutePathToFile,
                    Environment.Name
                    );
            }

            var configuration = configurationBuilder.AddEnvironmentVariables().Build();

            configuration.Bind(Settings);
        }

        /// <inheritdoc/>
        public sealed override void Save()
        {
            var contents = Settings.SerializeToJson(JsonSerialization.OptionsForConfig);

            File.WriteAllText(FilePath, contents);
        }

        #endregion Public methods
    }
}
