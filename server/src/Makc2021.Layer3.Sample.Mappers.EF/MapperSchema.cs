//Author Maxim Kuzmin//makc//

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Makc2021.Layer3.Sample.Mappers.EF
{
    /// <summary>
    /// Схема ORM.
    /// </summary>
    /// <typeparam name="TEntityObject">Тип объекта сущности.</typeparam>
    public abstract class MapperSchema<TEntityObject> : IEntityTypeConfiguration<TEntityObject>
        where TEntityObject : class
    {
        #region Properties

        /// <summary>
        /// Настройки сущностей.
        /// </summary>
        protected EntitiesSettings EntitiesSettings { get; private set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="entitiesSettings">Настройки сущностей.</param>
        public MapperSchema(EntitiesSettings entitiesSettings)
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
