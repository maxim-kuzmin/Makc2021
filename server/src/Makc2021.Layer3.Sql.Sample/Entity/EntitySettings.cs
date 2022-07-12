// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2021.Layer3.Sql.Sample.Db;

namespace Makc2021.Layer3.Sql.Sample.Entity
{
    /// <inheritdoc/>
    public class EntitySettings : Layer2.Sql.Entity.EntitySettings<DbDefaults>
    {
        #region Constructors

        /// <inheritdoc/>
        public EntitySettings(DbDefaults defaults, string dbTable, string dbSchema = null)
            : base(defaults, dbTable, dbSchema)
        {
        }

        #endregion Constructors
    }
}
