// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Makc2021.Layer1.Completion;
using Makc2021.Layer1.Query;
using Makc2021.Layer4.Sql.Domains.DummyMain;
using Makc2021.Layer4.Sql.Domains.DummyMain.Queries.List.Get;
using Makc2021.Layer5.Sql.Server.Pages.DummyMain.List.Queries.Get;

namespace Makc2021.Layer5.Sql.Server.Pages.DummyMain.List
{
    /// <summary>
    /// Сервис страницы сущностей "DummyMain".
    /// </summary>
    public class DummyMainListPageService : IDummyMainListPageService
    {
        private IDomainListGetQueryHandler DomainListGetQueryHandler { get; }

        private IDomainService DomainService { get; }

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="domainListGetQueryHandler">Обработчик запроса на получение списка в домене.</param>
        /// <param name="domainService">Сервис домена.</param>
        public DummyMainListPageService(
            IDomainListGetQueryHandler domainListGetQueryHandler,
            IDomainService domainService
            )
        {
            DomainListGetQueryHandler = domainListGetQueryHandler;
            DomainService = domainService;
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public async Task<QueryResultWithOutput<DummyMainListPageGetQueryOutput>> Get(
            DummyMainListPageGetQueryInput input,
            string queryCode = null
            )
        {
            QueryResultWithOutput<DummyMainListPageGetQueryOutput> result = new();

            if (string.IsNullOrWhiteSpace(queryCode))
            {
                queryCode = result.QueryCode;
            }
            else
            {
                result.QueryCode = queryCode;
            }

            DummyMainListPageGetQueryOutput output = new();

            List<QueryResult> queryResults = new();

            var list = input.List;

            await queryResults.AddWithOutputAsync(
                () => GetListGetQueryResult(
                    new DomainListGetQueryInput
                    {
                        PageNumber = list.PageNumber,
                        PageSize = list.PageSize,
                        SortDirection = list.SortDirection,
                        SortField = list.SortField,
                        EntityName = list.EntityName
                    },
                    queryCode
                    ),
                queryOutput => output.List = queryOutput
                ).ConfigureAwaitWithCultureSaving(false);

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
            var queryHandler = DomainListGetQueryHandler;

            try
            {
                queryHandler.OnStart(input, queryCode);

                var queryOutput = await DomainService.GetList(
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
