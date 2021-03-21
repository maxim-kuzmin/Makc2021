// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;

namespace Makc2021.Layer1.Converting
{
    /// <summary>
    /// Расширение преобразования.
    /// </summary>
    public static class ConvertingExtension
    {
        #region Public methods

        /// <summary>
        /// Преобразовать из IP-адреса версии в строковое представление версии 4.
        /// </summary>
        /// <param name="value">IP-адрес.</param>
        /// <returns>Строковое представление IP-адреса.</returns>
        public static string ConvertFromIPToV4String(this IPAddress value)
        {
            if (IPAddress.IsLoopback(value))
            {
                return "127.0.0.1";
            }

            // If we got an IPV6 address, then we need to ask the network for the IPV4 address 
            // This usually only happens when the browser is on the same machine as the server.
            if (value.AddressFamily == AddressFamily.InterNetworkV6)
            {
                value = Dns.GetHostEntry(value).AddressList.First(x => x.AddressFamily == AddressFamily.InterNetwork);
            }

            return value.ToString();
        }

        /// <summary>
        /// Преобразовать из даты и времени в строку в формате ISO8601.
        /// </summary>
        /// <param name="value">Дата и время.</param>
        /// <returns>Строковое представление даты и времени в формате ISO8601.</returns>
        public static string ConvertFromDateTimeToISO8601String(this DateTime value)
        {
            return value.ToString("yyyy-MM-ddTHH:mm:ss.FFF");
        }

        /// <summary>
        /// Преобразовать из даты и времени в строку в формате двусторонней передачи.
        /// </summary>
        /// <param name="value">Дата и время.</param>
        /// <returns>Строковое представление даты и времени в формате двусторонней передачи.</returns>
        public static string ConvertFromDateTimeToRoundTripString(this DateTime value)
        {
            return value.ToString("o");
        }

        /// <summary>
        /// Преобразовать из даты и времени с часовым поясом в строку в формате двусторонней передачи.
        /// </summary>
        /// <param name="value">Значение.</param>
        /// <returns>Строковое представление даты и времени с часовым поясом в формате двусторонней передачи.</returns>
        public static string ConvertFromDateTimeOffsetToRoundTripString(
            this DateTimeOffset value
            )
        {
            return value.ToString("o");
        }

        /// <summary>
        /// Преобразовать из строки в формате двусторонней передачи в дату и время с часовым поясом.
        /// </summary>
        /// <param name="value">Строка в формате двусторонней передачи.</param>
        /// <returns>Дата и время с часовым поясом.</returns>
        public static DateTimeOffset ConvertFromRoundTripStringToDateTimeOffset(
            this string value
            )
        {
            return DateTimeOffset.ParseExact(value, "o", CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Преобразовать из даты в строку.
        /// </summary>
        /// <param name="value">Дата.</param>
        /// <param name="resource">Ресурс.</param>
        /// <returns>Строковое представление даты.</returns>        
        public static string ConvertFromDateToString(this DateTime value, IConvertingResource resource)
        {
            return value.ToString(resource.GetFormatForDate(), CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Преобразовать из строки в дату.
        /// </summary>
        /// <param name="value">Строковое представление даты.</param>
        /// <param name="resource">Ресурс.</param>
        /// <returns>Дата.</returns>
        public static DateTime ConvertToDate(this string value, IConvertingResource resource)
        {
            return DateTime.ParseExact(value.Trim(), resource.GetFormatForDate(), CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Преобразовать из даты или нуля в строку.
        /// </summary>
        /// <param name="value">Дата или нуль.</param>
        /// <param name="resource">Ресурс.</param>
        /// <returns>Строковое представления даты или нуля.</returns>
        public static string ConvertFromDateNullableToString(this DateTime? value, IConvertingResource resource)
        {
            return value.HasValue ? value.Value.ConvertFromDateToString(resource) : string.Empty;
        }

        /// <summary>
        /// Преобразовать в дату или нуль.
        /// </summary>
        /// <param name="value">Строковое представление даты или нуля.</param>
        /// <param name="resource">Ресурсы преобразования основы ядра.</param>
        /// <returns>Дата или нуль.</returns>
        public static DateTime? ConvertToDateNullable(this string value, IConvertingResource resource)
        {
            return string.IsNullOrWhiteSpace(value) ? null : new DateTime?(value.ConvertToDate(resource));
        }

        /// <summary>
        /// Преобразовать в десятичную дробь.
        /// </summary>
        /// <param name="value">Строка.</param>
        /// <returns>Десятичная дробь.</returns>
        public static decimal ConvertToNumericDecimal(this string value)
        {
            return decimal.Parse(
                value.Trim(),
                NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign,
                CultureInfo.InvariantCulture
                );
        }

        /// <summary>
        /// Преобразовать в десятичную дробь или нуль.
        /// </summary>
        /// <param name="value">Строка.</param>
        /// <returns>Десятичная дробь или нуль.</returns>
        public static decimal? ConvertToNumericDecimalNullable(this string value)
        {
            return string.IsNullOrWhiteSpace(value) ? null : value.ConvertToNumericDecimal();
        }

        /// <summary>
        /// Преобразовать в 32-х разрядное целое число.
        /// </summary>
        /// <param name="value">Строка.</param>
        /// <returns>Целое число.</returns>
        public static int ConvertToNumericInt32(this string value)
        {
            return int.Parse(value.Trim(), CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Преобразовать в 32-х разрядное целое число или NULL.
        /// </summary>
        /// <param name="value">Строка.</param>
        /// <returns>Целое число или NULL.</returns>
        public static int? ConvertToNumericInt32Nullable(this string value)
        {
            return string.IsNullOrWhiteSpace(value) ? null : value.ConvertToNumericInt32();
        }

        /// <summary>
        /// Преобразовать в 64-х разрядное целое число.
        /// </summary>
        /// <param name="value">Строка.</param>
        /// <returns>Целое число.</returns>
        public static long ConvertToNumericInt64(this string value)
        {
            return long.Parse(value.Trim(), CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Преобразовать в 64-х разрядное целое число или NULL.
        /// </summary>
        /// <param name="value">Строка.</param>
        /// <returns>Целое число или NULL.</returns>
        public static long? ConvertToNumericInt64Nullable(this string value)
        {
            return string.IsNullOrWhiteSpace(value) ? null : value.ConvertToNumericInt64();
        }

        /// <summary>
        /// Преобразовать в массив 64-битных целых чисел.
        /// </summary>
        /// <param name="value">Строка.</param>
        /// <returns>Массив 64-битных целых чисел.</returns>
        public static long[] ConvertToNumericInt64Array(this string value)
        {
            return value.ConvertToNumericArray(x => long.Parse(x));
        }

        #endregion Public methods

        #region Private methods

        private static T[] ConvertToNumericArray<T>(this string str, Func<string, T> funcParse)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return new T[0];
            }
            else
            {
                return Regex.Replace(str, @"[^\d\+\-]", " ").Split(' ')
                    .Where(x => !string.IsNullOrWhiteSpace(x))
                    .Select(x => funcParse.Invoke(x))
                    .ToArray();
            }
        }

        #endregion Private methods
    }
}
