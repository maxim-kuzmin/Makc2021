// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2021.Layer3.Sample.Entities.DummyTreeLink
{
    /// <summary>
    /// Объект сущности "DummyTreeLink".
    /// </summary>
    public class DummyTreeLinkEntityObject
    {
        #region Properties

        /// <summary>
        /// Идентификатор узла.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Идентификатор родительского узла.
        /// </summary>
        public long ParentId { get; set; }

        #endregion Properties
    }
}
