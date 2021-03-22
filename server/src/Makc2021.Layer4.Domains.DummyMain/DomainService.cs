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
using SampleMapper = Makc2021.Layer3.Sample.Mappers.EF;

namespace Makc2021.Layer4.Domains.DummyMain
{
    /// <summary>
    /// Сервис домена.
    /// </summary>
    public class DomainService : IDomainService
    {
        #region Properties

        private SampleMapper::IMapperService AppSampleMapperService { get; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="appSampleMapperService">Сервис сопоставителя базы данных "Sample".</param>
        public DomainService(SampleMapper::IMapperService appSampleMapperService)
        {
            AppSampleMapperService = appSampleMapperService;
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public async Task<ItemGetQueryDomainOutput> GetItem(ItemGetQueryDomainInput input)
        {
            ItemGetQueryDomainOutput result = null;

            using var dbContext = AppSampleMapperService.CreateDbContext();

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
                        .Select(x => x.ObjectDummyManyToManyId)
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
        public async Task<ListGetQueryDomainOutput> GetList(ListGetQueryDomainInput input)
        {
            var result = new ListGetQueryDomainOutput();

            using var dbContext = AppSampleMapperService.CreateDbContext();
            using var dbContextForTotalCount = AppSampleMapperService.CreateDbContext();

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
                    .Select(x => x.ObjectDummyManyToManyId)
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

        private ItemGetQueryDomainOutput CreateItem(DummyMainEntityMapperObject entity)
        {
            var result = new ItemGetQueryDomainOutput
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

        private void InitItemDummyManyToMany(
            ItemGetQueryDomainOutput item,
            IEnumerable<DummyManyToManyEntityMapperObject> enities
            )
        {
            item.ObjectsOfDummyManyToManyEntity = enities
                .OrderBy(x => x.Name)
                .ThenBy(x => x.Id)
                .Select(x => x.CreateEntityObject())
                .ToArray();
        }

        private void InitItemDummyManyToMany(
            ItemGetQueryDomainOutput item,
            IDictionary<long, DummyManyToManyEntityMapperObject> lookup
            )
        {
            long[] ids = item.ObjectsOfDummyMainDummyManyToManyEntity
                .Select(x => x.ObjectDummyManyToManyId)
                .ToArray();

            var entities = new List<DummyManyToManyEntityMapperObject>();

            foreach (long id in ids)
            {
                if (lookup.TryGetValue(id, out DummyManyToManyEntityMapperObject entity))
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
