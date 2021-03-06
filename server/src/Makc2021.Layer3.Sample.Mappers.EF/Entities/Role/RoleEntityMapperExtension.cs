// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2021.Layer3.Sample.Entities.Role;

namespace Makc2021.Layer3.Sample.Mappers.EF.Entities.Role
{
    /// <summary>
    /// Расширение сущности "Role" для сопоставителя.
    /// </summary>
    public static class RoleEntityMapperExtension
    {
        #region Public methods

        /// <summary>
        /// Создать объект Entity Framework, где хранятся данные сущности "DummyMain".
        /// </summary>
        /// <param name="source">Источник данных.</param>
        /// <returns>Объект Entity Framework, где хранятся данные сущности "DummyMain".</returns>
        public static RoleEntityMapperObject CreateEntityEFObject(
            this RoleEntityObject source
            )
        {
            RoleEntityMapperObject result = new();

            new RoleEntityLoader(result).LoadDataFrom(source);

            return result;
        }

        /// <summary>
        /// Создать объект, где хранятся данные сущности "DummyMain".
        /// </summary>
        /// <returns>Объект сущности "DummyMain".</returns>
        public static RoleEntityObject CreateEntityObject(
            this RoleEntityMapperObject source
            )
        {
            RoleEntityLoader loader = new();

            loader.LoadDataFrom(source);

            return loader.EntityObject;
        }

        #endregion Public methods
    }
}
