// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2021.Layer3.Sample.Entities.UserToken;

namespace Makc2021.Layer3.Sample.Mappers.EF.Entities.UserToken
{
    /// <summary>
    /// Расширение сущности "UserToken" сопоставителя.
    /// </summary>
    public static class MapperUserTokenEntityExtension
    {
        #region Public methods

        /// <summary>
        /// Создать объект сущности сопоставителя.
        /// </summary>
        /// <param name="source">Источник данных.</param>
        /// <returns>Объект сущности сопоставителя.</returns>
        public static MapperUserTokenEntityObject CreateMapperEntityObject(
            this UserTokenEntityObject source
            )
        {
            MapperUserTokenEntityObject result = new();

            new UserTokenEntityLoader(result).LoadDataFrom(source);

            return result;
        }

        /// <summary>
        /// Создать объект сущности.
        /// </summary>
        /// <returns>Объект сущности.</returns>
        public static UserTokenEntityObject CreateEntityObject(
            this MapperUserTokenEntityObject source
            )
        {
            UserTokenEntityLoader loader = new();

            loader.LoadDataFrom(source);

            return loader.EntityObject;
        }

        #endregion Public methods
    }
}
