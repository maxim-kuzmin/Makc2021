//Author Maxim Kuzmin//makc//

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Makc2021.Layer2.Mappers.EF
{
    /// <summary>
    /// Схема ORM.
    /// </summary>
    /// <typeparam name="TEntityObject">Тип объекта сущности.</typeparam>
    /// <typeparam name="TEntitiesSettings">Тип настроек сущностей.</typeparam>
    public abstract class MapperSchema<TEntityObject, TEntitiesSettings> : IEntityTypeConfiguration<TEntityObject>
        where TEntityObject : class
    {
        #region Properties

        /// <summary>
        /// Настройки сущностей.
        /// </summary>
        protected TEntitiesSettings EntitiesSettings { get; private set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="entitiesSettings">Настройки сущностей.</param>
        public MapperSchema(TEntitiesSettings entitiesSettings)
        {
            EntitiesSettings = entitiesSettings;
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public abstract void Configure(EntityTypeBuilder<TEntityObject> builder);

        #endregion Public methods
    }
}
