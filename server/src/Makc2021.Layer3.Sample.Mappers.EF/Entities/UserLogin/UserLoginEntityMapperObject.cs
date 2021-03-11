//Author Maxim Kuzmin//makc//

using Makc2021.Layer3.Sample.Entities.UserLogin;
using Makc2021.Layer3.Sample.Mappers.EF.Entities.User;

namespace Makc2021.Layer3.Sample.Mappers.EF.Entities.UserLogin
{
    /// <summary>
    /// Объект ORM сущности "UserLogin".
    /// </summary>
    public class UserLoginEntityMapperObject : UserLoginEntityObject
    {
        #region Properties

        /// <summary>
        /// Объект сущности "User".
        /// </summary>
        public UserEntityMapperObject ObjectOfUserEntity { get; set; }

        #endregion Properties
    }
}
