//Author Maxim Kuzmin//makc//

using Makc2021.Layer2.Sources.Sample.Entities.Role;
using Makc2021.Layer2.Sources.Sample.ORMs.EF.Entities.RoleClaim;
using Makc2021.Layer2.Sources.Sample.ORMs.EF.Entities.UserRole;
using System.Collections.Generic;

namespace Makc2021.Layer2.Sources.Sample.ORMs.EF.Entities.Role
{
    /// <summary>
    /// Источник "Sample". Сущность "Role". ORM "Entity Framework". Объект.
    /// </summary>
    public class SampleRoleEntityEFObject : SampleRoleEntityObject
    {
        #region Properties

        /// <summary>
        /// Объекты, где хранятся данные сущности "RoleClaim".
        /// </summary>
        public List<SampleRoleClaimEntityEFObject> ObjectsRoleClaim { get; } =
            new List<SampleRoleClaimEntityEFObject>();

        /// <summary>
        /// Объекты, где хранятся данные сущности "UserRole".
        /// </summary>
        public List<SampleUserRoleEntityEFObject> ObjectsUserRole { get; } =
            new List<SampleUserRoleEntityEFObject>();

        #endregion Properties
    }
}
