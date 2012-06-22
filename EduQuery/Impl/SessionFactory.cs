using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EduQuery
{
    public class SessionFactory
    {
        public string Filename { get; set; }

        public SessionFactory(string filename)
        {
            Filename = filename;
        }

        public Session OpenSession()
        {
            throw NotImplementedException();
        }
    }
}
