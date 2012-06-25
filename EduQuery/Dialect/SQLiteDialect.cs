using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
            throw new NotImplementedException();
        }
    }
}
