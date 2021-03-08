//Author Maxim Kuzmin//makc//

using Makc2021.Layer2.Sources.Sample.Entities.UserRole;
using Makc2021.Layer2.Sources.Sample.ORMs.EF.Entities.Role;
using Makc2021.Layer2.Sources.Sample.ORMs.EF.Entities.User;

namespace Makc2021.Layer2.Sources.Sample.ORMs.EF.Entities.UserRole
{
    /// <summary>
    /// Источник "Sample". Сущность "UserRole". ORM "Entity Framework". Объект.
    /// </summary>
    public class SampleUserRoleEntityEFObject : SampleUserRoleEntityObject
    {
        #region Properties

        /// <summary>
        /// Объект, где хранятся данные сущности "Role".
        /// </summary>
        public SampleRoleEntityEFObject ObjectRole { get; set; }

        /// <summary>
        /// Объект, где хранятся данные сущности "User".
        /// </summary>
        public SampleUserEntityEFObject ObjectUser { get; set; }

        #endregion Properties
    }
}
