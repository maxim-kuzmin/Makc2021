// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2021.Layer3.Sample.Entities.DummyMainDummyManyToMany;

namespace Makc2021.Layer3.Sample.Mappers.EF.Entities.DummyMainDummyManyToMany
{
    /// <summary>
    /// Расширение ORM сущности "DummyMainDummyManyToMany".
    /// </summary>
    public static class DummyMainDummyManyToManyEntityMapperExtension
    {
        #region Public methods

        /// <summary>
        /// Создать объект Entity Framework, где хранятся данные сущности "DummyMain".
        /// </summary>
        /// <param name="source">Источник данных.</param>
        /// <returns>Объект Entity Framework, где хранятся данные сущности "DummyMain".</returns>
        public static DummyMainDummyManyToManyEntityMapperObject CreateEntityEFObject(
            this DummyMainDummyManyToManyEntityObject source
            )
        {
            DummyMainDummyManyToManyEntityMapperObject result = new();

            new DummyMainDummyManyToManyEntityLoader(result).LoadDataFrom(source);

            return result;
        }

        /// <summary>
        /// Создать объект, где хранятся данные сущности "DummyMain".
        /// </summary>
        /// <returns>Объект сущности "DummyMain".</returns>
        public static DummyMainDummyManyToManyEntityObject CreateEntityObject(
            this DummyMainDummyManyToManyEntityMapperObject source
            )
        {
            DummyMainDummyManyToManyEntityLoader loader = new();

            loader.LoadDataFrom(source);

            return loader.EntityObject;
        }

        #endregion Public methods
    }
}
