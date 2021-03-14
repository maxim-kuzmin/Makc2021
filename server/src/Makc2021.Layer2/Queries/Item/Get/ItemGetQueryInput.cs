// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System.Collections.Generic;

namespace Makc2021.Layer2.Queries.Item.Get
{
    /// <summary>
    /// Ввод запроса на получение элемента.
    /// </summary>
    public class ItemGetQueryInput
    {
        #region Properties

        /// <summary>
        /// Идентификатор сущности.
        /// </summary>
        public long EntityId { get; set; }

        #endregion Properties

        #region Public methods

        /// <summary>
        /// Нормализовать.
        /// </summary>
        public virtual void Normalize()
        {
            if (EntityId < 0)
            {
                EntityId = 0;
            }
        }

        /// <summary>
        /// Получить список свойств с недействительными значениями.
        /// </summary>
        /// <returns>Список свойств.</returns>
        public virtual List<string> GetInvalidProperties()
        {
            var result = new List<string>();

            if (EntityId < 1)
            {
                result.Add(nameof(EntityId));
            }

            return result;
        }

        #endregion Public methods
    }
}
