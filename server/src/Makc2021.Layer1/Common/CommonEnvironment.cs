// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2021.Layer1.Common
{
    /// <summary>
    /// Общее окружение.
    /// </summary>
    public class CommonEnvironment
    {
        #region Properties

        /// <summary>
        /// Базовый путь: абсолютный путь к папке, относительно которой указываются пути к файлам.
        /// </summary>
        public string BasePath { get; set; } = System.AppContext.BaseDirectory;

        /// <summary>
        /// Имя.
        /// </summary>
        public string Name { get; set; } = System.Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

        #endregion Properties
    }
}
