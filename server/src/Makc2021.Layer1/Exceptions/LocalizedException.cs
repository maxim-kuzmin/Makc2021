// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System;

namespace Makc2021.Layer1.Query.Exceptions
{
    /// <summary>
    /// Локализованное исключение.
    /// </summary>
    public class LocalizedException : Exception
    {
        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="message">Сообщение.</param>
        public LocalizedException(string message)
            : base(message)
        {
        }

        #endregion Constructors
    }
}
