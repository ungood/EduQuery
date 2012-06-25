using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using EduQuery.Query;

namespace EduQuery.Dialect
{
    /// <summary>
    /// Responsible for generating SQL for a QueryInfo.  One dialect for each DB type we support.
    /// </summary>
    public interface IDialect
    {
        void ConfigureCommand<T>(IDbCommand command, SqlQuery<T> sqlQuery);
    }
}
