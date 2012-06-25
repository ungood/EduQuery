using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;

namespace EduQuery.Linq
{
    internal class Queryable<T> : IQueryable<T>
    {
        internal Queryable(IDbConnection connection)
        {
            
        }

        public IQueryProvider Provider
        {
            get { throw new NotImplementedException(); }
        }

        public Expression Expression
        {
            get { throw new NotImplementedException(); }
        }

        public Type ElementType
        {
            get { return typeof(T); }
        }

        public IEnumerator<T> GetEnumerator()
        {
            var enumerable = Provider.Execute<IEnumerable<T>>(Expression);
            return enumerable.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            var enumerable = Provider.Execute<IEnumerable>(Expression);
            return enumerable.GetEnumerator();
        }
    }
}
