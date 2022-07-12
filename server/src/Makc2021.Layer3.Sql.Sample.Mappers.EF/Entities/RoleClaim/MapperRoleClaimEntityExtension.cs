// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2021.Layer3.Sql.Sample.Entities.RoleClaim;

namespace Makc2021.Layer3.Sql.Sample.Mappers.EF.Entities.RoleClaim
{
    /// <summary>
    /// Расширение сущности "RoleClaim" сопоставителя.
    /// </summary>
    public static class MapperRoleClaimEntityExtension
    {
        #region Public methods

        /// <summary>
        /// Создать объект сущности сопоставителя.
        /// </summary>
        /// <param name="source">Источник данных.</param>
        /// <returns>Объект сущности сопоставителя.</returns>
        public static MapperRoleClaimEntityObject CreateMapperEntityObject(
            this RoleClaimEntityObject source
            )
        {
            MapperRoleClaimEntityObject result = new();

            new RoleClaimEntityLoader(result).LoadDataFrom(source);

            return result;
        }

        /// <summary>
        /// Создать объект сущности.
        /// </summary>
        /// <returns>Объект сущности.</returns>
        public static RoleClaimEntityObject CreateEntityObject(
            this MapperRoleClaimEntityObject source
            )
        {
            RoleClaimEntityLoader loader = new();

            loader.LoadDataFrom(source);

            return loader.EntityObject;
        }

        #endregion Public methods
    }
}
