//Author Maxim Kuzmin//makc//

using Makc2021.Layer2.Sources.Sample.Entities.DummyMain;
using Makc2021.Layer2.Sources.Sample.Entities.DummyMainDummyManyToMany;
using Makc2021.Layer2.Sources.Sample.Entities.DummyManyToMany;
using Makc2021.Layer2.Sources.Sample.Entities.DummyOneToMany;
using Makc2021.Layer2.Sources.Sample.Entities.DummyTree;
using Makc2021.Layer2.Sources.Sample.Entities.DummyTreeLink;
using Makc2021.Layer2.Sources.Sample.Entities.Role;
using Makc2021.Layer2.Sources.Sample.Entities.RoleClaim;
using Makc2021.Layer2.Sources.Sample.Entities.User;
using Makc2021.Layer2.Sources.Sample.Entities.UserClaim;
using Makc2021.Layer2.Sources.Sample.Entities.UserLogin;
using Makc2021.Layer2.Sources.Sample.Entities.UserRole;
using Makc2021.Layer2.Sources.Sample.Entities.UserToken;
using System;

namespace Makc2021.Layer2.Sources.Sample.ORMs.EF.DBs.SqlServer
{
    /// <summary>
    /// Источник "Sample". ORM "Entity Framework". База данных "Microsoft SQL Server". Настройки.
    /// </summary>
    public sealed class SampleEFSqlServerSettings : SampleSettings
    {
        #region Fields

        private static readonly Lazy<SampleEFSqlServerSettings> _lazy =
            new Lazy<SampleEFSqlServerSettings>(() => new SampleEFSqlServerSettings());

        #endregion Fields

        #region Properties

        /// <summary>
        /// Экземпляр.
        /// </summary>
        public static SampleSettings Instance
        {
            get
            {
                return _lazy.Value;
            }
        }

        #endregion Properties

        #region Constructors

        private SampleEFSqlServerSettings()
        {
            var defaults = new SampleDefaults
            {
                ColumnNameForId = "Id",
                ColumnNameForName = "Name",
                ColumnNameForParentId = "ParentId",
                ColumnNameForTreeChildCount = "TreeChildCount",
                ColumnNameForTreeDescendantCount = "TreeDescendantCount",
                ColumnNameForTreeLevel = "TreeLevel",
                ColumnNameForTreePath = "TreePath",
                ColumnNameForTreePosition = "TreePosition",
                ColumnNameForTreeSort = "TreeSort",
                ColumnNamePartsSeparator = "",
                ForeignKeyPrefix = "FK",
                FullNamePartsSeparator = ".",
                IndexPrefix = "IX",
                NamePartsSeparator = "_",
                PrimaryKeyPrefix = "PK",
                Schema = "dbo",
                UniqueIndexPrefix = "UX"
            };

            DummyOneToMany = new SampleDummyOneToManyEntitySetting(defaults, "DummyOneToMany");

            DummyMain = new SampleDummyMainEntitySetting(DummyOneToMany, defaults, "DummyMain");

            DummyManyToMany = new SampleDummyManyToManyEntitySetting(defaults, "DummyManyToMany");

            DummyMainDummyManyToMany = new SampleDummyMainDummyManyToManyEntitySetting(
                DummyMain,
                DummyManyToMany,
                defaults,
                "DummyMainDummyManyToMany"
                );

            DummyTree = new SampleDummyTreeEntitySetting(defaults, "DummyTree");

            DummyTreeLink = new SampleDummyTreeLinkEntitySetting(DummyTree, defaults, "DummyTreeLink");

            Role = new SampleRoleEntitySetting(defaults, "Role");

            RoleClaim = new SampleRoleClaimEntitySetting(Role, defaults, "RoleClaim");

            User = new SampleUserEntitySetting(defaults, "User");

            UserClaim = new SampleUserClaimEntitySetting(User, defaults, "UserClaim");

            UserLogin = new SampleUserLoginEntitySetting(User, defaults, "UserLogin");

            UserRole = new SampleUserRoleEntitySetting(Role, User, defaults, "UserRole");

            UserToken = new SampleUserTokenEntitySetting(User, defaults, "UserToken");
        }

        #endregion Constructors     
    }
}
