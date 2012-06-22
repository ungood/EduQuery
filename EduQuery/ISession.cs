using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EduQuery
{
    public interface ISession : IDisposable
    {
        IQueryable<T> CreateQuery<T>();
    }
}
