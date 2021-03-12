// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System;

namespace Makc2021.Layer1.Exceptions
{
    /// <summary>
    /// Исключение, возникающее в случае, если тип не готов.
    /// </summary>
    public class TypeIsNotReadyException : Exception
    {
        #region Constructors

        public TypeIsNotReadyException(Type type)
            : base($"{type} is not ready")
        {
        }

        #endregion Constructors
    }
}
