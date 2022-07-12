// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2021.Layer3.Sql.Sample.Entities.UserRole;

namespace Makc2021.Layer3.Sql.Sample.Mappers.EF.Entities.UserRole
{
    /// <summary>
    /// Расширение сущности "UserRole" сопоставителя.
    /// </summary>
    public static class MapperUserRoleEntityExtension
    {
        #region Public methods

        /// <summary>
        /// Создать объект сущности сопоставителя.
        /// </summary>
        /// <param name="source">Источник данных.</param>
        /// <returns>Объект сущности сопоставителя.</returns>
        public static MapperUserRoleEntityObject CreateMapperEntityObject(
            this UserRoleEntityObject source
            )
        {
            MapperUserRoleEntityObject result = new();

            new UserRoleEntityLoader(result).Load(source);

            return result;
        }

        /// <summary>
        /// Создать объект сущности.
        /// </summary>
        /// <returns>Объект сущности.</returns>
        public static UserRoleEntityObject CreateEntityObject(
            this MapperUserRoleEntityObject source
            )
        {
            UserRoleEntityLoader loader = new();

            loader.Load(source);

            return loader.EntityObject;
        }

        #endregion Public methods
    }
}
