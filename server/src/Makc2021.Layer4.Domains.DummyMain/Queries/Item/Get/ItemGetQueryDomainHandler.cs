﻿// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System.Linq;
using Makc2021.Layer1.Query;
using Makc2021.Layer1.Query.Exceptions;
using Makc2021.Layer1.Query.Handlers;
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
            IItemGetQueryDomainResource appResource,
            IQueryResource appQueryResource,
            ILogger<ItemGetQueryDomainHandler> extLogger
            )
            : base(
                  appResource.GetQueryName(),
                  appQueryResource,
                  extLogger
                  )
        {
            FunctionToTransformQueryInput = TransformInput;
            FunctionToTransformQueryOutput = TransformOutput;
        }

        #endregion Constructors

        #region Private methods

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
                throw new InvalidQueryInputException(AppQueryResource, invalidProperties);
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
