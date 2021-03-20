// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System.Collections.Generic;
using Makc2021.Layer1.Common;

namespace Makc2021.Layer1.Query.Exceptions
{
    /// <summary>
    /// Исключение, возникающее в случае недействительных входных данных.
    /// </summary>
    public class InvalidQueryInputException : CommonException
    {
        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="resource">Ресурс.</param>
        /// <param name="invalidProperties">Список свойств с недействительными значениями.</param>
        public InvalidQueryInputException(IQueryResource resource, List<string> invalidProperties)
            : base(resource.GetForIvalidQueryInput(invalidProperties))
        {
        }

        #endregion Constructors
    }
}
