// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2021.Layer3.Sql.Sample.Entities.DummyTreeLink;

namespace Makc2021.Layer3.Sql.Sample.Mappers.EF.Entities.DummyTreeLink
{
    /// <summary>
    /// Расширение сущности "DummyTreeLink" сопоставителя.
    /// </summary>
    public static class MapperDummyTreeLinkEntityExtension
    {
        #region Public methods

        /// <summary>
        /// Создать объект сущности сопоставителя.
        /// </summary>
        /// <param name="source">Источник данных.</param>
        /// <returns>Объект сущности сопоставителя.</returns>
        public static MapperDummyTreeLinkEntityObject CreateMapperEntityObject(
            this DummyTreeLinkEntityObject source
            )
        {
            MapperDummyTreeLinkEntityObject result = new();

            new DummyTreeLinkEntityLoader(result).Load(source);

            return result;
        }

        /// <summary>
        /// Создать объект сущности.
        /// </summary>
        /// <returns>Объект сущности.</returns>
        public static DummyTreeLinkEntityObject CreateEntityObject(
            this MapperDummyTreeLinkEntityObject source
            )
        {
            DummyTreeLinkEntityLoader loader = new();

            loader.Load(source);

            return loader.EntityObject;
        }

        #endregion Public methods
    }
}
