//Author Maxim Kuzmin//makc//

using Microsoft.AspNetCore.Identity;

namespace Makc2021.Layer2.Sources.Sample.Entities.User
{
    /// <summary>
    /// Источник "Sample". Сущность "User". Объект.
    /// </summary>
    public class SampleUserEntityObject : IdentityUser<long>
    {
        #region Properties

        /// <summary>
        /// Полное имя.
        /// </summary>
        public string FullName { get; set; }

        #endregion Properties
    }
}
