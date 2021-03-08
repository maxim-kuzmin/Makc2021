//Author Maxim Kuzmin//makc//

using Makc2021.Layer2.Sources.Sample.Entities.User;
using Makc2021.Layer2.Sources.Sample.ORMs.EF.Entities.UserClaim;
using Makc2021.Layer2.Sources.Sample.ORMs.EF.Entities.UserLogin;
using Makc2021.Layer2.Sources.Sample.ORMs.EF.Entities.UserRole;
using Makc2021.Layer2.Sources.Sample.ORMs.EF.Entities.UserToken;
using System.Collections.Generic;

namespace Makc2021.Layer2.Sources.Sample.ORMs.EF.Entities.User
{
    /// <summary>
    /// Источник "Sample". Сущность "User". ORM "Entity Framework". Объект.
    /// </summary>
    public class SampleUserEntityEFObject : SampleUserEntityObject
    {
        #region Properties

        /// <summary>
        /// Объекты, где хранятся данные сущности "UserClaim".
        /// </summary>
        public List<SampleUserClaimEntityEFObject> ObjectsUserClaim { get; } =
            new List<SampleUserClaimEntityEFObject>();

        /// <summary>
        /// Объекты, где хранятся данные сущности "UserLogin".
        /// </summary>
        public List<SampleUserLoginEntityEFObject> ObjectsUserLogin { get; } =
            new List<SampleUserLoginEntityEFObject>();

        /// <summary>
        /// Объекты, где хранятся данные сущности "UserRole".
        /// </summary>
        public List<SampleUserRoleEntityEFObject> ObjectsUserRole { get; } =
            new List<SampleUserRoleEntityEFObject>();

        /// <summary>
        /// Объекты, где хранятся данные сущности "UserToken".
        /// </summary>
        public List<SampleUserTokenEntityEFObject> ObjectsUserToken { get; } =
            new List<SampleUserTokenEntityEFObject>();

        #endregion Properties
    }
}
