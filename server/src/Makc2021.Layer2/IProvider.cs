// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2021.Layer2.Queries.Identity.Reseed;
using Makc2021.Layer2.Queries.Tree.Calculate;
using Makc2021.Layer2.Queries.Tree.Trigger;
using System;
using System.Data.Common;

namespace Makc2021.Layer2
{
    /// <summary>
    /// Интерфейс поставщика.
    /// </summary>
    public interface IProvider
    {
        /// <summary>
        /// Создать параметр команды базы данных.
        /// </summary>
        /// <param name="name">Имя параметра.</param>
        /// <param name="value">Значение параметра.</param>
        /// <returns>Параметр команды базы данных.</returns>
        DbParameter CreateDbParameter(string name, object value);

        /// <summary>
        /// Создать команду базы данных.
        /// </summary>
        /// <param name="connection">Подключение к базе данных.</param>
        /// <param name="parameters">Параметры команды.</param>
        /// <returns>Команда базы данных.</returns>
        DbCommand CreateDbCommand(DbConnection connection, DbParameter[] parameters);

        /// <summary>
        /// Создать подключение к базе данных.
        /// </summary>
        /// <param name="connectionString">Строка подключения к базе данных.</param>
        /// <param name="transformConnectionString">Функция преобразования строки подключения.</param>
        /// <returns>Подключение к базе данных.</returns>        
        DbConnection CreateDbConnection(string connectionString, Func<string, string> transformConnectionString = null);

        /// <summary>
        /// Создать построитель запроса перезаполнения идентичности.
        /// </summary>
        /// <returns>Построитель запроса.</returns>
        IdentityReseedQueryBuilder CreateQueryIdentityReseedBuilder();

        /// <summary>
        /// Создать построитель запроса вычисления дерева.
        /// </summary>
        /// <returns>Построитель запроса.</returns>
        TreeCalculateQueryBuilder CreateQueryTreeCalculateBuilder();

        /// <summary>
        /// Создать построитель запроса триггера дерева.
        /// </summary>
        /// <returns>Построитель запроса.</returns>
        TreeTriggerQueryBuilder CreateQueryTreeTriggerBuilder();
    }
}
