using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
                    throw new NotImplementedException();
                }
            }
        }
    }
}
