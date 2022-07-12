// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2021.Layer3.Sql.Sample.Entities.DummyTree;

namespace Makc2021.Layer3.Sql.Sample.Mappers.EF.Entities.DummyTree
{
    /// <summary>
    /// Расширение сущности "DummyTree" сопоставителя.
    /// </summary>
    public static class MapperDummyTreeEntityExtension
    {
        #region Public methods

        /// <summary>
        /// Создать объект сущности сопоставителя.
        /// </summary>
        /// <param name="source">Источник данных.</param>
        /// <returns>Объект сущности сопоставителя.</returns>
        public static MapperDummyTreeEntityObject CreateMapperEntityObject(
            this DummyTreeEntityObject source
            )
        {
            MapperDummyTreeEntityObject result = new();

            new DummyTreeEntityLoader(result).Load(source);

            return result;
        }

        /// <summary>
        /// Создать объект сущности.
        /// </summary>
        /// <returns>Объект сущности.</returns>
        public static DummyTreeEntityObject CreateEntityObject(
            this MapperDummyTreeEntityObject source
            )
        {
            DummyTreeEntityLoader loader = new();

            loader.Load(source);

            return loader.EntityObject;
        }

        #endregion Public methods
    }
}
