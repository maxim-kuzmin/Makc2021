// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2021.Layer1.Query;
using Makc2021.Layer1.Query.Handlers;
using Microsoft.Extensions.Logging;

namespace Makc2021.Layer4.Domains.DummyMain.Queries.List.Get
{
    /// <summary>
    /// Обработчик запроса на получение списка в домене.
    /// </summary>
    public class ListGetQueryDomainHandler : QueryWithInputAndOutputHandler<ListGetQueryDomainInput, ListGetQueryDomainOutput>
    {
        #region Constructors

        /// <inheritdoc/>
        public ListGetQueryDomainHandler(
            IListGetQueryDomainResource appResource,
            IQueryResource appQueryResource,
            ILogger<ListGetQueryDomainHandler> extLogger
            )
            : base(
                  appResource.GetQueryName(),
                  appQueryResource,
                  extLogger
                  )
        {
            FunctionToTransformQueryInput = TransformInput;
        }

        #endregion Constructors

        #region Private methods

        private ListGetQueryDomainInput TransformInput(ListGetQueryDomainInput input)
        {
            if (input == null)
            {
                input = new ListGetQueryDomainInput();
            }

            input.Normalize();

            return input;
        }

        #endregion Private methods
    }
}
