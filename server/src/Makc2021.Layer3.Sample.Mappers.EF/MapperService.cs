// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Makc2021.Layer1.Completion;
using Makc2021.Layer2.Clients.SqlServer;
using Makc2021.Layer2.Commands.Tree.Trigger;
using Makc2021.Layer2.Commands.Trigger;
using Makc2021.Layer3.Sample.Entities;
using Makc2021.Layer3.Sample.Entities.DummyTree;
using Makc2021.Layer3.Sample.Entities.DummyTreeLink;
using Makc2021.Layer3.Sample.Mappers.EF.Db;
using Makc2021.Layer3.Sample.Mappers.EF.Entities.DummyMain;
using Makc2021.Layer3.Sample.Mappers.EF.Entities.DummyMainDummyManyToMany;
using Makc2021.Layer3.Sample.Mappers.EF.Entities.DummyManyToMany;
using Makc2021.Layer3.Sample.Mappers.EF.Entities.DummyOneToMany;
using Makc2021.Layer3.Sample.Mappers.EF.Entities.DummyTree;
using Microsoft.EntityFrameworkCore;

namespace Makc2021.Layer3.Sample.Mappers.EF
{
    /// <summary>
    /// Сервис сопоставителя.
    /// </summary>
    public class MapperService : IMapperService
    {
        #region Properties

        private IClientProvider ClientProvider { get; }

        private EntitiesSettings EntitiesSettings { get; }

        private IMapperDbFactory MapperDbFactory { get; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>        
        /// <param name="entitiesSettings">Настройки сущностей.</param>
        /// <param name="сlientProvider">Поставщик клиента.</param>
        /// <param name="mapperDbFactory">Фабрика базы данных сопоставителя.</param>
        public MapperService(            
            IClientProvider сlientProvider,
            EntitiesSettings entitiesSettings,
            IMapperDbFactory mapperDbFactory
            )
        {
            ClientProvider = сlientProvider;
            EntitiesSettings = entitiesSettings;
            MapperDbFactory = mapperDbFactory;
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public async Task MigrateDatabase()
        {
            using var dbContext = MapperDbFactory.CreateDbContext();

            await dbContext.Database.MigrateAsync().ConfigureAwaitWithCultureSaving(false);
        }

        /// <inheritdoc/>
        public async Task SeedTestData()
        {
            using var dbContext = MapperDbFactory.CreateDbContext();

            using var transaction = await dbContext.Database.BeginTransactionAsync()
                .ConfigureAwaitWithCultureSaving(false);

            bool isOk = await dbContext.DummyMain.AnyAsync().ConfigureAwaitWithCultureSaving(false);

            if (!isOk)
            {
                var itemsOfDummyOneToMany = await SeedTestDataForDummyOneToMany(dbContext)
                    .ConfigureAwaitWithCultureSaving(false);

                var itemsOfDummyMain = await SeedTestDataForDummyMain(dbContext, itemsOfDummyOneToMany)
                    .ConfigureAwaitWithCultureSaving(false);

                var itemsOfDummyManyToMany = await SeedTestDataForDummyManyToMany(dbContext)
                    .ConfigureAwaitWithCultureSaving(false);

                await SeedTestDataForDummyMainDummyManyToMany(dbContext, itemsOfDummyMain, itemsOfDummyManyToMany)
                    .ConfigureAwaitWithCultureSaving(false);

                await SeedTestDataForDummyTree(dbContext).ConfigureAwaitWithCultureSaving(false);
            }

            await transaction.CommitAsync().ConfigureAwaitWithCultureSaving(false);
        }

        #endregion Public methods

        #region Private methods

        private TreeTriggerCommandBuilder CreateQueryTreeTriggerBuilder(
            TriggerCommandAction action
            )
        {
            var result = ClientProvider.CreateQueryTreeTriggerBuilder();

            result.Action = action;

            InitQueryBuilder(result, EntitiesSettings.DummyTreeLink, EntitiesSettings.DummyTree);

            return result;
        }

        private static void InitQueryBuilder(
            TreeTriggerCommandBuilder builder,
            DummyTreeLinkEntitySettings linkSettings,
            DummyTreeEntitySettings treeSettings
            )
        {
            builder.LinkTableFieldNameForId = linkSettings.DbColumnForId;
            builder.LinkTableFieldNameForParentId = linkSettings.DbColumnForDummyTreeEntityParentId;

            builder.LinkTableNameWithoutSchema = linkSettings.DbTable;
            builder.LinkTableSchema = linkSettings.DbSchema;

            builder.TreeTableFieldNameForId = treeSettings.DbColumnForId;
            builder.TreeTableFieldNameForParentId = treeSettings.DbColumnForDummyTreeEntityParentId;
            builder.TreeTableFieldNameForTreeChildCount = treeSettings.DbColumnForTreeChildCount;
            builder.TreeTableFieldNameForTreeDescendantCount = treeSettings.DbColumnForTreeDescendantCount;
            builder.TreeTableFieldNameForTreeLevel = treeSettings.DbColumnForTreeLevel;
            builder.TreeTableFieldNameForTreePath = treeSettings.DbColumnForTreePath;
            builder.TreeTableFieldNameForTreePosition = treeSettings.DbColumnForTreePosition;
            builder.TreeTableFieldNameForTreeSort = treeSettings.DbColumnForTreeSort;

            builder.TreeTableNameWithoutSchema = treeSettings.DbTable;
            builder.TreeTableSchema = treeSettings.DbSchema;
        }

        private static MapperDummyMainEntityObject CreateTestDataItemForDummyMain(
            long index,
            IEnumerable<MapperDummyOneToManyEntityObject> itemsOfDummyOneToMany
            )
        {
            bool isEven = index % 2 == 0;

            int day = isEven ? 2 : 1;

            var localTime = new DateTime(2018, 03, day, 06, 32, 00);

            var dateAndOffsetLocal = new DateTimeOffset(
                localTime,
                TimeZoneInfo.Local.GetUtcOffset(localTime)
                );

            int indexOfDummyOneToMany = GetRandomIndex(itemsOfDummyOneToMany);

            return new MapperDummyMainEntityObject
            {
                Name = $"Name-{index}",
                IdOfDummyOneToManyEntity = itemsOfDummyOneToMany.ElementAt(indexOfDummyOneToMany).Id,
                PropBoolean = isEven,
                PropBooleanNullable = isEven ? new bool?(!isEven) : null,
                PropDate = new DateTime(2018, 01, day),
                PropDateNullable = isEven ? new DateTime?(new DateTime(2018, 02, day)) : null,
                PropDateTimeOffset = dateAndOffsetLocal,
                PropDateTimeOffsetNullable = isEven ? new DateTimeOffset?(dateAndOffsetLocal) : null,
                PropDecimal = 1000M + index + (index / 100M),
                PropDecimalNullable = isEven ? new decimal?(2000M + index + (index / 200M)) : null,
                PropInt32 = 1000 + (int)index,
                PropInt32Nullable = isEven ? new int?(1000 + (int)index) : null,
                PropInt64 = 3000 + index,
                PropInt64Nullable = isEven ? new long?(3000 + index) : null,
                PropString = $"PropString-{index}",
                PropStringNullable = isEven ? $"PropStringNullable-{index}" : null
            };
        }

        private static List<MapperDummyMainDummyManyToManyEntityObject> CreateTestDataItemsForDummyMainDummyManyToMany(
            MapperDummyMainEntityObject itemOfDummyMain,
            IEnumerable<MapperDummyManyToManyEntityObject> itemsOfDummyManyToMany
            )
        {
            var result = new List<MapperDummyMainDummyManyToManyEntityObject>();

            foreach (var itemOfDummyManyToMany in itemsOfDummyManyToMany)
            {
                bool isEven = GetRandomIndex(itemsOfDummyManyToMany) % 2 == 0;

                if (isEven) continue;

                var item = new MapperDummyMainDummyManyToManyEntityObject
                {
                    IdOfDummyMainEntity = itemOfDummyMain.Id,
                    IdOfDummyManyToManyEntity = itemOfDummyManyToMany.Id
                };

                result.Add(item);
            }

            if (!result.Any())
            {
                int index = GetRandomIndex(itemsOfDummyManyToMany);

                var item = new MapperDummyMainDummyManyToManyEntityObject
                {
                    IdOfDummyMainEntity = itemOfDummyMain.Id,
                    IdOfDummyManyToManyEntity = itemsOfDummyManyToMany.ElementAt(index).Id
                };

                result.Add(item);
            }

            return result;
        }

        private static MapperDummyManyToManyEntityObject CreateTestDataItemForDummyManyToMany(long index)
        {
            return new MapperDummyManyToManyEntityObject
            {
                Name = $"Name-{index}"
            };
        }

        private static MapperDummyOneToManyEntityObject CreateTestDataItemForDummyOneToMany(long index)
        {
            return new MapperDummyOneToManyEntityObject
            {
                Name = $"Name-{index}"
            };
        }

        private static MapperDummyTreeEntityObject CreateTestDataItemForDummyTree(IEnumerable<int> indexes, long? parentId)
        {
            string suffix = indexes.Any() ? "-" + string.Join("-", indexes) : string.Empty;

            return new MapperDummyTreeEntityObject
            {
                Name = $"Name{suffix}",
                ParentId = parentId
            };
        }

        private static int GetRandomIndex<T>(IEnumerable<T> items)
        {
            return new Random(Guid.NewGuid().GetHashCode()).Next(0, items.Count());
        }

        private async Task SaveTestDataListForDummyTree(
            MapperDbContext dbContext,
            List<MapperDummyTreeEntityObject> list,
            List<int> parentIndexes,
            long? parentId
            )
        {
            if (parentIndexes.Count == 5)
            {
                return;
            }

            var indexes = new List<int>();

            if (parentIndexes.Any())
            {
                indexes.AddRange(parentIndexes);
            }

            for (int index = 1; index < 4; index++)
            {
                indexes.Add(index);

                var item = CreateTestDataItemForDummyTree(indexes, parentId);

                list.Add(item);

                dbContext.DummyTree.Add(item);

                await dbContext.SaveChangesAsync().ConfigureAwaitWithCultureSaving(false);

                await SaveTestDataListForDummyTree(dbContext, list, indexes, item.Id)
                    .ConfigureAwaitWithCultureSaving(false);

                indexes.RemoveAt(indexes.Count - 1);
            }
        }

        private static async Task<IEnumerable<MapperDummyMainEntityObject>> SeedTestDataForDummyMain(
            MapperDbContext dbContext,
            IEnumerable<MapperDummyOneToManyEntityObject> itemsOfDummyOneToMany
            )
        {
            var result = Enumerable.Range(1, 100)
                .Select(index => CreateTestDataItemForDummyMain(index, itemsOfDummyOneToMany))
                .ToArray();

            dbContext.DummyMain.AddRange(result);

            await dbContext.SaveChangesAsync().ConfigureAwaitWithCultureSaving(false);

            return result;
        }

        private static async Task<IEnumerable<MapperDummyMainDummyManyToManyEntityObject>> SeedTestDataForDummyMainDummyManyToMany(
            MapperDbContext dbContext,
            IEnumerable<MapperDummyMainEntityObject> itemsOfDummyMain,
            IEnumerable<MapperDummyManyToManyEntityObject> itemsOfDummyManyToMany
            )
        {
            var result = new List<MapperDummyMainDummyManyToManyEntityObject>();

            foreach (var itemOfDummyMain in itemsOfDummyMain)
            {
                var itemsOfDummyMainDummyManyToMany = CreateTestDataItemsForDummyMainDummyManyToMany(
                    itemOfDummyMain,
                    itemsOfDummyManyToMany
                    );

                if (itemsOfDummyMainDummyManyToMany.Any())
                {
                    result.AddRange(itemsOfDummyMainDummyManyToMany);
                }
            }

            dbContext.AddRange(result);

            await dbContext.SaveChangesAsync().ConfigureAwaitWithCultureSaving(false);

            return result;
        }

        private static async Task<IEnumerable<MapperDummyManyToManyEntityObject>> SeedTestDataForDummyManyToMany(
            MapperDbContext dbContext
            )
        {
            var result = Enumerable.Range(1, 10)
                .Select(index => CreateTestDataItemForDummyManyToMany(index))
                .ToArray();

            dbContext.DummyManyToMany.AddRange(result);

            await dbContext.SaveChangesAsync().ConfigureAwaitWithCultureSaving(false);

            return result;
        }

        private static async Task<IEnumerable<MapperDummyOneToManyEntityObject>> SeedTestDataForDummyOneToMany(
            MapperDbContext dbContext
            )
        {
            var result = Enumerable.Range(1, 10)
                .Select(index => CreateTestDataItemForDummyOneToMany(index))
                .ToArray();

            dbContext.DummyOneToMany.AddRange(result);

            await dbContext.SaveChangesAsync().ConfigureAwaitWithCultureSaving(false);

            return result;
        }

        private async Task<IEnumerable<MapperDummyTreeEntityObject>> SeedTestDataForDummyTree(
            MapperDbContext dbContext
            )
        {
            var result = new List<MapperDummyTreeEntityObject>();

            await SaveTestDataListForDummyTree(dbContext, result, new List<int>(), null)
                .ConfigureAwaitWithCultureSaving(false);

            var queryTreeTriggerBuilder = CreateQueryTreeTriggerBuilder(TriggerCommandAction.None);

            string sql = queryTreeTriggerBuilder.GetResultSql();

            await dbContext.Database.ExecuteSqlRawAsync(sql).ConfigureAwaitWithCultureSaving(false);

            return result;
        }

        #endregion Private methods
    }
}
