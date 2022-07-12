// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2021.Layer3.Sql.Sample.Entities.Role;

namespace Makc2021.Layer3.Sql.Sample.Mappers.EF.Entities.Role
{
    /// <summary>
    /// Расширение сущности "Role" сопоставителя.
    /// </summary>
    public static class MapperRoleEntityExtension
    {
        #region Public methods

        /// <summary>
        /// Создать объект сущности сопоставителя.
        /// </summary>
        /// <param name="source">Источник данных.</param>
        /// <returns>Объект сущности сопоставителя.</returns>
        public static MapperRoleEntityObject CreateMapperEntityObject(
            this RoleEntityObject source
            )
        {
            MapperRoleEntityObject result = new();

            new RoleEntityLoader(result).LoadDataFrom(source);

            return result;
        }

        /// <summary>
        /// Создать объект сущности.
        /// </summary>
        /// <returns>Объект сущности.</returns>
        public static RoleEntityObject CreateEntityObject(
            this MapperRoleEntityObject source
            )
        {
            RoleEntityLoader loader = new();

            loader.LoadDataFrom(source);

            return loader.EntityObject;
        }

        #endregion Public methods
    }
}
