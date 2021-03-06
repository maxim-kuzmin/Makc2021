// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

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
