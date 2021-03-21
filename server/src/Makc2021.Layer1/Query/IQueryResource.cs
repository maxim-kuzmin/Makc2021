// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System.Collections.Generic;

namespace Makc2021.Layer1.Query
{
    /// <summary>
    /// Интерфейс ресурса запроса.
    /// </summary>
    public interface IQueryResource
    {
        #region Methods

        /// <summary>
        /// Получить сообщение об ошибке с кодом и URL.
        /// </summary>
        /// <param name="prefix">Префикс.</param>
        /// <param name="code">Код.</param>
        /// <param name="url">URL.</param>
        /// <returns>Сообщение об ошибке.</returns>
        string GetErrorMessageWithCodeAndUrl(string prefix, string code, string url);

        /// <summary>
        /// Получить сообщение об ошибке при наличии недействительных входных данных.
        /// </summary>
        /// <param name="invalidProperties">Недействительные свойства.</param>
        /// <returns>Сообщение об ошибке.</returns>
        string GetInvalidQueryInputErrorMessage(IEnumerable<string> invalidProperties);

        /// <summary>
        /// Получить сообщение о неизвестной ошибке.
        /// </summary>
        /// <returns>Сообщение об ошибке.</returns>
        string GetUnknownErrorMessage();
        
        #endregion Methods
    }
}
