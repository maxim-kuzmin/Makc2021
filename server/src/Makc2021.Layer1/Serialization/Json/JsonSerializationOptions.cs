// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System.Text.Encodings.Web;
using System.Text.Json;

namespace Makc2021.Layer1.Serialization.Json
{
    /// <summary>
    /// Опции сериализации JSON.
    /// </summary>
    public static class JsonSerializationOptions
    {
        #region Properties

        /// <summary>
        /// Для конфигурации.
        /// </summary>
        public static JsonSerializerOptions ForConfig { get; } = new()
        {
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            IgnoreNullValues = true
        };

        /// <summary>
        /// Для JavaScript.
        /// </summary>
        public static JsonSerializerOptions ForJavaScript { get; } = new()
        {
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            IgnoreNullValues = true
        };

        /// <summary>
        /// Для регистратора.
        /// </summary>
        public static JsonSerializerOptions ForLogger { get; } = new()
        {
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            IgnoreNullValues = false
        };

        #endregion Properties
    }
}