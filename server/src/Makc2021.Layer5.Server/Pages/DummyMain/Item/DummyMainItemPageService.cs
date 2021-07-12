// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Makc2021.Layer1.Completion;
using Makc2021.Layer1.Query;
using Makc2021.Layer4.Domains.DummyMain;
using Makc2021.Layer4.Domains.DummyMain.Queries.Item.Get;
using Makc2021.Layer5.Server.Pages.DummyMain.Item.Queries.Get;

namespace Makc2021.Layer5.Server.Pages.DummyMain.Item
{
    /// <summary>
    /// Сервис страницы сущности "DummyMain".
    /// </summary>
    public class DummyMainItemPageService : IDummyMainItemPageService
    {
        private IDomainItemGetQueryHandler AppItemGetQueryDomainHandler { get; }

        private IDomainService AppService { get; }

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="appItemGetQueryDomainHandler">Обработчик запроса на получение.</param>
        /// <param name="appService">Сервис.</param>
        public DummyMainItemPageService(
            IDomainItemGetQueryHandler appItemGetQueryDomainHandler,
            IDomainService appService
            )
        {
            AppItemGetQueryDomainHandler = appItemGetQueryDomainHandler;
            AppService = appService;
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public async Task<QueryResultWithOutput<DummyMainItemPageGetQueryOutput>> Get(
            DummyMainItemPageGetQueryInput input,
            string queryCode = null
            )
        {
            QueryResultWithOutput<DummyMainItemPageGetQueryOutput> result = new();

            if (string.IsNullOrWhiteSpace(queryCode))
            {
                queryCode = result.QueryCode;
            }
            else
            {
                result.QueryCode = queryCode;
            }

            DummyMainItemPageGetQueryOutput output = new();

            List<QueryResult> queryResults = new();

            var item = input.Item;

            var queryResult1 = await GetItemGetQueryResult(               
                new DomainItemGetQueryInput
                {
                    EntityId = item.EntityId
                },
                queryCode
                ).ConfigureAwaitWithCultureSaving(false);

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

        private async Task<QueryResultWithOutput<DomainItemGetQueryOutput>> GetItemGetQueryResult(            
            DomainItemGetQueryInput input,
            string queryCode
            )
        {
            var queryHandler = AppItemGetQueryDomainHandler;

            try
            {
                queryHandler.OnStart(input, queryCode);

                var queryOutput = await AppService.GetItem(
                    queryHandler.QueryInput
                    ).ConfigureAwaitWithCultureSaving(false);

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
