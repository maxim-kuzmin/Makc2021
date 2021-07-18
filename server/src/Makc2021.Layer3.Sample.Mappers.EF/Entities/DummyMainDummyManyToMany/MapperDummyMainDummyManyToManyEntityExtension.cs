// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2021.Layer3.Sample.Entities.DummyMainDummyManyToMany;

namespace Makc2021.Layer3.Sample.Mappers.EF.Entities.DummyMainDummyManyToMany
{
    /// <summary>
    /// Расширение сущности "DummyMainDummyManyToMany" сопоставителя.
    /// </summary>
    public static class MapperDummyMainDummyManyToManyEntityExtension
    {
        #region Public methods

        /// <summary>
        /// Создать объект сущности сопоставителя.
        /// </summary>
        /// <param name="source">Источник данных.</param>
        /// <returns>Объект сущности сопоставителя.</returns>
        public static MapperDummyMainDummyManyToManyEntityObject CreateMapperEntityObject(
            this DummyMainDummyManyToManyEntityObject source
            )
        {
            MapperDummyMainDummyManyToManyEntityObject result = new();

            new DummyMainDummyManyToManyEntityLoader(result).LoadDataFrom(source);

            return result;
        }

        /// <summary>
        /// Создать объект сущности.
        /// </summary>
        /// <returns>Объект сущности.</returns>
        public static DummyMainDummyManyToManyEntityObject CreateEntityObject(
            this MapperDummyMainDummyManyToManyEntityObject source
            )
        {
            DummyMainDummyManyToManyEntityLoader loader = new();

            loader.LoadDataFrom(source);

            return loader.EntityObject;
        }

        #endregion Public methods
    }
}
