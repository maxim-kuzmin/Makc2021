// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using Makc2021.Layer2.Queries.Item.Get;

namespace Makc2021.Layer4.Domains.DummyMain.Queries.Item.Get
{
    /// <summary>
    /// Ввод запроса на получение элемента в домене.
    /// </summary>
    public class ItemGetQueryDomainInput : ItemGetQueryInput
    {
        #region Properties

        /// <summary>
        /// Имя сущности.
        /// </summary>
        public string EntityName { get; set; }

        #endregion Properties

        #region Public methods

        /// <inheritdoc/>
        public sealed override void Normalize()
        {
            base.Normalize();

            if (EntityId > 0)
            {
                EntityName = null;
            }
        }

        /// <inheritdoc/>
        public sealed override List<string> GetInvalidProperties()
        {
            var result = base.GetInvalidProperties();

            if (result.Any())
            {
                if (EntityName != null)
                {
                    result.Clear();
                }
                else
                {
                    result.Add(nameof(EntityName));
                }
            }

            return result;
        }

        #endregion Public methods
    }
}
