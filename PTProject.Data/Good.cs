﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTProject.Data
{
    public class Good
    {
        public int GoodId { get; set; }
        public string? Description { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
       
    }
}