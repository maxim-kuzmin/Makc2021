//Author Maxim Kuzmin//makc//

using Makc2021.Layer2.Sources.Sample.Entities.UserClaim;
using Makc2021.Layer2.Sources.Sample.ORMs.EF.Entities.User;

namespace Makc2021.Layer2.Sources.Sample.ORMs.EF.Entities.UserClaim
{
    /// <summary>
    /// Источник "Sample". Сущность "UserClaim". ORM "Entity Framework". Объект.
    /// </summary>
    public class SampleUserClaimEntityEFObject : SampleUserClaimEntityObject
    {
        #region Properties

        /// <summary>
        /// Объект, где хранятся данные сущности "User".
        /// </summary>
        public SampleUserEntityEFObject ObjectUser { get; set; }

        #endregion Properties
    }
}
