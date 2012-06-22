﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EduQuery.Model
{
    public class Product
    {
        public string Sku { get; set; }

        public string Description { get; set; }

        public override string ToString()
        {
            return string.Format("{0} - {1}", Sku, Description);
        }
    }
}
