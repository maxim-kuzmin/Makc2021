// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Makc2021.Layer1.Query.Exceptions;
using Makc2021.Layer1.Resources.Errors;
using Microsoft.Extensions.Logging;

namespace Makc2021.Layer1.Query
{
    /// <summary>
    /// Сервис запроса.
    /// </summary>
    /// <typeparam name="TQueryHandler">Тип обработчика запроса.</typeparam>
    public class QueryService<TQueryHandler>
        where TQueryHandler : QueryHandler
    {
        #region Properties

        /// <summary>
        /// Обработчик запроса.
        /// </summary>
        protected TQueryHandler QueryHandler { get; private set; }

        /// <summary>
        /// Ресурс ошибок.
        /// </summary>
        protected IErrorsResource ResourceOfErrors => QueryHandler.ResourceOfErrors;

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="queryExecution">Обработчик запроса.</param>
        public QueryService(TQueryHandler queryExecution)
        {
            QueryHandler = queryExecution;
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Обработать событие возникновения ошибки.
        /// </summary>
        /// <param name="ex">Исключение.</param>
        /// <param name="logger">Регистратор.</param>
        /// <param name="queryResult">Результат запроса.</param>
        public void OnError(Exception ex, ILogger logger, QueryResult queryResult)
        {
            QueryHandler.OnError(ex, logger, queryResult);
        }

        #endregion Public methods

        /// <summary>
        /// Получить сообщения об ошибках на недействительный ввод.
        /// </summary>
        /// <param name="exception">Исключение.</param>
        /// <returns>Сообщения об ошибках.</returns>
        protected IEnumerable<string> GetErrorMessagesOnInvalidInput(Exception exception)
        {
            if (exception is InvalidPropertiesException ex)
            {
                var ivalidProperties = ex.InvalidProperties;

                return new[]
                {
                    string.Format(
                        ResourceOfErrors.GetStringFormatMessageIvalidInput(),
                        string.Join(", ", ivalidProperties)
                        )
                };
            }

            return null;
        }

    }
}