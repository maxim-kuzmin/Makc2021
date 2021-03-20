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
        /// Получить строку "Неизвестная ошибка".
        /// </summary>
        /// <returns>Строка.</returns>
        string GetStringUnknownError();

        /// <summary>
        /// Получить строку форматирования "{0}. Код ошибки: {1}".
        /// </summary>
        /// <returns>Строка.</returns>
        string GetStringFormatMessageWithCode();

        /// <summary>
        /// Получить строку форматирования ". URL: {2}".
        /// </summary>
        /// <returns>Строка.</returns>
        string GetStringFormatMessagePartWithUrl();

        /// <summary>
        /// Получить для недействительных входных данных запроса.
        /// </summary>
        /// <param name="invalidProperties">Недействительные свойства.</param>
        /// <returns>Сообщение об ошибке.</returns>
        string GetForIvalidQueryInput(IEnumerable<string> invalidProperties);

        #endregion Methods
    }
}
