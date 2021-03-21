// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2021.Layer3.Sample.Entities.DummyMain;
using Makc2021.Layer3.Sample.Entities.DummyMainDummyManyToMany;
using Makc2021.Layer3.Sample.Entities.DummyManyToMany;
using Makc2021.Layer3.Sample.Entities.DummyOneToMany;
using Makc2021.Layer3.Sample.Entities.DummyTree;
using Makc2021.Layer3.Sample.Entities.DummyTreeLink;
using Makc2021.Layer3.Sample.Entities.Role;
using Makc2021.Layer3.Sample.Entities.RoleClaim;
using Makc2021.Layer3.Sample.Entities.User;
using Makc2021.Layer3.Sample.Entities.UserClaim;
using Makc2021.Layer3.Sample.Entities.UserLogin;
using Makc2021.Layer3.Sample.Entities.UserRole;
using Makc2021.Layer3.Sample.Entities.UserToken;

namespace Makc2021.Layer3.Sample.Entities
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
        public DummyMainEntitySetting DummyMain { get; protected set; }

        /// <summary>
        /// Сущность "DummyMainDummyManyToMany".
        /// </summary>
        public DummyMainDummyManyToManyEntitySetting DummyMainDummyManyToMany { get; protected set; }

        /// <summary>
        /// Сущность "DummyManyToMany".
        /// </summary>
        public DummyManyToManyEntitySetting DummyManyToMany { get; protected set; }

        /// <summary>
        /// Сущность "DummyOneToMany".
        /// </summary>
        public DummyOneToManyEntitySetting DummyOneToMany { get; protected set; }

        /// <summary>
        /// Сущность "DummyTree".
        /// </summary>
        public DummyTreeEntitySetting DummyTree { get; protected set; }

        /// <summary>
        /// Сущность "DummyTreeLink".
        /// </summary>
        public DummyTreeLinkEntitySetting DummyTreeLink { get; protected set; }

        /// <summary>
        /// Сущность "Role".
        /// </summary>
        public RoleEntitySetting Role { get; protected set; }

        /// <summary>
        /// Сущность "RoleClaim".
        /// </summary>
        public RoleClaimEntitySetting RoleClaim { get; protected set; }

        /// <summary>
        /// Сущность "User".
        /// </summary>
        public UserEntitySetting User { get; protected set; }

        /// <summary>
        /// Сущность "UserClaim".
        /// </summary>
        public UserClaimEntitySetting UserClaim { get; protected set; }

        /// <summary>
        /// Сущность "UserLogin".
        /// </summary>
        public UserLoginEntitySetting UserLogin { get; protected set; }

        /// <summary>
        /// Сущность "UserRole".
        /// </summary>
        public UserRoleEntitySetting UserRole { get; protected set; }

        /// <summary>
        /// Сущность "UserToken".
        /// </summary>
        public UserTokenEntitySetting UserToken { get; protected set; }

        #endregion Properties
    }
}
