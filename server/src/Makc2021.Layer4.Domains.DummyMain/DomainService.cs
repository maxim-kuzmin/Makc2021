// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Makc2021.Layer1.Extensions;
using Makc2021.Layer3.Sample.Mappers.EF.Entities.DummyMain;
using Makc2021.Layer3.Sample.Mappers.EF.Entities.DummyMainDummyManyToMany;
using Makc2021.Layer3.Sample.Mappers.EF.Entities.DummyManyToMany;
using Makc2021.Layer3.Sample.Mappers.EF.Entities.DummyOneToMany;
using Makc2021.Layer4.Domains.DummyMain.Queries.Item.Get;
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
                .ConfigureAwaitWithCurrentCulture(false);

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
                            .ConfigureAwaitWithCurrentCulture(false);

                        if (enitiesOfDummyManyToMany.Any())
                        {
                            InitItemDummyManyToMany(result, enitiesOfDummyManyToMany);
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
