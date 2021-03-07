//Author Maxim Kuzmin//makc//

using Makc2021.Layer2.ORMs.EF;

namespace Makc2021.Layer2.Sources.Sample.ORMs.EF
{
    public abstract class SampleEFSchema<TEntity> : EFSchema<TEntity, SampleSettings>
        where TEntity : class
    {
        #region Constructors

        /// <inheritdoc/>
        public SampleEFSchema(SampleSettings settings)
            : base(settings)
        {
        }

        #endregion Constructors
    }
}
