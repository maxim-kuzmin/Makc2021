// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2021.Layer3.Sql.Sample.Entities.User;

namespace Makc2021.Layer3.Sql.Sample.Mappers.EF.Entities.User
{
    /// <summary>
    /// Расширение сущности "User" сопоставителя.
    /// </summary>
    public static class MapperUserEntityExtension
    {
        #region Public methods

        /// <summary>
        /// Создать объект сущности сопоставителя.
        /// </summary>
        /// <param name="source">Источник данных.</param>
        /// <returns>Объект сущности сопоставителя.</returns>
        public static MapperUserEntityObject CreateMapperEntityObject(
            this UserEntityObject source
            )
        {
            MapperUserEntityObject result = new();

            new UserEntityLoader(result).LoadDataFrom(source);

            return result;
        }

        /// <summary>
        /// Создать объект сущности.
        /// </summary>
        /// <returns>Объект сущности.</returns>
        public static UserEntityObject CreateEntityObject(
            this MapperUserEntityObject source
            )
        {
            UserEntityLoader loader = new();

            loader.LoadDataFrom(source);

            return loader.EntityObject;
        }

        #endregion Public methods
    }
}
