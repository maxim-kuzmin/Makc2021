//Author Maxim Kuzmin//makc//

using Makc2021.Layer2.Sources.Sample.Entities.UserToken;
using Makc2021.Layer2.Sources.Sample.ORMs.EF.Entities.User;

namespace Makc2021.Layer2.Sources.Sample.ORMs.EF.Entities.UserToken
{
    /// <summary>
    /// Источник "Sample". Сущность "UserToken". ORM "Entity Framework". Объект.
    /// </summary>
    public class SampleUserTokenEntityEFObject : SampleUserTokenEntityObject
    {
        #region Properties

        /// <summary>
        /// Объект, где хранятся данные сущности "User".
        /// </summary>
        public SampleUserEntityEFObject ObjectUser { get; set; }

        #endregion Properties
    }
}
