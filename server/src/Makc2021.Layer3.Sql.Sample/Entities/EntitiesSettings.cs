// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2021.Layer3.Sql.Sample.Entities.DummyMain;
using Makc2021.Layer3.Sql.Sample.Entities.DummyMainDummyManyToMany;
using Makc2021.Layer3.Sql.Sample.Entities.DummyManyToMany;
using Makc2021.Layer3.Sql.Sample.Entities.DummyOneToMany;
using Makc2021.Layer3.Sql.Sample.Entities.DummyTree;
using Makc2021.Layer3.Sql.Sample.Entities.DummyTreeLink;
using Makc2021.Layer3.Sql.Sample.Entities.Role;
using Makc2021.Layer3.Sql.Sample.Entities.RoleClaim;
using Makc2021.Layer3.Sql.Sample.Entities.User;
using Makc2021.Layer3.Sql.Sample.Entities.UserClaim;
using Makc2021.Layer3.Sql.Sample.Entities.UserLogin;
using Makc2021.Layer3.Sql.Sample.Entities.UserRole;
using Makc2021.Layer3.Sql.Sample.Entities.UserToken;

namespace Makc2021.Layer3.Sql.Sample.Entities
{
    /// <summary>
    /// Настройки сущностей.
    /// </summary>
    public abstract class EntitiesSettings
    {
        #region Properties

        /// <summary>
        /// Сущность "DummyMain".
        /// </summary>
        public DummyMainEntitySettings DummyMain { get; protected set; }

        /// <summary>
        /// Сущность "DummyMainDummyManyToMany".
        /// </summary>
        public DummyMainDummyManyToManyEntitySettings DummyMainDummyManyToMany { get; protected set; }

        /// <summary>
        /// Сущность "DummyManyToMany".
        /// </summary>
        public DummyManyToManyEntitySettings DummyManyToMany { get; protected set; }

        /// <summary>
        /// Сущность "DummyOneToMany".
        /// </summary>
        public DummyOneToManyEntitySettings DummyOneToMany { get; protected set; }

        /// <summary>
        /// Сущность "DummyTree".
        /// </summary>
        public DummyTreeEntitySettings DummyTree { get; protected set; }

        /// <summary>
        /// Сущность "DummyTreeLink".
        /// </summary>
        public DummyTreeLinkEntitySettings DummyTreeLink { get; protected set; }

        /// <summary>
        /// Сущность "Role".
        /// </summary>
        public RoleEntitySettings Role { get; protected set; }

        /// <summary>
        /// Сущность "RoleClaim".
        /// </summary>
        public RoleClaimEntitySettings RoleClaim { get; protected set; }

        /// <summary>
        /// Сущность "User".
        /// </summary>
        public UserEntitySettings User { get; protected set; }

        /// <summary>
        /// Сущность "UserClaim".
        /// </summary>
        public UserClaimEntitySettings UserClaim { get; protected set; }

        /// <summary>
        /// Сущность "UserLogin".
        /// </summary>
        public UserLoginEntitySettings UserLogin { get; protected set; }

        /// <summary>
        /// Сущность "UserRole".
        /// </summary>
        public UserRoleEntitySettings UserRole { get; protected set; }

        /// <summary>
        /// Сущность "UserToken".
        /// </summary>
        public UserTokenEntitySettings UserToken { get; protected set; }

        #endregion Properties
    }
}
