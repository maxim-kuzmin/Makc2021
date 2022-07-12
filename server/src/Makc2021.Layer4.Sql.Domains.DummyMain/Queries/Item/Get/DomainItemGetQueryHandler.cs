// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System.Linq;
using Makc2021.Layer1.Common;
using Makc2021.Layer1.Query;
using Makc2021.Layer1.Query.Handlers;
using Microsoft.Extensions.Logging;

namespace Makc2021.Layer4.Sql.Domains.DummyMain.Queries.Item.Get
{
    /// <summary>
    /// Обработчик запроса на получение элемента в домене.
    /// </summary>
    public class DomainItemGetQueryHandler :
        QueryWithInputAndOutputHandler<DomainItemGetQueryInput, DomainItemGetQueryOutput>,
        IDomainItemGetQueryHandler
    {
        #region Constructors

        /// <inheritdoc/>
        public DomainItemGetQueryHandler(
            IDomainResource domainResource,
            IQueryResource queryResource,
            ILogger<DomainItemGetQueryHandler> logger
            )
            : base(
                  domainResource.GetItemGetQueryName(),
                  queryResource,
                  logger
                  )
        {
            FunctionToTransformQueryInput = TransformQueryInput;
            FunctionToTransformQueryOutput = TransformQueryOutput;
        }

        #endregion Constructors

        #region Private methods

        private DomainItemGetQueryInput TransformQueryInput(DomainItemGetQueryInput input)
        {
            if (input == null)
            {
                input = new DomainItemGetQueryInput();
            }

            input.Normalize();

            var invalidProperties = input.GetInvalidProperties();

            if (invalidProperties.Any())
            {
                throw new CommonException(QueryResource.GetErrorMessageForInvalidInput(invalidProperties));
            }

            return input;
        }

        private DomainItemGetQueryOutput TransformQueryOutput(DomainItemGetQueryOutput output)
        {
            return output.ObjectOfDummyMainEntity != null ? output : null;
        }

        #endregion Private methods
    }
}
