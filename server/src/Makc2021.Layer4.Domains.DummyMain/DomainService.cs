// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Makc2021.Layer1.Completion;
using Makc2021.Layer2.Queries.List.Get;
using Makc2021.Layer3.Sample.Mappers.EF.Entities.DummyMain;
using Makc2021.Layer3.Sample.Mappers.EF.Entities.DummyMainDummyManyToMany;
using Makc2021.Layer3.Sample.Mappers.EF.Entities.DummyManyToMany;
using Makc2021.Layer3.Sample.Mappers.EF.Entities.DummyOneToMany;
using Makc2021.Layer4.Domains.DummyMain.Queries.Item.Get;
using Makc2021.Layer4.Domains.DummyMain.Queries.List.Get;
using Microsoft.EntityFrameworkCore;

namespace Makc2021.Layer4.Domains.DummyMain
{
    /// <summary>
    /// Сервис домена.
    /// </summary>
    public class DomainService : IDomainService
    {
        #region Properties

        private Layer3.Sample.Mappers.EF.Db.IMapperDbFactory MapperDbFactoryForSample { get; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="mapperDbFactoryForSample">Фабрика базы данных сопоставителя для "Sample".</param>
        public DomainService(Layer3.Sample.Mappers.EF.Db.IMapperDbFactory mapperDbFactoryForSample)
        {
            MapperDbFactoryForSample = mapperDbFactoryForSample;
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public async Task<DomainItemGetQueryOutput> GetItem(DomainItemGetQueryInput input)
        {
            DomainItemGetQueryOutput result = null;

            using var dbContext = MapperDbFactoryForSample.CreateDbContext();

            var entityOfDummyMain = await dbContext.DummyMain
                .Include(x => x.ObjectOfDummyOneToManyEntity)
                .Include(x => x.ObjectsOfDummyMainDummyManyToManyEntity)
                .ApplyFiltering(input)
                .FirstOrDefaultAsync()
                .ConfigureAwaitWithCultureSaving(false);

            if (entityOfDummyMain != null)
            {
                result = CreateItem(entityOfDummyMain);

                if (result.ObjectsOfDummyMainDummyManyToManyEntity != null)
                {
                    long[] idsOfDummyManyToMany = result.ObjectsOfDummyMainDummyManyToManyEntity
                        .Select(x => x.IdOfDummyManyToManyEntity)
                        .ToArray();

                    if (idsOfDummyManyToMany.Any())
                    {
                        var enitiesOfDummyManyToMany = await dbContext.DummyManyToMany
                            .Where(x => idsOfDummyManyToMany.Contains(x.Id))
                            .ToArrayAsync()
                            .ConfigureAwaitWithCultureSaving(false);

                        if (enitiesOfDummyManyToMany.Any())
                        {
                            InitItemDummyManyToMany(result, enitiesOfDummyManyToMany);
                        }
                    }
                }
            }

            return result;
        }

        /// <inheritdoc/>
        public async Task<DomainListGetQueryOutput> GetList(DomainListGetQueryInput input)
        {
            var result = new DomainListGetQueryOutput();

            using var dbContext = MapperDbFactoryForSample.CreateDbContext();
            using var dbContextForTotalCount = MapperDbFactoryForSample.CreateDbContext();

            var queryOfItems = dbContext.DummyMain
                .Include(x => x.ObjectOfDummyOneToManyEntity)
                .Include(x => x.ObjectsOfDummyMainDummyManyToManyEntity)
                .ApplyFiltering(input)
                .ApplySorting(input)
                .ApplyPagination(input);

            var queryOfTotalCount = dbContextForTotalCount.DummyMain
                .ApplyFiltering(input);

            var taskOfItems = queryOfItems.ToArrayAsync();
            var taskOfTotalCount = queryOfTotalCount.CountAsync();

            await Task.WhenAll(taskOfItems, taskOfTotalCount).ConfigureAwaitWithCultureSaving(false);

            result.Items = taskOfItems.Result.Select(x => CreateItem(x)).ToArray();
            result.TotalCount = taskOfTotalCount.Result;

            if (result.Items.Any())
            {
                long[] idsDummyManyToMany = result.Items
                    .Where(x => x.ObjectsOfDummyMainDummyManyToManyEntity != null)
                    .SelectMany(x => x.ObjectsOfDummyMainDummyManyToManyEntity)
                    .Select(x => x.IdOfDummyManyToManyEntity)
                    .Distinct()
                    .ToArray();

                if (idsDummyManyToMany.Any())
                {
                    var lookupOfDummyManyToMany = await dbContext.DummyManyToMany
                        .Where(x => idsDummyManyToMany.Contains(x.Id))
                        .ToDictionaryAsync(x => x.Id)
                        .ConfigureAwaitWithCultureSaving(false);

                    if (lookupOfDummyManyToMany.Any())
                    {
                        foreach (var item in result.Items)
                        {
                            if (item.ObjectsOfDummyMainDummyManyToManyEntity != null)
                            {
                                InitItemDummyManyToMany(item, lookupOfDummyManyToMany);
                            }
                        }
                    }
                }
            }

            return result;
        }

        #endregion Public methods

        #region Private methods

        private static DomainItemGetQueryOutput CreateItem(MapperDummyMainEntityObject entity)
        {
            var result = new DomainItemGetQueryOutput
            {
                ObjectOfDummyMainEntity = entity.CreateEntityObject(),
                ObjectOfDummyOneToManyEntity = entity.ObjectOfDummyOneToManyEntity.CreateEntityObject()
            };

            if (entity.ObjectsOfDummyMainDummyManyToManyEntity.Any())
            {
                result.ObjectsOfDummyMainDummyManyToManyEntity = entity.ObjectsOfDummyMainDummyManyToManyEntity
                    .Select(x => x.CreateEntityObject())
                    .ToArray();
            }

            return result;
        }

        private static void InitItemDummyManyToMany(
            DomainItemGetQueryOutput item,
            IEnumerable<MapperDummyManyToManyEntityObject> enities
            )
        {
            item.ObjectsOfDummyManyToManyEntity = enities
                .OrderBy(x => x.Name)
                .ThenBy(x => x.Id)
                .Select(x => x.CreateEntityObject())
                .ToArray();
        }

        private static void InitItemDummyManyToMany(
            DomainItemGetQueryOutput item,
            IDictionary<long, MapperDummyManyToManyEntityObject> lookup
            )
        {
            long[] ids = item.ObjectsOfDummyMainDummyManyToManyEntity
                .Select(x => x.IdOfDummyManyToManyEntity)
                .ToArray();

            var entities = new List<MapperDummyManyToManyEntityObject>();

            foreach (long id in ids)
            {
                if (lookup.TryGetValue(id, out MapperDummyManyToManyEntityObject entity))
                {
                    entities.Add(entity);
                }
            }

            if (entities.Any())
            {
                InitItemDummyManyToMany(item, entities);
            }
        }

        #endregion Private methods
    }
}
