// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2021.Layer3.Sample.Entities.UserClaim;

namespace Makc2021.Layer3.Sample.Mappers.EF.Entities.UserClaim
{
    /// <summary>
    /// Расширение сущности "UserClaim" сопоставителя.
    /// </summary>
    public static class MapperUserClaimEntityExtension
    {
        #region Public methods

        /// <summary>
        /// Создать объект сущности сопоставителя.
        /// </summary>
        /// <param name="source">Источник данных.</param>
        /// <returns>Объект сущности сопоставителя.</returns>
        public static MapperUserClaimEntityObject CreateMapperEntityObject(
            this UserClaimEntityObject source
            )
        {
            MapperUserClaimEntityObject result = new();

            new UserClaimEntityLoader(result).LoadDataFrom(source);

            return result;
        }

        /// <summary>
        /// Создать объект сущности.
        /// </summary>
        /// <returns>Объект сущности.</returns>
        public static UserClaimEntityObject CreateEntityObject(
            this MapperUserClaimEntityObject source
            )
        {
            UserClaimEntityLoader loader = new();

            loader.LoadDataFrom(source);

            return loader.EntityObject;
        }

        #endregion Public methods
    }
}
