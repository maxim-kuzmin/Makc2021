﻿// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System;
using System.Linq;
using Makc2021.Layer1.Query;
using Makc2021.Layer3.Sql.Sample.Mappers.EF.Entities.DummyMain;
using Makc2021.Layer4.Sql.Domains.DummyMain.Queries.Item.Get;
using Makc2021.Layer4.Sql.Domains.DummyMain.Queries.List.Get;

namespace Makc2021.Layer4.Sql.Domains.DummyMain
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
        public static IQueryable<MapperDummyMainEntityObject> ApplyFiltering(
            this IQueryable<MapperDummyMainEntityObject> query,
            DomainItemGetQueryInput input
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
        public static IQueryable<MapperDummyMainEntityObject> ApplyFiltering(
            this IQueryable<MapperDummyMainEntityObject> query,
            DomainListGetQueryInput input
            )
        {
            if (!string.IsNullOrWhiteSpace(input.EntityName))
            {
                query = query.Where(x => x.Name.Contains(input.EntityName));
            }

            if (input.EntityIds != null && input.EntityIds.Any())
            {
                if (input.EntityIds.Length > 1)
                {
                    query = query.Where(x => input.EntityIds.Contains(x.Id));
                }
                else
                {
                    long entityId = input.EntityIds[0];

                    query = query.Where(x => x.Id == entityId);
                }
            }

            if (input.IdOfDummyOneToManyEntity > 0)
            {
                query = query.Where(x => x.IdOfDummyOneToManyEntity == input.IdOfDummyOneToManyEntity);
            }

            if (input.IdsOfDummyOneToManyEntity != null && input.IdsOfDummyOneToManyEntity.Any())
            {
                if (input.IdsOfDummyOneToManyEntity.Count() > 1)
                {
                    query = query.Where(x => input.IdsOfDummyOneToManyEntity.Contains(x.IdOfDummyOneToManyEntity));
                }
                else
                {
                    long objectIdOfDummyOneToManyEntity = input.IdsOfDummyOneToManyEntity[0];

                    query = query.Where(x => x.IdOfDummyOneToManyEntity == objectIdOfDummyOneToManyEntity);
                }
            }

            if (!string.IsNullOrWhiteSpace(input.NameOfDummyOneToManyEntity))
            {
                query = query.Where(x => x.ObjectOfDummyOneToManyEntity.Name.Contains(input.NameOfDummyOneToManyEntity));
            }

            return query;
        }

        /// <summary>
        /// Применить. Сортировку.
        /// </summary>
        /// <param name="query">Запрос.</param>
        /// <param name="input">Входные данные.</param>
        /// <returns>Запрос с учётом сортировки.</returns>
        public static IQueryable<MapperDummyMainEntityObject> ApplySorting(
            this IQueryable<MapperDummyMainEntityObject> query,
            DomainListGetQueryInput input
            )
        {
            string sortField = input.SortField.ToLower();
            string sortDirection = input.SortDirection.ToLower();

            MapperDummyMainEntityObject obj;

            string sortFieldForId = nameof(obj.Id).ToLower();
            string sortFieldForName = nameof(obj.Name).ToLower();
            string sortFieldForObjectDummyOneToMany = nameof(obj.ObjectOfDummyOneToManyEntity).ToLower();
            string sortFieldForPropDate = nameof(obj.PropDate).ToLower();
            string sortFieldForPropBoolean = nameof(obj.PropBoolean).ToLower();

            if (sortField == sortFieldForId)
            {
                switch (sortDirection)
                {
                    case QueryOptions.SORT_DIRECTION_ASC:
                        query = query.OrderBy(x => x.Id);
                        break;
                    case QueryOptions.SORT_DIRECTION_DESC:
                        query = query.OrderByDescending(x => x.Id);
                        break;
                }
            }
            else if (sortField == sortFieldForName)
            {
                switch (sortDirection)
                {
                    case QueryOptions.SORT_DIRECTION_ASC:
                        query = query.OrderBy(x => x.Name);
                        break;
                    case QueryOptions.SORT_DIRECTION_DESC:
                        query = query.OrderByDescending(x => x.Name);
                        break;
                }
            }
            else if (sortField == sortFieldForObjectDummyOneToMany)
            {
                switch (sortDirection)
                {
                    case QueryOptions.SORT_DIRECTION_ASC:
                        query = query.OrderBy(x => x.ObjectOfDummyOneToManyEntity.Name);
                        break;
                    case QueryOptions.SORT_DIRECTION_DESC:
                        query = query.OrderByDescending(x => x.ObjectOfDummyOneToManyEntity.Name);
                        break;
                }
            }
            else if (sortField == sortFieldForPropDate)
            {
                switch (sortDirection)
                {
                    case QueryOptions.SORT_DIRECTION_ASC:
                        query = query.OrderBy(x => x.PropDate);
                        break;
                    case QueryOptions.SORT_DIRECTION_DESC:
                        query = query.OrderByDescending(x => x.PropDate);
                        break;
                }
            }
            else if (sortField == sortFieldForPropBoolean)
            {
                switch (sortDirection)
                {
                    case QueryOptions.SORT_DIRECTION_ASC:
                        query = query.OrderBy(x => x.PropBoolean);
                        break;
                    case QueryOptions.SORT_DIRECTION_DESC:
                        query = query.OrderByDescending(x => x.PropBoolean);
                        break;
                }
            }

            if (!string.IsNullOrWhiteSpace(sortField) && sortField != sortFieldForId)
            {
                query = ((IOrderedQueryable<MapperDummyMainEntityObject>)query).ThenBy(x => x.Id);
            }

            return query;
        }

        #endregion Public methods
    }
}
