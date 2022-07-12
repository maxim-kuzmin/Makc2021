﻿// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2021.Layer3.Sql.Sample.Entities.DummyOneToMany;

namespace Makc2021.Layer3.Sql.Sample.Mappers.EF.Entities.DummyOneToMany
{
    /// <summary>
    /// Расширение сущности "DummyOneToMany" сопоставителя.
    /// </summary>
    public static class MapperDummyOneToManyEntityExtension
    {
        #region Public methods

        /// <summary>
        /// Создать объект сущности сопоставителя.
        /// </summary>
        /// <param name="source">Источник данных.</param>
        /// <returns>Объект сущности сопоставителя.</returns>
        public static MapperDummyOneToManyEntityObject CreateMapperEntityObject(
            this DummyOneToManyEntityObject source
            )
        {
            MapperDummyOneToManyEntityObject result = new();

            new DummyOneToManyEntityLoader(result).Load(source);

            return result;
        }

        /// <summary>
        /// Создать объект сущности.
        /// </summary>
        /// <returns>Объект сущности.</returns>
        public static DummyOneToManyEntityObject CreateEntityObject(
            this MapperDummyOneToManyEntityObject source
            )
        {
            DummyOneToManyEntityLoader loader = new();

            loader.Load(source);

            return loader.EntityObject;
        }

        #endregion Public methods
    }
}
