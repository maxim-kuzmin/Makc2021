// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Makc2021.Layer1.Completion;
using Makc2021.Layer1.Query;
using Makc2021.Layer5.Sql.Server.Pages.DummyMain.Item.Queries.Get;
using DummyMainDomainItemGetQueryInput = Makc2021.Layer4.Sql.Domains.DummyMain.Queries.Item.Get.DomainItemGetQueryInput;
using DummyMainDomainItemGetQueryOutput = Makc2021.Layer4.Sql.Domains.DummyMain.Queries.Item.Get.DomainItemGetQueryOutput;
using IDummyMainDomainItemGetQueryHandler = Makc2021.Layer4.Sql.Domains.DummyMain.Queries.Item.Get.IDomainItemGetQueryHandler;
using IDummyMainDomainService = Makc2021.Layer4.Sql.Domains.DummyMain.IDomainService;

namespace Makc2021.Layer5.Sql.Server.Pages.DummyMain.Item
{
    /// <summary>
    /// Сервис страницы сущности "DummyMain".
    /// </summary>
    public class DummyMainItemPageService : IDummyMainItemPageService
    {
        private IDummyMainDomainItemGetQueryHandler HandlerOfDummyMainDomainItemGetQuery { get; }

        private IDummyMainDomainService ServiceOfDummyMainDomain { get; }

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="handlerOfDummyMainDomainItemGetQueryHandler">Обработчик запроса на получение элемента в домене "DummyMain".</param>
        /// <param name="serviceOfDummyMainDomainService">Сервис домена "DummyMain".</param>
        public DummyMainItemPageService(
            IDummyMainDomainItemGetQueryHandler handlerOfDummyMainDomainItemGetQueryHandler,
            IDummyMainDomainService serviceOfDummyMainDomainService
            )
        {
            HandlerOfDummyMainDomainItemGetQuery = handlerOfDummyMainDomainItemGetQueryHandler;
            ServiceOfDummyMainDomain = serviceOfDummyMainDomainService;
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

            var item = input.InputOfDummyMainDomainItemGetQuery;

            await queryResults.AddWithOutputAsync(
                () => GetItemGetQueryResult(
                    new DummyMainDomainItemGetQueryInput
                    {
                        EntityId = item.EntityId
                    },
                    queryCode
                    ),
                queryOutput => output.OutputOfDummyMainDomainItemGetQuery = queryOutput
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

        private async Task<QueryResultWithOutput<DummyMainDomainItemGetQueryOutput>> GetItemGetQueryResult(
            DummyMainDomainItemGetQueryInput input,
            string queryCode
            )
        {
            var queryHandler = HandlerOfDummyMainDomainItemGetQuery;

            try
            {
                queryHandler.OnStart(input, queryCode);

                var queryOutput = await ServiceOfDummyMainDomain.GetItem(
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
