//Author Maxim Kuzmin//makc//

using Makc2021.Layer3.Sample.Entities.UserToken;
using Makc2021.Layer3.Sample.Mappers.EF.Entities.User;

namespace Makc2021.Layer3.Sample.Mappers.EF.Entities.UserToken
{
    /// <summary>
    /// Объект ORM сущности "UserToken".
    /// </summary>
    public class UserTokenEntityMapperObject : UserTokenEntityObject
    {
        #region Properties

        /// <summary>
        /// Объект сущности "User".
        /// </summary>
        public UserEntityMapperObject ObjectOfUserEntity { get; set; }

        #endregion Properties
    }
}
