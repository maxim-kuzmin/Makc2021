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
        /// Идентификатор объекта, где хранятся данные сущности "DummyMain".
        /// </summary>
        public long ObjectDummyMainId { get; set; }

        /// <summary>
        /// Идентификатор объекта, где хранятся данные сущности "DummyManyToMany".
        /// </summary>
        public long ObjectDummyManyToManyId { get; set; }

        #endregion Properties
    }
}
