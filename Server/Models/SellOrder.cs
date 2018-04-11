using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Serializable;

namespace Server.Models
{
    public class SellOrder: Order
    {
        public virtual Diginote Diginote { get; set; }

        public Common.Serializable.SellOrder Serialize()
        {
            return new Common.Serializable.SellOrder
            {
                CreatedAt = CreatedAt,
                CreatedById = CreatedById,
                Id = Id,
                Quote = Quote,
                Status = Status,
                DiginoteId = Diginote.Id
            };
        }
    }
}
