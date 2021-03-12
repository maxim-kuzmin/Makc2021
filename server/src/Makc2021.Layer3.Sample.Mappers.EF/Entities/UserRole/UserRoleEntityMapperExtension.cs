// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2021.Layer3.Sample.Entities.UserRole;

namespace Makc2021.Layer3.Sample.Mappers.EF.Entities.UserRole
{
    /// <summary>
    /// Расширение ORM сущности "UserRole".
    /// </summary>
    public static class UserRoleEntityMapperExtension
    {
        #region Public methods

        /// <summary>
        /// Создать объект Entity Framework, где хранятся данные сущности "DummyMain".
        /// </summary>
        /// <param name="source">Источник данных.</param>
        /// <returns>Объект Entity Framework, где хранятся данные сущности "DummyMain".</returns>
        public static UserRoleEntityMapperObject CreateEntityEFObject(
            this UserRoleEntityObject source
            )
        {
            UserRoleEntityMapperObject result = new();

            new UserRoleEntityLoader(result).LoadDataFrom(source);

            return result;
        }

        /// <summary>
        /// Создать объект, где хранятся данные сущности "DummyMain".
        /// </summary>
        /// <returns>Объект сущности "DummyMain".</returns>
        public static UserRoleEntityObject CreateEntityObject(
            this UserRoleEntityMapperObject source
            )
        {
            UserRoleEntityLoader loader = new();

            loader.LoadDataFrom(source);

            return loader.EntityObject;
        }

        #endregion Public methods
    }
}
