// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2021.Layer3.Sample.Entities.DummyMainDummyManyToMany
{
    /// <summary>
    /// Объект сущности "DummyMainDummyManyToMany".
    /// </summary>
    public class DummyMainDummyManyToManyEntityObject
    {
        #region Properties

        /// <summary>
        /// Идентификатор сущности "DummyMain".
        /// </summary>
        public long IdOfDummyMainEntity { get; set; }

        /// <summary>
        /// Идентификатор сущности "DummyManyToMany".
        /// </summary>
        public long IdOfDummyManyToManyEntity { get; set; }

        #endregion Properties
    }
}
