// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System.Linq;
using Makc2021.Layer1.Converting;
using Makc2021.Layer1.Query;
using Makc2021.Layer2.Queries.List.Get;
using Makc2021.Layer3.Sample.Mappers.EF.Entities.DummyMain;

namespace Makc2021.Layer4.Domains.DummyMain.Queries.List.Get
{
    /// <summary>
    /// Входные данные запроса на получение списка в домене.
    /// </summary>
    public class DomainListGetQueryInput : ListGetQueryInput
    {
        #region Properties

        /// <summary>
        /// Идентификаторы сущности.
        /// </summary>
        public long[] EntityIds { get; set; }

        /// <summary>
        /// Строка идентификаторов сущности.
        /// </summary>
        public string EntityIdsString { get; set; }

        /// <summary>
        /// Имя сущности.
        /// </summary>
        public string EntityName { get; set; }

        /// <summary>
        /// Имя сущности "DummyOneToMany".
        /// </summary>
        public string NameOfDummyOneToManyEntity { get; set; }

        /// <summary>
        /// Идентификатор сущности "DummyOneToMany".
        /// </summary>
        public long IdOfDummyOneToManyEntity { get; set; }

        /// <summary>
        /// Идентификаторы сущности "DummyOneToMany".
        /// </summary>
        public long[] IdsOfDummyOneToManyEntity { get; set; }

        /// <summary>
        /// Строка идентификаторов сущности "DummyOneToMany".
        /// </summary>
        public string IdsStringOfDummyOneToManyEntity { get; set; }

        #endregion Properties

        #region Public methods

        /// <inheritdoc/>
        public sealed override void Normalize()
        {
            base.Normalize();

            if (string.IsNullOrWhiteSpace(SortField))
            {
                DummyMainEntityMapperObject obj;

                SortField = nameof(obj.Id);
            }

            if (string.IsNullOrWhiteSpace(SortDirection))
            {
                SortDirection = QuerySettings.SORT_DIRECTION_DESC;
            }

            bool isOk = !string.IsNullOrWhiteSpace(IdsStringOfDummyOneToManyEntity)
                &&
                (
                    IdsOfDummyOneToManyEntity == null
                    ||
                    !IdsOfDummyOneToManyEntity.Any()
                );

            if (isOk)
            {
                IdsOfDummyOneToManyEntity = IdsStringOfDummyOneToManyEntity.FromStringToNumericInt64Array();
            }

            if (!string.IsNullOrWhiteSpace(EntityIdsString) && (EntityIds == null || !EntityIds.Any()))
            {
                EntityIds = EntityIdsString.FromStringToNumericInt64Array();
            }
        }

        #endregion Public methods
    }
}
