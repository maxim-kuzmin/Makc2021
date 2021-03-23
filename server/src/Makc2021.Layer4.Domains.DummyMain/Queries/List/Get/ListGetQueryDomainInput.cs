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
    public class ListGetQueryDomainInput : ListGetQueryInput
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
        /// Имя объекта сущности "DummyOneToMany".
        /// </summary>
        public string ObjectNameOfDummyOneToManyEntity { get; set; }

        /// <summary>
        /// Идентификатор объекта сущности "DummyOneToMany".
        /// </summary>
        public long ObjectIdOfDummyOneToManyEntity { get; set; }

        /// <summary>
        /// Строка идентификаторов сущности "DummyOneToMany".
        /// </summary>
        public string ObjectIdsStringOfDummyOneToManyEntity { get; set; }

        /// <summary>
        /// Идентификаторы объектов сущности "DummyOneToMany".
        /// </summary>
        public long[] ObjectIdsOfDummyOneToManyEntity { get; set; }

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

            bool isOk = !string.IsNullOrWhiteSpace(ObjectIdsStringOfDummyOneToManyEntity)
                &&
                (
                    ObjectIdsOfDummyOneToManyEntity == null
                    ||
                    !ObjectIdsOfDummyOneToManyEntity.Any()
                );

            if (isOk)
            {
                ObjectIdsOfDummyOneToManyEntity = ObjectIdsStringOfDummyOneToManyEntity.FromStringToNumericInt64Array();
            }

            if (!string.IsNullOrWhiteSpace(EntityIdsString) && (EntityIds == null || !EntityIds.Any()))
            {
                EntityIds = EntityIdsString.FromStringToNumericInt64Array();
            }
        }

        #endregion Public methods
    }
}
