//Author Maxim Kuzmin//makc//

namespace Makc2021.Layer3.Sample.ORMs.EF
{
    /// <summary>
    /// ORM "Entity Framework". Схема.
    /// </summary>
    public abstract class EFSchema<TEntity> : Layer2.ORMs.EF.EFSchema<TEntity, Settings>
        where TEntity : class
    {
        #region Constructors

        /// <inheritdoc/>
        public EFSchema(Settings settings)
            : base(settings)
        {
        }

        #endregion Constructors
    }
}
