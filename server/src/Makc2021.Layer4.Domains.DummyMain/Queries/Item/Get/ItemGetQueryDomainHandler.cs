// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Makc2021.Layer1.Query.Exceptions;
using Makc2021.Layer1.Query.Handlers;
using Makc2021.Layer1.Resources.Errors;
using Makc2021.Layer4.Domains.DummyMain.Resources.Names;
using Microsoft.Extensions.Logging;

namespace Makc2021.Layer4.Domains.DummyMain.Queries.Item.Get
{
    /// <summary>
    /// Обработчик запроса на получение элемента в домене.
    /// </summary>
    public class ItemGetQueryDomainHandler : QueryWithInputAndOutputHandler<ItemGetQueryDomainInput, ItemGetQueryDomainOutput>
    {
        #region Constructors

        /// <inheritdoc/>
        public ItemGetQueryDomainHandler(
            INamesDomainResource appNamesDomainResource,
            IErrorsResource appErrorsResource,
            ILogger<ItemGetQueryDomainHandler> extLogger
            )
            : base(
                  appNamesDomainResource.GetForItemGetQuery(),
                  appErrorsResource,
                  extLogger
                  )
        {
            FunctionToGetErrorMessages = GetErrorMessages;
            FunctionToTransformQueryInput = TransformInput;
            FunctionToTransformQueryOutput = TransformOutput;
        }

        #endregion Constructors

        #region Private methods

        private IEnumerable<string> GetErrorMessages(Exception exception)
        {
            return GetErrorMessagesOnInvalidQueryInput(exception);
        }

        private ItemGetQueryDomainInput TransformInput(ItemGetQueryDomainInput input)
        {
            if (input == null)
            {
                input = new ItemGetQueryDomainInput();
            }

            input.Normalize();

            var invalidProperties = input.GetInvalidProperties();

            if (invalidProperties.Any())
            {
                throw new InvalidPropertiesException(AppErrorsResource, invalidProperties);
            }

            return input;
        }

        private ItemGetQueryDomainOutput TransformOutput(ItemGetQueryDomainOutput output)
        {
            return output.ObjectOfDummyMainEntity != null ? output : null;
        }

        #endregion Private methods
    }
}
