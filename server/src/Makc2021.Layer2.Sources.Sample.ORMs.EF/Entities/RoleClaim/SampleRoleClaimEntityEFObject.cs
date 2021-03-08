//Author Maxim Kuzmin//makc//

using Makc2021.Layer2.Sources.Sample.Entities.RoleClaim;
using Makc2021.Layer2.Sources.Sample.ORMs.EF.Entities.Role;

namespace Makc2021.Layer2.Sources.Sample.ORMs.EF.Entities.RoleClaim
{
    /// <summary>
    /// Источник "Sample". Сущность "RoleClaim". ORM "Entity Framework". Объект.
    /// </summary>
    public class SampleRoleClaimEntityEFObject : SampleRoleClaimEntityObject
    {
        #region Properties

        /// <summary>
        /// Объект, где хранятся данные сущности "Role".
        /// </summary>
        public SampleRoleEntityEFObject ObjectRole { get; set; }

        #endregion Properties
    }
}
