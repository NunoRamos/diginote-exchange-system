using Common.Interfaces;
using Common.Serializable;
using System;

namespace Common
{
    public class Session
    {
        public int Id { get; }

        public event UserDiginotesUpdated UserDiginotesUpdated;
        public event UserPurchaseOrdersUpdated UserPurchaseOrdersUpdated;
        public event UserSellOrdersUpdated UserSellOrdersUpdated;
        public event UserTransactionsUpdated UserTransactionsUpdated;

        public Session(int id)
        {
            Id = id;
            UserDiginotesUpdated += e => { Console.Write("Boas"); };
            UserPurchaseOrdersUpdated += e => { Console.Write("Boas"); };
            UserSellOrdersUpdated += e => { Console.Write("Boas"); };
            UserTransactionsUpdated += e => { Console.Write("Boas"); };
        }

        public void UpdateDiginotes(int diginotes)
        {
            UserDiginotesUpdated(diginotes);
        }

        public void UpdatePurchaseOrders(Order[] orders)
        {
            UserPurchaseOrdersUpdated(orders);
        }

        public void UpdateSellOrders(Order[] orders)
        {
            UserSellOrdersUpdated(orders);
        }

        public void UpdateTransactionsUpdated(Transaction[] transactions)
        {
            UserTransactionsUpdated(transactions);
        }
    }
}
