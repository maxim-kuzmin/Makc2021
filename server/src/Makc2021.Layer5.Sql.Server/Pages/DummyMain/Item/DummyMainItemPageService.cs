// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Makc2021.Layer1.Completion;
using Makc2021.Layer1.Query;
using Makc2021.Layer4.Sql.Domains.DummyMain;
using Makc2021.Layer4.Sql.Domains.DummyMain.Queries.Item.Get;
using Makc2021.Layer5.Sql.Server.Pages.DummyMain.Item.Queries.Get;

namespace Makc2021.Layer5.Sql.Server.Pages.DummyMain.Item
{
    /// <summary>
    /// Сервис страницы сущности "DummyMain".
    /// </summary>
    public class DummyMainItemPageService : IDummyMainItemPageService
    {
        private IDomainItemGetQueryHandler DomainItemGetQueryHandler { get; }

        private IDomainService DomainService { get; }

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="domainItemGetQueryHandler">Обработчик запроса на получение элемента в домене.</param>
        /// <param name="domainService">Сервис домена.</param>
        public DummyMainItemPageService(
            IDomainItemGetQueryHandler domainItemGetQueryHandler,
            IDomainService domainService
            )
        {
            DomainItemGetQueryHandler = domainItemGetQueryHandler;
            DomainService = domainService;
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

            await queryResults.AddAsync(
                () => GetItemGetQueryResult(
                    new DomainItemGetQueryInput
                    {
                        EntityId = item.EntityId
                    },
                    queryCode
                    ),
                queryOutput => output.Item = queryOutput
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

        private async Task<QueryResultWithOutput<DomainItemGetQueryOutput>> GetItemGetQueryResult(            
            DomainItemGetQueryInput input,
            string queryCode
            )
        {
            var queryHandler = DomainItemGetQueryHandler;

            try
            {
                queryHandler.OnStart(input, queryCode);

                var queryOutput = await DomainService.GetItem(
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
