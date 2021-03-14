// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2021.Layer3.Sample.Entities.User;

namespace Makc2021.Layer3.Sample.Mappers.EF.Entities.User
{
    /// <summary>
    /// Расширение сущности "User" для сопоставителя.
    /// </summary>
    public static class UserEntityMapperExtension
    {
        #region Public methods

        /// <summary>
        /// Создать объект Entity Framework, где хранятся данные сущности "DummyMain".
        /// </summary>
        /// <param name="source">Источник данных.</param>
        /// <returns>Объект Entity Framework, где хранятся данные сущности "DummyMain".</returns>
        public static UserEntityMapperObject CreateEntityEFObject(
            this UserEntityObject source
            )
        {
            UserEntityMapperObject result = new();

            new UserEntityLoader(result).LoadDataFrom(source);

            return result;
        }

        /// <summary>
        /// Создать объект, где хранятся данные сущности "DummyMain".
        /// </summary>
        /// <returns>Объект сущности "DummyMain".</returns>
        public static UserEntityObject CreateEntityObject(
            this UserEntityMapperObject source
            )
        {
            UserEntityLoader loader = new();

            loader.LoadDataFrom(source);

            return loader.EntityObject;
        }

        #endregion Public methods
    }
}
