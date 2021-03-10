//Author Maxim Kuzmin//makc//

using Makc2021.Layer3.Sample.ORMs.EF.Db;

namespace Makc2021.Layer3.Sample.ORMs.EF
{
    /// <summary>
    /// ORM "Entity Framework". Внешнее.
    /// </summary>
    public class EFExternals
    {
        #region Properties

        /// <summary>
        /// Фабрика базы данных.
        /// </summary>
        public IEFDbFactory DbFactory { get; set; }

        /// <summary>
        /// Настройки сущностей.
        /// </summary>
        public EntitiesSettings EntitiesSettings { get; set; }

        #endregion Properties
    }
}
