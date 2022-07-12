// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2021.Layer3.Sql.Sample.Entities.DummyTreeLink
{
    /// <summary>
    /// Объект сущности "DummyTreeLink".
    /// </summary>
    public class DummyTreeLinkEntityObject
    {
        #region Properties

        /// <summary>
        /// Идентификатор.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Идентификатор родителя.
        /// </summary>
        public long ParentId { get; set; }

        #endregion Properties
    }
}
