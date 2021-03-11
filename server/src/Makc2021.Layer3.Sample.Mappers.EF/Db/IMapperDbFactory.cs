//Author Maxim Kuzmin//makc//

using Microsoft.EntityFrameworkCore;

namespace Makc2021.Layer3.Sample.Mappers.EF.Db
{
    /// <summary>
    /// Интерфейс фабрики базы данных ORM.
    /// </summary>
    public interface IMapperDbFactory
    {
        #region Properties

        /// <summary>
        /// Опции.
        /// </summary>
        DbContextOptions<MapperDbContext> Options { get; }

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
        MapperDbContext CreateDbContext();

        #endregion Methods
    }
}
