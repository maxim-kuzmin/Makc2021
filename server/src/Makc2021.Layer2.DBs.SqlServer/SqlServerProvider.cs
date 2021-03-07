﻿//Author Maxim Kuzmin//makc//

using Makc2021.Layer2.DBs.SqlServer.Filestream;
using Makc2021.Layer2.DBs.SqlServer.Queries.Identity.Reseed;
using Makc2021.Layer2.DBs.SqlServer.Queries.Tree.Calculate;
using Makc2021.Layer2.DBs.SqlServer.Queries.Tree.Trigger;
using Makc2021.Layer2.Queries.Identity.Reseed;
using Makc2021.Layer2.Queries.Tree.Calculate;
using Makc2021.Layer2.Queries.Tree.Trigger;
using Microsoft.Win32.SafeHandles;
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Runtime.InteropServices;

namespace Makc2021.Layer2.DBs.SqlServer
{
    /// <summary>
    /// База данных "Microsoft SQL Server". Поставщик.
    /// </summary>
    public class SqlServerProvider : IProvider
    {
        #region Public methods

        /// <inheritdoc/>
        public DbParameter CreateDbParameter(string name, object value)
        {
            return new SqlParameter(name, value);
        }

        /// <inheritdoc/>
        public DbCommand CreateDbCommand(DbConnection connection, DbParameter[] parameters)
        {
            SqlCommand result = null;

            if (!(connection is SqlConnection cn)) return result;

            result = cn.CreateCommand();

            if (parameters == null) return result;

            foreach (var parameter in parameters)
            {
                var par = result.CreateParameter();

                var name = parameter.ParameterName;

                if (!string.IsNullOrEmpty(name))
                {
                    if (!name.StartsWith("@"))
                    {
                        name = "@" + name;
                    }

                    par.ParameterName = name;
                }

                par.Direction = parameter.Direction;

                if (parameter.Value is DataTable val)
                {
                    par.SqlDbType = SqlDbType.Structured;
                    par.TypeName = val.TableName;
                    par.SqlValue = val;

                }
                else
                {
                    par.Value = parameter.Value;
                    par.DbType = parameter.DbType;
                }

                result.Parameters.Add(par);
            }

            return result;
        }

        /// <inheritdoc/>   
        public DbConnection CreateDbConnection(string connectionString, Func<string, string> transformConnectionString = null)
        {
            if (transformConnectionString != null)
            {
                connectionString = transformConnectionString(connectionString);
            }

            return new SqlConnection(connectionString);
        }

        /// <inheritdoc/>
        public IdentityReseedQueryBuilder CreateQueryIdentityReseedBuilder()
        {
            return new SqlServerIdentityReseedQueryBuilder();
        }

        /// <inheritdoc/>
        public TreeCalculateQueryBuilder CreateQueryTreeCalculateBuilder()
        {
            return new SqlServerTreeCalculateQueryBuilder();
        }

        /// <inheritdoc/>
        public TreeTriggerQueryBuilder CreateQueryTreeTriggerBuilder()
        {
            return new SqlServerTreeTriggerQueryBuilder();
        }

        /// <summary>
        /// Получить указатель на файловый поток базы данных SQL Server.
        /// </summary>
        /// <param name="filePath">Путь к файлу.</param>
        /// <param name="access">Уровень доступа.</param>
        /// <param name="txnToken">Токен контекста транзакции.</param>
        /// <returns>Указатель на файловый поток базы данных SQL Server.</returns>
        public static SafeFileHandle GetSqlFilestreamHandle(
            string filePath,
            SqlServerFilestreamAccess access,
            byte[] txnToken
            )
        {
            return OpenSqlFilestream(
                filePath,
                (uint)access,
                0,
                txnToken,
                (uint)txnToken.Length,
                new Sql64(0)
                );
        }

        #endregion Public methods

        #region Private methods

        [DllImport("sqlncli10.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        private static extern SafeFileHandle OpenSqlFilestream(
            string path,
            uint access,
            uint options,
            byte[] txnToken,
            uint txnTokenLength,
            Sql64 allocationSize
            );

        [StructLayout(LayoutKind.Sequential)]
        private struct Sql64
        {
            public long QuadPart;

            public Sql64(long quadPart)
            {
                QuadPart = quadPart;
            }
        }

        #endregion Private methods
    }
}