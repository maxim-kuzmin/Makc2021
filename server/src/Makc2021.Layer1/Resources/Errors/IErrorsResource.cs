// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System;

namespace Makc2021.Layer1.Resources.Errors
{
    /// <summary>
    /// Интерфейс ресурса ошибок.
    /// </summary>
    public interface IErrorsResource
    {
        #region Methods

        /// <summary>
        /// Получить сообщение об ошибке HTTP "Доступ запрещён".
        /// </summary>
        /// <returns>Сообщение об ошибке.</returns>
        string GetHttp403ErrorMessage();

        /// <summary>
        /// Получить сообщение об ошибке HTTP "Страница не найдена".
        /// </summary>
        /// <returns>Сообщение об ошибке.</returns>
        string GetHttp404ErrorMessage();

        /// <summary>
        /// Получить сообщение об ошибке при попытке использования неимпортированного типа.
        /// </summary>
        /// <param name="type">Тип.</param>
        /// <returns>Сообщение об ошибке.</returns>
        string GetTypeIsNotImportedErrorMessage(Type type);

        #endregion Methods
    }
}
