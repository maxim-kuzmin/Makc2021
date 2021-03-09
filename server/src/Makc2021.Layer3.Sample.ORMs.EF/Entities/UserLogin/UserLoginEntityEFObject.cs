//Author Maxim Kuzmin//makc//

using Makc2021.Layer3.Sample.Entities.UserLogin;
using Makc2021.Layer3.Sample.ORMs.EF.Entities.User;

namespace Makc2021.Layer3.Sample.ORMs.EF.Entities.UserLogin
{
    /// <summary>
    /// Сущность "UserLogin". ORM "Entity Framework". Объект.
    /// </summary>
    public class UserLoginEntityEFObject : UserLoginEntityObject
    {
        #region Properties

        /// <summary>
        /// Объект сущности "User".
        /// </summary>
        public UserEntityEFObject ObjectOfUserEntity { get; set; }

        #endregion Properties
    }
}
