//Author Maxim Kuzmin//makc//

using Microsoft.EntityFrameworkCore;

namespace Makc2021.Layer3.Sample.ORMs.EF.Db
{
    /// <summary>
    /// ORM "Entity Framework". Фабрика базы данных. Интерфейс.
    /// </summary>
    public interface IEFDbFactory
    {
        #region Properties

        /// <summary>
        /// Опции.
        /// </summary>
        DbContextOptions<EFDbContext> Options { get; }

        /// <summary>
        /// Настройки.
        /// </summary>
        EntitiesSettings Settings { get; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Создать контекст базы данных.
        /// </summary>
        /// <returns>Контекст базы данных.</returns>
        EFDbContext CreateDbContext();

        #endregion Methods
    }
}
