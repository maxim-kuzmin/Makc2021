//Author Maxim Kuzmin//makc//

namespace Makc2021.Layer3.Sample
{
    /// <inheritdoc/>
    public abstract class EntityLoader<TEntityObject> : Layer2.EntityLoader<TEntityObject>
    {
        #region Constructors

        /// <inheritdoc/>
        public EntityLoader(TEntityObject entityObject)
            : base(entityObject)
        {
            EntityObject = entityObject;
        }

        #endregion Constructors
    }
}
