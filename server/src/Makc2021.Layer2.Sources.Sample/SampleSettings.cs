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

namespace Makc2021.Layer2.Sources.Sample
{
    /// <summary>
    /// Источник "Sample". Настройки.
    /// </summary>
    public abstract class SampleSettings
    {
        #region Properties

        /// <summary>
        /// Сущность "DummyMain".
        /// </summary>
        public SampleDummyMainEntitySetting DummyMain { get; protected set; }

        /// <summary>
        /// Сущность "DummyMainDummyManyToMany".
        /// </summary>
        public SampleDummyMainDummyManyToManyEntitySetting DummyMainDummyManyToMany { get; protected set; }

        /// <summary>
        /// Сущность "DummyManyToMany".
        /// </summary>
        public SampleDummyManyToManyEntitySetting DummyManyToMany { get; protected set; }

        /// <summary>
        /// Сущность "DummyOneToMany".
        /// </summary>
        public SampleDummyOneToManyEntitySetting DummyOneToMany { get; protected set; }

        /// <summary>
        /// Сущность "DummyTree".
        /// </summary>
        public SampleDummyTreeEntitySetting DummyTree { get; protected set; }

        /// <summary>
        /// Сущность "DummyTreeLink".
        /// </summary>
        public SampleDummyTreeLinkEntitySetting DummyTreeLink { get; protected set; }

        /// <summary>
        /// Сущность "Role".
        /// </summary>
        public SampleRoleEntitySetting Role { get; protected set; }

        /// <summary>
        /// Сущность "RoleClaim".
        /// </summary>
        public SampleRoleClaimEntitySetting RoleClaim { get; protected set; }

        /// <summary>
        /// Сущность "User".
        /// </summary>
        public SampleUserEntitySetting User { get; protected set; }

        /// <summary>
        /// Сущность "UserClaim".
        /// </summary>
        public SampleUserClaimEntitySetting UserClaim { get; protected set; }

        /// <summary>
        /// Сущность "UserLogin".
        /// </summary>
        public SampleUserLoginEntitySetting UserLogin { get; protected set; }

        /// <summary>
        /// Сущность "UserRole".
        /// </summary>
        public SampleUserRoleEntitySetting UserRole { get; protected set; }

        /// <summary>
        /// Сущность "UserToken".
        /// </summary>
        public SampleUserTokenEntitySetting UserToken { get; protected set; }

        #endregion Properties
    }
}
