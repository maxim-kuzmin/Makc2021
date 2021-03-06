﻿namespace Makc2021.Layer1.Base
{
    /// <summary>
    /// Слой "Layer1". Основа. Окружение.
    /// </summary>
    public class Layer1BaseEnvironment
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