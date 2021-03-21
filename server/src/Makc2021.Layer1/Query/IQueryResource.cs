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
        /// Получить сообщение об ошибке по умолчанию.
        /// </summary>
        /// <returns>Сообщение об ошибке.</returns>
        string GetErrorMessageForDefault();

        /// <summary>
        /// Получить сообщение об ошибке для недействительных входных данных.
        /// </summary>
        /// <param name="invalidProperties">Недействительные свойства.</param>
        /// <returns>Сообщение об ошибке.</returns>
        string GetErrorMessageForInvalidInput(IEnumerable<string> invalidProperties);

        /// <summary>
        /// Получить сообщение об ошибке с кодом.
        /// </summary>
        /// <param name="errorMessage">Сообщение об ошибке.</param>
        /// <param name="code">Код.</param>
        /// <returns>Сообщение об ошибке.</returns>
        string GetErrorMessageWithCode(string errorMessage, string code);

        /// <summary>
        /// Получить заголовок для входных данных.
        /// </summary>
        /// <returns>Заголовок.</returns>
        string GetTitleForInput();

        /// <summary>
        /// Получить заголовок для результата.
        /// </summary>
        /// <returns>Заголовок.</returns>
        string GetTitleForResult();
        
        #endregion Methods
    }
}
