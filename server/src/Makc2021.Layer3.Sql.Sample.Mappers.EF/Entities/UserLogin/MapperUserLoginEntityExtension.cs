// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2021.Layer3.Sql.Sample.Entities.UserLogin;

namespace Makc2021.Layer3.Sql.Sample.Mappers.EF.Entities.UserLogin
{
    /// <summary>
    /// Расширение сущности "UserLogin" сопоставителя.
    /// </summary>
    public static class MapperUserLoginEntityExtension
    {
        #region Public methods

        /// <summary>
        /// Создать объект сущности сопоставителя.
        /// </summary>
        /// <param name="source">Источник данных.</param>
        /// <returns>Объект сущности сопоставителя.</returns>
        public static MapperUserLoginEntityObject CreateMapperEntityObject(
            this UserLoginEntityObject source
            )
        {
            MapperUserLoginEntityObject result = new();

            new UserLoginEntityLoader(result).LoadDataFrom(source);

            return result;
        }

        /// <summary>
        /// Создать объект сущности.
        /// </summary>
        /// <returns>Объект сущности.</returns>
        public static UserLoginEntityObject CreateEntityObject(
            this MapperUserLoginEntityObject source
            )
        {
            UserLoginEntityLoader loader = new();

            loader.LoadDataFrom(source);

            return loader.EntityObject;
        }

        #endregion Public methods
    }
}
