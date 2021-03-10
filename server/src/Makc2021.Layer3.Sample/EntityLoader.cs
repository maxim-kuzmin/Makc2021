//Author Maxim Kuzmin//makc//

namespace Makc2021.Layer3.Sample
{
    /// <inheritdoc/>
    public abstract class EntityLoader<TData> : Layer2.EntityLoader<TData>
    {
        #region Constructors

        /// <inheritdoc/>
        public EntityLoader(TData data)
            : base(data)
        {
            Entity = data;
        }

        #endregion Constructors
    }
}
