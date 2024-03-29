﻿// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2021.Layer3.Sql.Sample.Entities.DummyTreeLink;
using Makc2021.Layer3.Sql.Sample.Mappers.EF.Entities.DummyTree;

namespace Makc2021.Layer3.Sql.Sample.Mappers.EF.Entities.DummyTreeLink
{
    /// <summary>
    /// Объект сущности "DummyTreeLink" сопоставителя.
    /// </summary>
    public class MapperDummyTreeLinkEntityObject : DummyTreeLinkEntityObject
    {
        #region Properties

        /// <summary>
        /// Объект сущности "DummyTree".
        /// </summary>
        public MapperDummyTreeEntityObject ObjectOfDummyTreeEntity { get; set; }

        #endregion Properties
    }
}
