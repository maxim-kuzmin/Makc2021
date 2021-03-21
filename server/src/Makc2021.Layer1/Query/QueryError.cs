﻿// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System;
using System.Net;
using System.Net.Http;

namespace Makc2021.Layer1.Query
{
    /// <summary>
    /// Ошибка запроса.
    /// </summary>
    public class QueryError
    {
        #region Properties

        private IQueryResource Resource { get; }

        /// <summary>
        /// Код.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Исключение, приведшее к возникновению ошибки.
        /// </summary>
        public Exception Exception { get; set; }

        /// <summary>
        /// Код HTTP-статуса.
        /// </summary>
        public HttpStatusCode HttpStatusCode { get; set; }

        /// <summary>
        /// Признак того, что код и URL спрятаны.
        /// </summary>
        public bool IsCodeAndUrlHidden { get; set; }

        /// <summary>
        /// Признак того, что сообщение об ошибке должно быть зарегистрировано в журнале.
        /// </summary>
        public bool IsLoggable { get; set; }

        /// <summary>
        /// Сообщение об ошибке.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// URL.
        /// </summary>
        public string Url { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор информации об ошибке. 
        /// Если исключение равно нулю, признак того, что сообщение об ошибке должно быть зарегистрировано в журнале,
        /// устанавливается в false, иначе - в true.
        /// Если исключение равно нулю, признак того, что код и URL спрятаны, устанавливается в true, иначе - в false. 
        /// </summary>
        /// <param name="exception">Исключение.</param>
        /// <param name="resource">Ресурс.</param>
        public QueryError(Exception exception, IQueryResource resource)
        {
            Exception = exception;
            Resource = resource;

            IsLoggable = exception != null;
            IsCodeAndUrlHidden = exception == null;

            Message = resource.GetUnknownErrorMessage();
            Code = Guid.NewGuid().ToString("N").ToUpper();
            HttpStatusCode = HttpStatusCode.InternalServerError;
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Получение сообщения для HTTP-отклика.
        /// </summary>
        /// <returns>Сообщение для HTTP-отклика.</returns>
        public HttpResponseMessage GetHttpResponseMessage()
        {
            return new HttpResponseMessage(HttpStatusCode)
            {
                Content = new StringContent(CreateMessageWithCode()),
                ReasonPhrase = Message
            };
        }

        /// <summary>
        /// Создание сообщения с кодом ошибки.
        /// </summary>
        /// <returns>Сообщение с кодом ошибки.</returns>
        public string CreateMessageWithCode()
        {
            return IsCodeAndUrlHidden ? Message : Resource.GetErrorMessageWithCodeAndUrl(Message, Code, Url);
        }

        #endregion Public methods
    }
}
