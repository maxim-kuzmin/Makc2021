//Author Maxim Kuzmin//makc//

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
using System;

namespace Makc2021.Layer3.Sample.Mappers.EF.Clients.SqlServer
{
    /// <summary>
    /// Настройки сущностей ORM клиента.
    /// </summary>
    public sealed class ClientMapperEntitiesSettings : EntitiesSettings
    {
        #region Fields

        private static readonly Lazy<ClientMapperEntitiesSettings> _lazy =
            new Lazy<ClientMapperEntitiesSettings>(() => new ClientMapperEntitiesSettings());

        #endregion Fields

        #region Properties

        /// <summary>
        /// Экземпляр.
        /// </summary>
        public static EntitiesSettings Instance
        {
            get
            {
                return _lazy.Value;
            }
        }

        #endregion Properties

        #region Constructors

        private ClientMapperEntitiesSettings()
        {
            var defaults = new Defaults
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
                ForeignKeyPrefix = "FK",
                FullNamePartsSeparator = ".",
                IndexPrefix = "IX",
                NamePartsSeparator = "_",
                PrimaryKeyPrefix = "PK",
                Schema = "dbo",
                UniqueIndexPrefix = "UX"
            };

            DummyOneToMany = new DummyOneToManyEntitySetting(defaults, "DummyOneToMany");

            DummyMain = new DummyMainEntitySetting(DummyOneToMany, defaults, "DummyMain");

            DummyManyToMany = new DummyManyToManyEntitySetting(defaults, "DummyManyToMany");

            DummyMainDummyManyToMany = new DummyMainDummyManyToManyEntitySetting(
                DummyMain,
                DummyManyToMany,
                defaults,
                "DummyMainDummyManyToMany"
                );

            DummyTree = new DummyTreeEntitySetting(defaults, "DummyTree");

            DummyTreeLink = new DummyTreeLinkEntitySetting(DummyTree, defaults, "DummyTreeLink");

            Role = new RoleEntitySetting(defaults, "Role");

            RoleClaim = new RoleClaimEntitySetting(Role, defaults, "RoleClaim");

            User = new UserEntitySetting(defaults, "User");

            UserClaim = new UserClaimEntitySetting(User, defaults, "UserClaim");

            UserLogin = new UserLoginEntitySetting(User, defaults, "UserLogin");

            UserRole = new UserRoleEntitySetting(Role, User, defaults, "UserRole");

            UserToken = new UserTokenEntitySetting(User, defaults, "UserToken");
        }

        #endregion Constructors     
    }
}
