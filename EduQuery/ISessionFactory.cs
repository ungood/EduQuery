using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EduQuery
{
    public interface ISessionFactory
    {
        string ConnectionString { get; }

        ISession OpenSession();
    }
}
