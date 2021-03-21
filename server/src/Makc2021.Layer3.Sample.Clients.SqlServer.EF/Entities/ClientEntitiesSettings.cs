// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System;
using Makc2021.Layer3.Sample.Db;
using Makc2021.Layer3.Sample.Entities;
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

namespace Makc2021.Layer3.Sample.Clients.SqlServer.EF.Entities
{
    /// <summary>
    /// Настройки сущностей клиента.
    /// </summary>
    internal class ClientEntitiesSettings : EntitiesSettings
    {
        #region Fields

        private static readonly Lazy<EntitiesSettings> _lazy = new(() => new ClientEntitiesSettings());

        #endregion Fields

        #region Properties

        /// <summary>
        /// Экземпляр.
        /// </summary>
        public static EntitiesSettings Instance => _lazy.Value;

        #endregion Properties

        #region Constructors

        private ClientEntitiesSettings()
        {
            DbDefaults dbDefaults = new()
            {
                DbColumnForId = "Id",
                DbColumnForName = "Name",
                DbColumnForParentId = "ParentId",
                DbColumnForTreeChildCount = "TreeChildCount",
                DbColumnForTreeDescendantCount = "TreeDescendantCount",
                DbColumnForTreeLevel = "TreeLevel",
                DbColumnForTreePath = "TreePath",
                DbColumnForTreePosition = "TreePosition",
                DbColumnForTreeSort = "TreeSort",
                DbColumnPartsSeparator = "",
                DbForeignKeyPrefix = "FK",
                DbIndexPrefix = "IX",
                DbPrimaryKeyPrefix = "PK",
                DbSchema = "dbo",
                DbUniqueIndexPrefix = "UX",
                FullNamePartsSeparator = ".",
                NamePartsSeparator = "_"
            };

            DummyOneToMany = new DummyOneToManyEntitySetting(dbDefaults, "DummyOneToMany");

            DummyMain = new DummyMainEntitySetting(DummyOneToMany, dbDefaults, "DummyMain");

            DummyManyToMany = new DummyManyToManyEntitySetting(dbDefaults, "DummyManyToMany");

            DummyMainDummyManyToMany = new DummyMainDummyManyToManyEntitySetting(
                DummyMain,
                DummyManyToMany,
                dbDefaults,
                "DummyMainDummyManyToMany"
                );

            DummyTree = new DummyTreeEntitySetting(dbDefaults, "DummyTree");

            DummyTreeLink = new DummyTreeLinkEntitySetting(DummyTree, dbDefaults, "DummyTreeLink");

            Role = new RoleEntitySetting(dbDefaults, "Role");

            RoleClaim = new RoleClaimEntitySetting(Role, dbDefaults, "RoleClaim");

            User = new UserEntitySetting(dbDefaults, "User");

            UserClaim = new UserClaimEntitySetting(User, dbDefaults, "UserClaim");

            UserLogin = new UserLoginEntitySetting(User, dbDefaults, "UserLogin");

            UserRole = new UserRoleEntitySetting(Role, User, dbDefaults, "UserRole");

            UserToken = new UserTokenEntitySetting(User, dbDefaults, "UserToken");
        }

        #endregion Constructors     
    }
}
