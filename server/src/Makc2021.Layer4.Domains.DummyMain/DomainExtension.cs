// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System;
using System.Linq;
using Makc2021.Layer1.Query;
using Makc2021.Layer3.Sample.Mappers.EF.Entities.DummyMain;
using Makc2021.Layer4.Domains.DummyMain.Queries.Item.Get;
using Makc2021.Layer4.Domains.DummyMain.Queries.List.Get;

namespace Makc2021.Layer4.Domains.DummyMain
{
    /// <summary>
    /// Расширение домена.
    /// </summary>
    public static class DomainExtension
    {
        #region Public methods

        /// <summary>
        /// Применить. Фильтрацию.
        /// </summary>
        /// <param name="query">Запрос.</param>
        /// <param name="input">Входные данные.</param>
        /// <returns>Запрос с учётом фильтрации.</returns>
        public static IQueryable<DummyMainEntityMapperObject> ApplyFiltering(
            this IQueryable<DummyMainEntityMapperObject> query,
            ItemGetQueryDomainInput input
            )
        {
            if (input.EntityId > 0)
            {
                query = query.Where(x => x.Id == input.EntityId);
            }

            if (input.EntityName != null)
            {
                query = query.Where(x => x.Name == input.EntityName);
            }

            return query;
        }

        /// <summary>
        /// Применить. Фильтрацию.
        /// </summary>
        /// <param name="query">Запрос.</param>
        /// <param name="input">Входные данные.</param>
        /// <returns>Запрос с учётом фильтрации.</returns>
        public static IQueryable<DummyMainEntityMapperObject> ApplyFiltering(
            this IQueryable<DummyMainEntityMapperObject> query,
            ListGetQueryDomainInput input
            )
        {
            if (!string.IsNullOrWhiteSpace(input.EntityName))
            {
                query = query.Where(x => x.Name.Contains(input.EntityName));
            }

            if (input.EntityIds != null && input.EntityIds.Any())
            {
                if (input.EntityIds.Count() > 1)
                {
                    query = query.Where(x => input.EntityIds.Contains(x.Id));
                }
                else
                {
                    long entityId = input.EntityIds[0];

                    query = query.Where(x => x.Id == entityId);
                }
            }

            if (input.ObjectIdOfDummyOneToManyEntity > 0)
            {
                query = query.Where(x => x.ObjectDummyOneToManyId == input.ObjectIdOfDummyOneToManyEntity);
            }

            if (input.ObjectIdsOfDummyOneToManyEntity != null && input.ObjectIdsOfDummyOneToManyEntity.Any())
            {
                if (input.ObjectIdsOfDummyOneToManyEntity.Count() > 1)
                {
                    query = query.Where(x => input.ObjectIdsOfDummyOneToManyEntity.Contains(x.ObjectDummyOneToManyId));
                }
                else
                {
                    long objectIdOfDummyOneToManyEntity = input.ObjectIdsOfDummyOneToManyEntity[0];

                    query = query.Where(x => x.ObjectDummyOneToManyId == objectIdOfDummyOneToManyEntity);
                }
            }

            if (!string.IsNullOrWhiteSpace(input.ObjectNameOfDummyOneToManyEntity))
            {
                query = query.Where(x => x.ObjectOfDummyOneToManyEntity.Name.Contains(input.ObjectNameOfDummyOneToManyEntity));
            }

            return query;
        }

        /// <summary>
        /// Применить. Сортировку.
        /// </summary>
        /// <param name="query">Запрос.</param>
        /// <param name="input">Входные данные.</param>
        /// <returns>Запрос с учётом сортировки.</returns>
        public static IQueryable<DummyMainEntityMapperObject> ApplySorting(
            this IQueryable<DummyMainEntityMapperObject> query,
            ListGetQueryDomainInput input
            )
        {
            string sortField = input.SortField.ToLower();
            string sortDirection = input.SortDirection.ToLower();

            DummyMainEntityMapperObject obj;

            string sortFieldForId = nameof(obj.Id).ToLower();
            string sortFieldForName = nameof(obj.Name).ToLower();
            string sortFieldForObjectDummyOneToMany = nameof(obj.ObjectOfDummyOneToManyEntity).ToLower();
            string sortFieldForPropDate = nameof(obj.PropDate).ToLower();
            string sortFieldForPropBoolean = nameof(obj.PropBoolean).ToLower();

            if (sortField == sortFieldForId)
            {
                switch (sortDirection)
                {
                    case QuerySettings.SORT_DIRECTION_ASC:
                        query = query.OrderBy(x => x.Id);
                        break;
                    case QuerySettings.SORT_DIRECTION_DESC:
                        query = query.OrderByDescending(x => x.Id);
                        break;
                }
            }
            else if (sortField == sortFieldForName)
            {
                switch (sortDirection)
                {
                    case QuerySettings.SORT_DIRECTION_ASC:
                        query = query.OrderBy(x => x.Name);
                        break;
                    case QuerySettings.SORT_DIRECTION_DESC:
                        query = query.OrderByDescending(x => x.Name);
                        break;
                }
            }
            else if (sortField == sortFieldForObjectDummyOneToMany)
            {
                switch (sortDirection)
                {
                    case QuerySettings.SORT_DIRECTION_ASC:
                        query = query.OrderBy(x => x.ObjectOfDummyOneToManyEntity.Name);
                        break;
                    case QuerySettings.SORT_DIRECTION_DESC:
                        query = query.OrderByDescending(x => x.ObjectOfDummyOneToManyEntity.Name);
                        break;
                }
            }
            else if (sortField == sortFieldForPropDate)
            {
                switch (sortDirection)
                {
                    case QuerySettings.SORT_DIRECTION_ASC:
                        query = query.OrderBy(x => x.PropDate);
                        break;
                    case QuerySettings.SORT_DIRECTION_DESC:
                        query = query.OrderByDescending(x => x.PropDate);
                        break;
                }
            }
            else if (sortField == sortFieldForPropBoolean)
            {
                switch (sortDirection)
                {
                    case QuerySettings.SORT_DIRECTION_ASC:
                        query = query.OrderBy(x => x.PropBoolean);
                        break;
                    case QuerySettings.SORT_DIRECTION_DESC:
                        query = query.OrderByDescending(x => x.PropBoolean);
                        break;
                }
            }

            if (!string.IsNullOrWhiteSpace(sortField) && sortField != sortFieldForId)
            {
                query = ((IOrderedQueryable<DummyMainEntityMapperObject>)query).ThenBy(x => x.Id);
            }

            return query;
        }

        #endregion Public methods
    }
}
