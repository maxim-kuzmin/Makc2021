// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2021.Layer3.Sample.Entities.RoleClaim;

namespace Makc2021.Layer3.Sample.Mappers.EF.Entities.RoleClaim
{
    /// <summary>
    /// Расширение сущности "RoleClaim" для сопоставителя.
    /// </summary>
    public static class RoleClaimEntityMapperExtension
    {
        #region Public methods

        /// <summary>
        /// Создать объект Entity Framework, где хранятся данные сущности "DummyMain".
        /// </summary>
        /// <param name="source">Источник данных.</param>
        /// <returns>Объект Entity Framework, где хранятся данные сущности "DummyMain".</returns>
        public static RoleClaimEntityMapperObject CreateEntityEFObject(
            this RoleClaimEntityObject source
            )
        {
            RoleClaimEntityMapperObject result = new();

            new RoleClaimEntityLoader(result).LoadDataFrom(source);

            return result;
        }

        /// <summary>
        /// Создать объект, где хранятся данные сущности "DummyMain".
        /// </summary>
        /// <returns>Объект сущности "DummyMain".</returns>
        public static RoleClaimEntityObject CreateEntityObject(
            this RoleClaimEntityMapperObject source
            )
        {
            RoleClaimEntityLoader loader = new();

            loader.LoadDataFrom(source);

            return loader.EntityObject;
        }

        #endregion Public methods
    }
}
