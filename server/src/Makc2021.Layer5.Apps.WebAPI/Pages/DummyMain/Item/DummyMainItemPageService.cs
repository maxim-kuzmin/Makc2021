﻿// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Makc2021.Layer1.Completion;
using Makc2021.Layer1.Query;
using Makc2021.Layer4.Domains.DummyMain;
using Makc2021.Layer4.Domains.DummyMain.Queries.Item.Get;
using Makc2021.Layer5.Apps.WebAPI.Pages.DummyMain.Item.Queries.Get;

namespace Makc2021.Layer5.Apps.WebAPI.Pages.DummyMain.Item
{
    /// <summary>
    /// Сервис страницы сущности "DummyMain".
    /// </summary>
    public class DummyMainItemPageService : IDummyMainItemPageService
    {
        private IItemGetQueryDomainHandler AppItemGetQueryDomainHandler { get; }

        private IDomainService AppService { get; }

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="appItemGetQueryDomainHandler">Обработчик запроса на получение.</param>
        /// <param name="appService">Сервис.</param>
        public DummyMainItemPageService(
            IItemGetQueryDomainHandler appItemGetQueryDomainHandler,
            IDomainService appService
            )
        {
            AppItemGetQueryDomainHandler = appItemGetQueryDomainHandler;
            AppService = appService;
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public async Task<QueryResultWithOutput<DummyMainItemPageGetQueryOutput>> Get(DummyMainItemPageGetQueryInput input)
        {
            QueryResultWithOutput<DummyMainItemPageGetQueryOutput> result = new();

            DummyMainItemPageGetQueryOutput output = new();

            List<QueryResult> queryResults = new();

            var queryResult1 = await  GetItemGetQueryResult(
                result.QueryCode,
                new ItemGetQueryDomainInput
                {
                    EntityId = input.Item.EntityId
                })
                .ConfigureAwaitWithCultureSaving(false);

            queryResults.Add(queryResult1);

            if (queryResult1.IsOk && queryResult1.Output != null)
            {
                output.Item = queryResult1.Output;
            }

            result.Load(queryResults);

            if (result.IsOk)
            {
                result.Output = output;
            }

            return result;
        }

        #endregion Public methods

        #region Private methods

        private async Task<QueryResultWithOutput<ItemGetQueryDomainOutput>> GetItemGetQueryResult(
            string queryCode,
            ItemGetQueryDomainInput input
            )
        {
            var queryHandler = AppItemGetQueryDomainHandler;

            queryHandler.QueryResult.QueryCode = queryCode;

            try
            {
                queryHandler.OnStart(input);

                var queryOutput = await AppService.GetItem(queryHandler.QueryInput)
                    .ConfigureAwaitWithCultureSaving(false);

                queryHandler.OnSuccess(queryOutput);
            }
            catch (Exception ex)
            {
                queryHandler.OnError(ex);
            }

            return queryHandler.QueryResult;
        }

        #endregion Private methods
    }
}
