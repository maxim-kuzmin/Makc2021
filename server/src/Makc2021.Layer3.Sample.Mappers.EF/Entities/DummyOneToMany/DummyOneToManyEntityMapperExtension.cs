// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2021.Layer3.Sample.Entities.DummyOneToMany;

namespace Makc2021.Layer3.Sample.Mappers.EF.Entities.DummyOneToMany
{
    /// <summary>
    /// Расширение сущности "DummyOneToMany" для сопоставителя.
    /// </summary>
    public static class DummyOneToManyEntityMapperExtension
    {
        #region Public methods

        /// <summary>
        /// Создать объект Entity Framework, где хранятся данные сущности "DummyMain".
        /// </summary>
        /// <param name="source">Источник данных.</param>
        /// <returns>Объект Entity Framework, где хранятся данные сущности "DummyMain".</returns>
        public static DummyOneToManyEntityMapperObject CreateEntityEFObject(
            this DummyOneToManyEntityObject source
            )
        {
            DummyOneToManyEntityMapperObject result = new();

            new DummyOneToManyEntityLoader(result).LoadDataFrom(source);

            return result;
        }

        /// <summary>
        /// Создать объект, где хранятся данные сущности "DummyMain".
        /// </summary>
        /// <returns>Объект сущности "DummyMain".</returns>
        public static DummyOneToManyEntityObject CreateEntityObject(
            this DummyOneToManyEntityMapperObject source
            )
        {
            DummyOneToManyEntityLoader loader = new();

            loader.LoadDataFrom(source);

            return loader.EntityObject;
        }

        #endregion Public methods
    }
}
