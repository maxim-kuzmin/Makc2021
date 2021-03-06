// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2021.Layer3.Sample.Entities.UserClaim;

namespace Makc2021.Layer3.Sample.Mappers.EF.Entities.UserClaim
{
    /// <summary>
    /// Расширение сущности "UserClaim" для сопоставителя.
    /// </summary>
    public static class UserClaimEntityMapperExtension
    {
        #region Public methods

        /// <summary>
        /// Создать объект Entity Framework, где хранятся данные сущности "DummyMain".
        /// </summary>
        /// <param name="source">Источник данных.</param>
        /// <returns>Объект Entity Framework, где хранятся данные сущности "DummyMain".</returns>
        public static UserClaimEntityMapperObject CreateEntityEFObject(
            this UserClaimEntityObject source
            )
        {
            UserClaimEntityMapperObject result = new();

            new UserClaimEntityLoader(result).LoadDataFrom(source);

            return result;
        }

        /// <summary>
        /// Создать объект, где хранятся данные сущности "DummyMain".
        /// </summary>
        /// <returns>Объект сущности "DummyMain".</returns>
        public static UserClaimEntityObject CreateEntityObject(
            this UserClaimEntityMapperObject source
            )
        {
            UserClaimEntityLoader loader = new();

            loader.LoadDataFrom(source);

            return loader.EntityObject;
        }

        #endregion Public methods
    }
}
