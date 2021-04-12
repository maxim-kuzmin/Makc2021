﻿// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Makc2021.Layer1.Completion;
using Makc2021.Layer1.Query;
using Makc2021.Layer4.Domains.DummyMain;
using Makc2021.Layer4.Domains.DummyMain.Queries.List.Get;
using Makc2021.Layer5.Apps.WebAPI.Pages.DummyMain.List.Queries.Get;

namespace Makc2021.Layer5.Apps.WebAPI.Pages.DummyMain.List
{
    /// <summary>
    /// Сервис страницы сущностей "DummyMain".
    /// </summary>
    public class DummyMainListPageService : IDummyMainListPageService
    {
        private IListGetQueryDomainHandler AppListGetQueryDomainHandler { get; }

        private IDomainService AppService { get; }

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="appListGetQueryDomainHandler">Обработчик запроса на получение.</param>
        /// <param name="appService">Сервис.</param>
        public DummyMainListPageService(
            IListGetQueryDomainHandler appListGetQueryDomainHandler,
            IDomainService appService
            )
        {
            AppListGetQueryDomainHandler = appListGetQueryDomainHandler;
            AppService = appService;
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public async Task<QueryResultWithOutput<DummyMainListPageGetQueryOutput>> Get(DummyMainListPageGetQueryInput input)
        {
            QueryResultWithOutput<DummyMainListPageGetQueryOutput> result = new();

            DummyMainListPageGetQueryOutput output = new();

            List<QueryResult> queryResults = new();

            var queryResult1 = await  GetListGetQueryResult(
                result.QueryCode,
                new ListGetQueryDomainInput
                {
                    PageNumber = input.List.PageNumber,
                    PageSize = input.List.PageSize
                })
                .ConfigureAwaitWithCultureSaving(false);

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

        private async Task<QueryResultWithOutput<ListGetQueryDomainOutput>> GetListGetQueryResult(
            string queryCode,
            ListGetQueryDomainInput input
            )
        {
            var queryHandler = AppListGetQueryDomainHandler;

            queryHandler.QueryResult.QueryCode = queryCode;

            try
            {
                queryHandler.OnStart(input);

                var queryOutput = await AppService.GetList(queryHandler.QueryInput)
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