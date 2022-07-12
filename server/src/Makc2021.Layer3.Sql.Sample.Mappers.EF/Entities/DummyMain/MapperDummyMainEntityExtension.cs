// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2021.Layer3.Sql.Sample.Entities.DummyMain;

namespace Makc2021.Layer3.Sql.Sample.Mappers.EF.Entities.DummyMain
{
    /// <summary>
    /// Расширение сущности "DummyMain" сопоставителя.
    /// </summary>
    public static class MapperDummyMainEntityExtension
    {
        #region Public methods

        /// <summary>
        /// Создать объект сущности сопоставителя.
        /// </summary>
        /// <param name="source">Источник данных.</param>
        /// <returns>Объект сущности сопоставителя.</returns>
        public static MapperDummyMainEntityObject CreateMapperEntityObject(
            this DummyMainEntityObject source
            )
        {
            MapperDummyMainEntityObject result = new();

            new DummyMainEntityLoader(result).Load(source);

            return result;
        }

        /// <summary>
        /// Создать объект сущности "DummyMain".
        /// </summary>
        /// <returns>Объект сущности.</returns>
        public static DummyMainEntityObject CreateEntityObject(
            this MapperDummyMainEntityObject source
            )
        {
            DummyMainEntityLoader loader = new();

            loader.Load(source);

            return loader.EntityObject;
        }

        #endregion Public methods
    }
}
