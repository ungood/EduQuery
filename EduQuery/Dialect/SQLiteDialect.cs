using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using EduQuery.Query;

namespace EduQuery.Dialect
{
    /// <summary>
    /// This class is responsible for creating SQL from a QueryInfo object
    /// </summary>
    public class SQLiteDialect : IDialect
    {
        public void ConfigureCommand<TOut>(IDbCommand command, SqlQuery<TOut> sqlQuery)
        {
            var outType = typeof(TOut);

            var tableName = GetTableName(outType);

            var columnNames = outType.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Select(GetColumnName)
                .ToArray();

            command.CommandText = string.Format("SELECT {0} FROM {1}",
                string.Join(", ", columnNames),
                tableName);
        }
        
        private static string GetTableName(Type type)
        {
            return EscapeIdentifier(type.Name);
        }

        private static string GetColumnName(MemberInfo mi)
        {
            return EscapeIdentifier(mi.Name);
        }

        private static string EscapeIdentifier(string identifer)
        {
            return "[" + identifer + "]";
        }
    }
}
