// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2021.Layer3.Sql.Sample.Entity
{
    /// <inheritdoc/>
    public abstract class EntityLoader<TEntityObject> : Layer1.Entity.EntityLoader<TEntityObject>
    {
        #region Constructors

        /// <inheritdoc/>
        public EntityLoader(TEntityObject entityObject)
            : base(entityObject)
        {
        }

        #endregion Constructors
    }
}
