//Author Maxim Kuzmin//makc//

using Makc2021.Layer2.Sources.Sample.Entities.UserLogin;
using Makc2021.Layer2.Sources.Sample.ORMs.EF.Entities.User;

namespace Makc2021.Layer2.Sources.Sample.ORMs.EF.Entities.UserLogin
{
    /// <summary>
    /// Источник "Sample". Сущность "UserLogin". ORM "Entity Framework". Объект.
    /// </summary>
    public class SampleUserLoginEntityEFObject : SampleUserLoginEntityObject
    {
        #region Properties

        /// <summary>
        /// Объект, где хранятся данные сущности "User".
        /// </summary>
        public SampleUserEntityEFObject ObjectUser { get; set; }

        #endregion Properties
    }
}
