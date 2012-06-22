using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EduQuery.Test
{
    public interface ISessionThingy
    {
        void Setup();

    }

    public abstract class TestBase<T>
        where T : ISessionThingy
    {


        protected TestBase()
        {
            
        }
    }
}
