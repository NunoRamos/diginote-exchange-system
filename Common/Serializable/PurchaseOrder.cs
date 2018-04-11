using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Serializable
{
    [Serializable]
    public class PurchaseOrder
    {
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public float Quote { get; set; }

        public OrderStatus Status { get; set; }

        public int CreatedById { get; set; }
    }
}
