//Author Maxim Kuzmin//makc//

using Microsoft.AspNetCore.Identity;

namespace Makc2021.Layer3.Sample.Entities.User
{
    /// <summary>
    /// Объект сущности "User".
    /// </summary>
    public class UserEntityObject : IdentityUser<long>
    {
        #region Properties

        /// <summary>
        /// Полное имя.
        /// </summary>
        public string FullName { get; set; }

        #endregion Properties
    }
}
