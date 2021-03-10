//Author Maxim Kuzmin//makc//

namespace Makc2021.Layer3.Sample.ORMs.EF
{
    /// <summary>
    /// ORM "Entity Framework". Схема.
    /// </summary>
    public abstract class EFSchema<TEntity> : Layer2.ORMs.EF.EFSchema<TEntity, EntitiesSettings>
        where TEntity : class
    {
        #region Constructors

        /// <inheritdoc/>
        public EFSchema(EntitiesSettings settings)
            : base(settings)
        {
        }

        #endregion Constructors
    }
}
