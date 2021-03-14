// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2021.Layer3.Sample.Entities.DummyMain;

namespace Makc2021.Layer3.Sample.Mappers.EF.Entities.DummyMain
{
    /// <summary>
    /// Расширение сущности "DummyMain" для сопоставителя.
    /// </summary>
    public static class DummyMainEntityMapperExtension
    {
        #region Public methods

        /// <summary>
        /// Создать объект Entity Framework, где хранятся данные сущности "DummyMain".
        /// </summary>
        /// <param name="source">Источник данных.</param>
        /// <returns>Объект Entity Framework, где хранятся данные сущности "DummyMain".</returns>
        public static DummyMainEntityMapperObject CreateEntityEFObject(
            this DummyMainEntityObject source
            )
        {
            DummyMainEntityMapperObject result = new();

            new DummyMainEntityLoader(result).LoadDataFrom(source);

            return result;
        }

        /// <summary>
        /// Создать объект, где хранятся данные сущности "DummyMain".
        /// </summary>
        /// <returns>Объект сущности "DummyMain".</returns>
        public static DummyMainEntityObject CreateEntityObject(
            this DummyMainEntityMapperObject source
            )
        {
            DummyMainEntityLoader loader = new();

            loader.LoadDataFrom(source);

            return loader.EntityObject;
        }

        #endregion Public methods
    }
}
