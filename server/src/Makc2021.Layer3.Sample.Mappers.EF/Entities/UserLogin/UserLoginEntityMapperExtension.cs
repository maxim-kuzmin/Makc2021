// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2021.Layer3.Sample.Entities.UserLogin;

namespace Makc2021.Layer3.Sample.Mappers.EF.Entities.UserLogin
{
    /// <summary>
    /// Расширение ORM сущности "UserLogin".
    /// </summary>
    public static class UserLoginEntityMapperExtension
    {
        #region Public methods

        /// <summary>
        /// Создать объект Entity Framework, где хранятся данные сущности "DummyMain".
        /// </summary>
        /// <param name="source">Источник данных.</param>
        /// <returns>Объект Entity Framework, где хранятся данные сущности "DummyMain".</returns>
        public static UserLoginEntityMapperObject CreateEntityEFObject(
            this UserLoginEntityObject source
            )
        {
            UserLoginEntityMapperObject result = new();

            new UserLoginEntityLoader(result).LoadDataFrom(source);

            return result;
        }

        /// <summary>
        /// Создать объект, где хранятся данные сущности "DummyMain".
        /// </summary>
        /// <returns>Объект сущности "DummyMain".</returns>
        public static UserLoginEntityObject CreateEntityObject(
            this UserLoginEntityMapperObject source
            )
        {
            UserLoginEntityLoader loader = new();

            loader.LoadDataFrom(source);

            return loader.EntityObject;
        }

        #endregion Public methods
    }
}
