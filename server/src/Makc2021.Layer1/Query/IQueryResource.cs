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
        /// Получить заголовок для ошибки.
        /// </summary>
        /// <returns>Заголовок.</returns>
        string GetTitleForError();

        /// <summary>
        /// Получить заголовок для входных данных.
        /// </summary>
        /// <returns>Заголовок.</returns>
        string GetTitleForInput();

        /// <summary>
        /// Получить заголовок для кода запроса.
        /// </summary>
        /// <returns>Заголовок.</returns>
        string GetTitleForQueryCode();

        /// <summary>
        /// Получить заголовок для результата.
        /// </summary>
        /// <returns>Заголовок.</returns>
        string GetTitleForResult();

        /// <summary>
        /// Получить заголовок для начала.
        /// </summary>
        /// <returns>Заголовок.</returns>
        string GetTitleForStart();

        /// <summary>
        /// Получить заголовок для успеха.
        /// </summary>
        /// <returns>Заголовок.</returns>
        string GetTitleForSuccess();

        #endregion Methods
    }
}
