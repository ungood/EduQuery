using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using EduQuery.Query;
using EduQuery.Test.Model;
using NUnit.Framework;

namespace EduQuery.Test.Query
{
    [TestFixture]
    public class EmptyTests
    {
        [Test]
        public void SimpleSelectAllQuery()
        {
            using(var connection = new SQLiteConnection("Data Source=testdb.db;Version=3;Read Only=True;"))
            {
                connection.Open();

                var dialect = new Dialect.SQLiteDialect();
                var runner = new QueryRunner(connection, dialect);

                var query = new SqlQuery<Order>();

                var results = runner.ExecuteReader(query).ToList();

                Assert.AreEqual(10, results.Count);
                results.Select(order => order.Id).AssertSeqeuenceEquals(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);
            }
        }
    }
}
