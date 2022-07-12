// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2021.Layer3.Sql.Sample.Entities.DummyManyToMany;

namespace Makc2021.Layer3.Sql.Sample.Mappers.EF.Entities.DummyManyToMany
{
    /// <summary>
    /// Расширение сущности "DummyManyToMany" сопоставителя.
    /// </summary>
    public static class MapperDummyManyToManyEntityExtension
    {
        #region Public methods

        /// <summary>
        /// Создать объект сущности сопоставителя.
        /// </summary>
        /// <param name="source">Источник данных.</param>
        /// <returns>Объект сущности сопоставителя.</returns>
        public static MapperDummyManyToManyEntityObject CreateMapperEntityObject(
            this DummyManyToManyEntityObject source
            )
        {
            MapperDummyManyToManyEntityObject result = new();

            new DummyManyToManyEntityLoader(result).Load(source);

            return result;
        }

        /// <summary>
        /// Создать объект сущности.
        /// </summary>
        /// <returns>Объект сущности.</returns>
        public static DummyManyToManyEntityObject CreateEntityObject(
            this MapperDummyManyToManyEntityObject source
            )
        {
            DummyManyToManyEntityLoader loader = new();

            loader.Load(source);

            return loader.EntityObject;
        }

        #endregion Public methods
    }
}
