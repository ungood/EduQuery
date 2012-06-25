using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using EduQuery.Dialect;

namespace EduQuery.Query
{
    /// <summary>
    /// Responsible for executing a SqlQuery and returning typed objects.
    /// </summary>
    public class QueryRunner
    {
        private readonly IDbConnection connection;
        private readonly IDialect dialect;

        public QueryRunner(IDbConnection connection, IDialect dialect)
        {
            this.connection = connection;
            this.dialect = dialect;
        }

        public IEnumerable<T> ExecuteReader<T>(SqlQuery<T> sqlQuery)
        {
            if(connection.State != ConnectionState.Open)
                throw new InvalidOperationException("Connection is not open!");

            using(var command = connection.CreateCommand())
            {
                dialect.ConfigureCommand(command, sqlQuery);
                Console.WriteLine(command.CommandText);

                using(var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                        yield return Deserialize<T>(reader);
                }
            }
        }

        private static T Deserialize<T>(IDataRecord reader)
        {
            var instance = Activator.CreateInstance<T>();

            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .ToDictionary(pi => pi.Name);

            for (int i = 0; i < reader.FieldCount; i++)
            {
                var columnName = reader.GetName(i);
                if (!properties.ContainsKey(columnName))
                    throw new Exception(string.Format("Could not map columnt '{0}' to type '{1}'", columnName, typeof(T).Name));

                var pi = properties[columnName];
                var converted = Convert.ChangeType(reader.GetValue(i), pi.PropertyType);

                pi.SetValue(instance, converted, null);
            }

            return instance;
        }
    }
}
