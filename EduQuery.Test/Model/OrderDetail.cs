using System;
using System.Collections.Generic;
using System.Linq;

namespace EduQuery.Model
{
    public class OrderDetail
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public string Sku { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public override string ToString()
        {
            return string.Format("{0:00}:{1:0000} {2} {3}x{4:C2}",
                OrderId,
                Id,
                Sku,
                Quantity,
                Price);
        }
    }
}
