﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Serializable
{
    [Serializable]
    public class Transaction
    {
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public float Quote { get; set; }

        public SellOrder SellOrder { get; set; }

        public PurchaseOrder PurchaseOrder { get; set; }
    }
}
