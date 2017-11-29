﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PW.Ncels.Database.Models.EMP
{
    public class PriceListModelView
    {
        public Guid Id { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public decimal TotalPrice { get; set; }
        public string ServiceTypeNameRu { get; set; }
        public string ServiceTypeNameKz { get; set; }
    }
}
