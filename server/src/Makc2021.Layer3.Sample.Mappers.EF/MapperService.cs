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

        private IClientProvider AppClientProvider { get; }

        private EntitiesSettings AppEntitiesSettings { get; }

        private IMapperDbFactory AppMapperDbFactory { get; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>        
        /// <param name="appEntitiesSettings">Настройки сущностей.</param>
        /// <param name="appClientProvider">Поставщик клиента.</param>
        /// <param name="appMapperDbFactory">Фабрика базы данных сопоставителя.</param>
        public MapperService(            
            IClientProvider appClientProvider,
            EntitiesSettings appEntitiesSettings,
            IMapperDbFactory appMapperDbFactory
            )
        {
            AppClientProvider = appClientProvider;
            AppEntitiesSettings = appEntitiesSettings;
            AppMapperDbFactory = appMapperDbFactory;
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public async Task MigrateDatabase()
        {
            using var dbContext = AppMapperDbFactory.CreateDbContext();

            await dbContext.Database.MigrateAsync().ConfigureAwaitWithCultureSaving(false);
        }

        /// <inheritdoc/>
        public async Task SeedTestData()
        {
            using var dbContext = AppMapperDbFactory.CreateDbContext();

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
            var result = AppClientProvider.CreateQueryTreeTriggerBuilder();

            result.Action = action;

            InitQueryBuilder(result, AppEntitiesSettings.DummyTreeLink, AppEntitiesSettings.DummyTree);

            return result;
        }

        private static void InitQueryBuilder(
            TreeTriggerCommandBuilder builder,
            DummyTreeLinkEntitySetting linkSettings,
            DummyTreeEntitySetting treeSettings
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

        private static DummyMainEntityMapperObject CreateTestDataItemForDummyMain(
            long index,
            IEnumerable<DummyOneToManyEntityMapperObject> itemsOfDummyOneToMany
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

            return new DummyMainEntityMapperObject
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

        private static List<DummyMainDummyManyToManyEntityMapperObject> CreateTestDataItemsForDummyMainDummyManyToMany(
            DummyMainEntityMapperObject itemOfDummyMain,
            IEnumerable<DummyManyToManyEntityMapperObject> itemsOfDummyManyToMany
            )
        {
            var result = new List<DummyMainDummyManyToManyEntityMapperObject>();

            foreach (var itemOfDummyManyToMany in itemsOfDummyManyToMany)
            {
                bool isEven = GetRandomIndex(itemsOfDummyManyToMany) % 2 == 0;

                if (isEven) continue;

                var item = new DummyMainDummyManyToManyEntityMapperObject
                {
                    IdOfDummyMainEntity = itemOfDummyMain.Id,
                    IdOfDummyManyToManyEntity = itemOfDummyManyToMany.Id
                };

                result.Add(item);
            }

            if (!result.Any())
            {
                int index = GetRandomIndex(itemsOfDummyManyToMany);

                var item = new DummyMainDummyManyToManyEntityMapperObject
                {
                    IdOfDummyMainEntity = itemOfDummyMain.Id,
                    IdOfDummyManyToManyEntity = itemsOfDummyManyToMany.ElementAt(index).Id
                };

                result.Add(item);
            }

            return result;
        }

        private static DummyManyToManyEntityMapperObject CreateTestDataItemForDummyManyToMany(long index)
        {
            return new DummyManyToManyEntityMapperObject
            {
                Name = $"Name-{index}"
            };
        }

        private static DummyOneToManyEntityMapperObject CreateTestDataItemForDummyOneToMany(long index)
        {
            return new DummyOneToManyEntityMapperObject
            {
                Name = $"Name-{index}"
            };
        }

        private static DummyTreeEntityMapperObject CreateTestDataItemForDummyTree(IEnumerable<int> indexes, long? parentId)
        {
            string suffix = indexes.Any() ? "-" + string.Join("-", indexes) : string.Empty;

            return new DummyTreeEntityMapperObject
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
            List<DummyTreeEntityMapperObject> list,
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

        private static async Task<IEnumerable<DummyMainEntityMapperObject>> SeedTestDataForDummyMain(
            MapperDbContext dbContext,
            IEnumerable<DummyOneToManyEntityMapperObject> itemsOfDummyOneToMany
            )
        {
            var result = Enumerable.Range(1, 100)
                .Select(index => CreateTestDataItemForDummyMain(index, itemsOfDummyOneToMany))
                .ToArray();

            dbContext.DummyMain.AddRange(result);

            await dbContext.SaveChangesAsync().ConfigureAwaitWithCultureSaving(false);

            return result;
        }

        private static async Task<IEnumerable<DummyMainDummyManyToManyEntityMapperObject>> SeedTestDataForDummyMainDummyManyToMany(
            MapperDbContext dbContext,
            IEnumerable<DummyMainEntityMapperObject> itemsOfDummyMain,
            IEnumerable<DummyManyToManyEntityMapperObject> itemsOfDummyManyToMany
            )
        {
            var result = new List<DummyMainDummyManyToManyEntityMapperObject>();

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

        private static async Task<IEnumerable<DummyManyToManyEntityMapperObject>> SeedTestDataForDummyManyToMany(
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

        private static async Task<IEnumerable<DummyOneToManyEntityMapperObject>> SeedTestDataForDummyOneToMany(
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

        private async Task<IEnumerable<DummyTreeEntityMapperObject>> SeedTestDataForDummyTree(
            MapperDbContext dbContext
            )
        {
            var result = new List<DummyTreeEntityMapperObject>();

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
