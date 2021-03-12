// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2021.Layer3.Sample.Entities.DummyTree;

namespace Makc2021.Layer3.Sample.Mappers.EF.Entities.DummyTree
{
    /// <summary>
    /// Расширение ORM сущности "DummyTree".
    /// </summary>
    public static class DummyTreeEntityMapperExtension
    {
        #region Public methods

        /// <summary>
        /// Создать объект Entity Framework, где хранятся данные сущности "DummyMain".
        /// </summary>
        /// <param name="source">Источник данных.</param>
        /// <returns>Объект Entity Framework, где хранятся данные сущности "DummyMain".</returns>
        public static DummyTreeEntityMapperObject CreateEntityEFObject(
            this DummyTreeEntityObject source
            )
        {
            DummyTreeEntityMapperObject result = new();

            new DummyTreeEntityLoader(result).LoadDataFrom(source);

            return result;
        }

        /// <summary>
        /// Создать объект, где хранятся данные сущности "DummyMain".
        /// </summary>
        /// <returns>Объект сущности "DummyMain".</returns>
        public static DummyTreeEntityObject CreateEntityObject(
            this DummyTreeEntityMapperObject source
            )
        {
            DummyTreeEntityLoader loader = new();

            loader.LoadDataFrom(source);

            return loader.EntityObject;
        }

        #endregion Public methods
    }
}
