// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Makc2021.Layer1.Completion;
using Makc2021.Layer1.Query;
using Makc2021.Layer4.Domains.DummyMain;
using Makc2021.Layer4.Domains.DummyMain.Queries.List.Get;
using Makc2021.Layer5.Apps.Server.Pages.DummyMain.List.Queries.Get;

namespace Makc2021.Layer5.Apps.Server.Pages.DummyMain.List
{
    /// <summary>
    /// Сервис страницы сущностей "DummyMain".
    /// </summary>
    public class ListPageService : IListPageService
    {
        private IDomainListGetQueryHandler AppListGetQueryDomainHandler { get; }

        private IDomainService AppService { get; }

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="appListGetQueryDomainHandler">Обработчик запроса на получение.</param>
        /// <param name="appService">Сервис.</param>
        public ListPageService(
            IDomainListGetQueryHandler appListGetQueryDomainHandler,
            IDomainService appService
            )
        {
            AppListGetQueryDomainHandler = appListGetQueryDomainHandler;
            AppService = appService;
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public async Task<QueryResultWithOutput<ListPageGetQueryOutput>> Get(
            ListPageGetQueryInput input,
            string queryCode = null
            )
        {
            QueryResultWithOutput<ListPageGetQueryOutput> result = new();

            if (string.IsNullOrWhiteSpace(queryCode))
            {
                queryCode = result.QueryCode;
            }            

            ListPageGetQueryOutput output = new();

            List<QueryResult> queryResults = new();

            var list = input.List;

            var queryResult1 = await GetListGetQueryResult(                
                new DomainListGetQueryInput
                {
                    PageNumber = list.PageNumber,
                    PageSize = list.PageSize,
                    SortDirection = list.SortDirection,
                    SortField = list.SortField,
                    EntityName = list.EntityName
                },
                queryCode
                ).ConfigureAwaitWithCultureSaving(false);

            queryResults.Add(queryResult1);

            if (queryResult1.IsOk && queryResult1.Output != null)
            {
                output.List = queryResult1.Output;
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

        private async Task<QueryResultWithOutput<DomainListGetQueryOutput>> GetListGetQueryResult(
            DomainListGetQueryInput input,
            string queryCode
            )
        {
            var queryHandler = AppListGetQueryDomainHandler;

            try
            {
                queryHandler.OnStart(input, queryCode);

                var queryOutput = await AppService.GetList(
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
