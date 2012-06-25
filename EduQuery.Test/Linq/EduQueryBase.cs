using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using NUnit.Framework;

namespace EduQuery.Test
{
    public abstract class EduQueryBase
    {
        private IDbConnection CreateConnection()
        {
            return new SQLiteConnection("Data Source=testdb.db;Version=3;Read Only=True;");
        }

        //private SimpleSession session;

        [SetUp]
        public void Setup()
        {
            //session = new SimpleSession(CreateConnection);
        }

        protected IQueryable<T> Query<T>()
        {
            return null;// return session.Query<T>();
        }

        [TearDown]
        public void Teardown()
        {
            //if(session != null)
            //{
            //    session.Dispose();
            //    session = null;
            //}
        }
    }
}
