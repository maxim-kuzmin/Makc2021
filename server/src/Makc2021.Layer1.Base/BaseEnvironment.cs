namespace Makc2021.Layer1.Base
{
    /// <summary>
    /// Основа. Окружение.
    /// </summary>
    public class BaseEnvironment
    {
        #region Properties

        /// <summary>
        /// Базовый путь: абсолютный путь к папке, относительно которой указываются пути к файлам.
        /// </summary>
        public string BasePath { get; set; }

        /// <summary>
        /// Имя.
        /// </summary>
        public string Name { get; set; }

        #endregion Properties
    }
}
