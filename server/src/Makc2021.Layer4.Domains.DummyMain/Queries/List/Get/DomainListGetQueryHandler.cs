// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System.Linq;
using Makc2021.Layer1.Common;
using Makc2021.Layer1.Query;
using Makc2021.Layer1.Query.Handlers;
using Microsoft.Extensions.Logging;

namespace Makc2021.Layer4.Domains.DummyMain.Queries.List.Get
{
    /// <summary>
    /// Обработчик запроса на получение списка в домене.
    /// </summary>
    public class DomainListGetQueryHandler :
        QueryWithInputAndOutputHandler<DomainListGetQueryInput, DomainListGetQueryOutput>,
        IDomainListGetQueryHandler
    {
        #region Constructors

        /// <inheritdoc/>
        public DomainListGetQueryHandler(
            IDomainResource appResource,
            IQueryResource appQueryResource,
            ILogger<DomainListGetQueryHandler> extLogger
            )
            : base(
                  appResource.GetListGetQueryName(),
                  appQueryResource,
                  extLogger
                  )
        {
            FunctionToTransformQueryInput = TransformQueryInput;
        }

        #endregion Constructors

        #region Private methods

        private DomainListGetQueryInput TransformQueryInput(DomainListGetQueryInput input)
        {
            if (input == null)
            {
                input = new DomainListGetQueryInput();
            }

            input.Normalize();

            var invalidProperties = input.GetInvalidProperties();

            if (invalidProperties.Any())
            {
                throw new CommonException(AppQueryResource.GetErrorMessageForInvalidInput(invalidProperties));
            }

            return input;
        }

        #endregion Private methods
    }
}
