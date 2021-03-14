// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2021.Layer3.Sample.Entities.DummyManyToMany;

namespace Makc2021.Layer3.Sample.Mappers.EF.Entities.DummyManyToMany
{
    /// <summary>
    /// Расширение сущности "DummyManyToMany" для сопоставителя.
    /// </summary>
    public static class DummyManyToManyEntityMapperExtension
    {
        #region Public methods

        /// <summary>
        /// Создать объект Entity Framework, где хранятся данные сущности "DummyMain".
        /// </summary>
        /// <param name="source">Источник данных.</param>
        /// <returns>Объект Entity Framework, где хранятся данные сущности "DummyMain".</returns>
        public static DummyManyToManyEntityMapperObject CreateEntityEFObject(
            this DummyManyToManyEntityObject source
            )
        {
            DummyManyToManyEntityMapperObject result = new();

            new DummyManyToManyEntityLoader(result).LoadDataFrom(source);

            return result;
        }

        /// <summary>
        /// Создать объект, где хранятся данные сущности "DummyMain".
        /// </summary>
        /// <returns>Объект сущности "DummyMain".</returns>
        public static DummyManyToManyEntityObject CreateEntityObject(
            this DummyManyToManyEntityMapperObject source
            )
        {
            DummyManyToManyEntityLoader loader = new();

            loader.LoadDataFrom(source);

            return loader.EntityObject;
        }

        #endregion Public methods
    }
}
