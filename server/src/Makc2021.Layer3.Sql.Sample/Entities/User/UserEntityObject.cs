// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Microsoft.AspNetCore.Identity;

namespace Makc2021.Layer3.Sql.Sample.Entities.User
{
    /// <summary>
    /// Объект сущности "User".
    /// </summary>
    public class UserEntityObject : IdentityUser<long>
    {
        #region Properties

        /// <summary>
        /// Полное имя.
        /// </summary>
        public string FullName { get; set; }

        #endregion Properties
    }
}
