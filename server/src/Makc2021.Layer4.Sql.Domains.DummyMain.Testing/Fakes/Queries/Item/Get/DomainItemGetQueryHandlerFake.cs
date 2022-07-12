// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2021.Layer1.Query;
using Makc2021.Layer1.Testing.Fakes.Query;
using Makc2021.Layer4.Sql.Domains.DummyMain.Queries.Item.Get;

namespace Makc2021.Layer4.Sql.Domains.DummyMain.Testing.Fakes.Queries.Item.Get
{
    /// <summary>
    /// Подделка обработчика запроса на получение элемента в домене.
    /// </summary>
    public class DomainItemGetQueryHandlerFake : QueryHandlerFake, IDomainItemGetQueryHandler
    {
        #region Properties

        /// <inheritdoc/>
        public DomainItemGetQueryInput QueryInput { get; private set; }

        /// <inheritdoc/>
        public QueryResultWithOutput<DomainItemGetQueryOutput> QueryResult { get; private set; }

        #endregion Properties

        #region Public methods

        /// <inheritdoc/>
        public void OnStart(DomainItemGetQueryInput queryInput, string queryCode = null)
        {
            QueryInput = queryInput;

            QueryResult = new QueryResultWithOutput<DomainItemGetQueryOutput>
            {
                QueryCode = queryCode
            };
        }

        /// <inheritdoc/>
        public void OnSuccess(DomainItemGetQueryOutput queryOutput)
        {
            QueryResult.Output = queryOutput;

            OnSuccess(QueryResult);
        }

        /// <inheritdoc/>
        public void OnSuccess(QueryResultWithOutput<DomainItemGetQueryOutput> queryResult)
        {
            queryResult.IsOk = true;

            QueryResult = queryResult;
        }

        #endregion Public methods
    }
}
