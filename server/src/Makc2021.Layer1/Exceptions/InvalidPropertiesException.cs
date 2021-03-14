// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Makc2021.Layer1.Query.Exceptions
{
    /// <summary>
    /// Исключение, возникающее в случае наличия недействительных свойств.
    /// </summary>
    public class InvalidPropertiesException : Exception
    {
        #region Properties

        /// <summary>
        /// Список свойств с недействительными значениями.
        /// </summary>
        public List<string> InvalidProperties { get; private set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="invalidProperties">Список свойств с недействительными значениями.</param>
        public InvalidPropertiesException(List<string> invalidProperties)
            : base(CreateErrorMessage(invalidProperties))
        {
            InvalidProperties = invalidProperties;
        }

        #endregion Constructors

        #region Private methods

        private static string CreateErrorMessage(List<string> invalidProperties)
        {
            return $"Invalid properties: {string.Join(", ", invalidProperties)}";
        }

        #endregion Private methods
    }
}
