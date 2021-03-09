//Author Maxim Kuzmin//makc//

namespace Makc2021.Layer3.Sample
{
    /// <inheritdoc/>
    public abstract class Loader<TData> : Layer2.Loader<TData>
    {
        #region Constructors

        /// <inheritdoc/>
        public Loader(TData data)
            : base(data)
        {
            Data = data;
        }

        #endregion Constructors
    }
}
