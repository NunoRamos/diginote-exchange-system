using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Models
{
    public class PurchaseOrder: Order
    {
        public Common.Serializable.PurchaseOrder Serialize()
        {
            return new Common.Serializable.PurchaseOrder
            {
                CreatedAt = CreatedAt,
                CreatedById = CreatedById,
                Id = Id,
                Quote = Quote,
                Status = Status
            };
        }
    }
}
