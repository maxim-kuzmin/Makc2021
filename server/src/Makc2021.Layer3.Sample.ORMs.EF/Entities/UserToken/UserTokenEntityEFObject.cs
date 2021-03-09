//Author Maxim Kuzmin//makc//

using Makc2021.Layer3.Sample.Entities.UserToken;
using Makc2021.Layer3.Sample.ORMs.EF.Entities.User;

namespace Makc2021.Layer3.Sample.ORMs.EF.Entities.UserToken
{
    /// <summary>
    /// Сущность "UserToken". ORM "Entity Framework". Объект.
    /// </summary>
    public class UserTokenEntityEFObject : UserTokenEntityObject
    {
        #region Properties

        /// <summary>
        /// Объект сущности "User".
        /// </summary>
        public UserEntityEFObject ObjectOfUserEntity { get; set; }

        #endregion Properties
    }
}
