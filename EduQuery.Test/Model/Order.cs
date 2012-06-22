using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EduQuery.Model
{
    public class Order
    {
        public int Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CustomerName { get; set; }

        public override string ToString()
        {
            return string.Format("{0:00} [{1:yyyyMMdd}] {2}", Id, CreatedDate, CustomerName);
        }
    }
}
