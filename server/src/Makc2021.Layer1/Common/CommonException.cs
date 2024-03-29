﻿// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System;

namespace Makc2021.Layer1.Common
{
    /// <summary>
    /// Общее исключение.
    /// Сообщение, передаваемое в это исключение, должно быть переведено на язык,
    /// соответствующий текущей культуре приложения.
    /// </summary>
    public class CommonException : Exception
    {
        #region Constructors

        /// <inheritdoc/>
        public CommonException(string message)
            : base(message)
        {
        }

        #endregion Constructors
    }
}
