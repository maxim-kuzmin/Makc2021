// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Makc2021.Layer1.Extensions;
using Makc2021.Layer1.Query.Exceptions;
using Makc2021.Layer1.Query.Services.Async;
using Makc2021.Layer1.Resources.Errors;
using Microsoft.EntityFrameworkCore;

namespace Makc2021.Layer4.Domains.DummyMain.Queries.Item.Get
{
    /// <summary>
    /// Сервис запроса на получение элемента в домене.
    /// </summary>
    public class ItemGetQueryDomainService :
        AsyncQueryWithInputAndOutputService<ItemGetQueryDomainInput, ItemGetQueryDomainOutput>,
        IItemGetQueryDomainService
    {
        #region Properties

        private IDomainService Service { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="executable">Выполняемое.</param>
        /// <param name="resourceOfErrors">Ресурс ошибок.</param>
        public ItemGetQueryDomainService(IDomainService service, IErrorsResource resourceOfErrors)
            : base(resourceOfErrors)
        {
            Service = service;

            FunctionToExecute = OnExecute;

            QueryHandler.FunctionToGetErrorMessages = GetErrorMessages;
            QueryHandler.FunctionToTransformInput = TransformInput;
            QueryHandler.FunctionToTransformOutput = TransformOutput;
        }

        #endregion Constructors

        #region Private methods

        private IEnumerable<string> GetErrorMessages(Exception exception)
        {
            return GetErrorMessagesOnInvalidInput(exception);
        }

        private async Task<ItemGetQueryDomainOutput> OnExecute(ItemGetQueryDomainInput input)
        {
            ItemGetQueryDomainOutput result = null;

            using var dbContext = Service.CreateSampleDbContext();

            var entityDummyMain = await dbContext.DummyMain
                .Include(x => x.ObjectOfDummyOneToManyEntity)
                .Include(x => x.ObjectsOfDummyMainDummyManyToManyEntity)
                .ApplyFiltering(input)
                .FirstOrDefaultAsync()
                .ConfigureAwaitWithCurrentCulture(false);

            if (entityDummyMain != null)
            {
                result = Service.CreateItem(entityDummyMain);

                if (result.ObjectsOfDummyMainDummyManyToManyEntity != null)
                {
                    long[] idsOfDummyManyToMany = result.ObjectsOfDummyMainDummyManyToManyEntity
                        .Select(x => x.ObjectDummyManyToManyId)
                        .ToArray();

                    if (idsOfDummyManyToMany.Any())
                    {
                        var enities = await dbContext.DummyManyToMany
                            .Where(x => idsOfDummyManyToMany.Contains(x.Id))
                            .ToArrayAsync()
                            .ConfigureAwaitWithCurrentCulture(false);

                        if (enities.Any())
                        {
                            Service.InitItemDummyManyToMany(result, enities);
                        }
                    }
                }
            }

            return result;
        }

        private ItemGetQueryDomainInput TransformInput(ItemGetQueryDomainInput input)
        {
            if (input == null)
            {
                input = new ItemGetQueryDomainInput();
            }

            input.Normalize();

            var invalidProperties = input.GetInvalidProperties();

            if (invalidProperties.Any())
            {
                throw new InvalidPropertiesException(invalidProperties);
            }

            return input;
        }

        private ItemGetQueryDomainOutput TransformOutput(ItemGetQueryDomainOutput output)
        {
            return output.ObjectOfDummyMainEntity != null ? output : null;
        }

        #endregion Private methods
    }
}