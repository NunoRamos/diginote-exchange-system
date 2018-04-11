using Common.Serializable;
using System;
using System.Collections.Generic;

namespace Common.Interfaces
{
    [Serializable]
    public delegate void QuoteUpdated(float newQuote);

    [Serializable]
    public delegate void UserDiginotesUpdated(int diginotes);

    [Serializable]
    public delegate void UserPurchaseOrdersUpdated(Order[] orders);

    [Serializable]
    public delegate void UserSellOrdersUpdated(Order[] orders);

    [Serializable]
    public delegate void UserTransactionsUpdated(Transaction[] transactions);

    public interface IServer
    {
        event QuoteUpdated QuoteUpdated;

        Tuple<string, Exception> Login(string nickname, string password);

        Tuple<string, Exception> Register(string name, string nickname, string password);

        Exception Logout(string token);

        Tuple<Exception, OrderNotSatisfiedException> CreateSellOrder(string token, int quantity);

        Tuple<Exception, OrderNotSatisfiedException> CreatePurchaseOrder(string token, int quantity);

        float GetCurrentQuote();

        int GetAvailableDiginotes(string token);
        Exception ConfirmPurchaseOrder(string token, int diginotesLeft, float value);

        Exception ConfirmSellOrder(string token, int diginotesLeft, float value);
        Order[] GetUserIncompleteOrders(string token, OrderType type);
        Transaction[] GetUserTransactions(string token);

        bool SubscribeUserDiginotesUpdated(string token, UserDiginotesUpdated userDiginotesUpdated);
        bool SubscribeUserPurchaseOrdersUpdated(string token, UserPurchaseOrdersUpdated userPurchaseOrdersUpdated);
        bool SubscribeUserSellOrdersUpdated(string token, UserSellOrdersUpdated userSellOrdersUpdated);
        bool SubscribeUserTransactionsUpdated(string token, UserTransactionsUpdated userTransactionsUpdated);
    }

    [Serializable]
    public class EventRepeater : MarshalByRefObject
    {
        public event QuoteUpdated QuoteUpdated;

        public event UserDiginotesUpdated DiginotesUpdated;
        public event UserPurchaseOrdersUpdated PurchaseOrdersUpdated;
        public event UserSellOrdersUpdated SellOrdersUpdated;
        public event UserTransactionsUpdated TransactionsUpdated;

        public void FireQuoteUpdated(float newQuote)
        {
            QuoteUpdated(newQuote);
        }

        public void FireDiginotesUpdated(int diginotes)
        {
            DiginotesUpdated(diginotes);
        }

        public void FirePurchaseOrdersUpdated(Order[] orders)
        {
            PurchaseOrdersUpdated(orders);
        }

        public void FireSellOrdersUpdated(Order[] orders)
        {
            SellOrdersUpdated(orders);
        }

        public void FireTransactionsUpdated(Transaction[] transactions)
        {
            TransactionsUpdated(transactions);
        }

        public void SubscribeDiginotesUpdated(IServer server, string token)
        {
            //server.SubscribeUserDiginotesUpdated(token, FireDiginotesUpdated);
            server.SubscribeUserDiginotesUpdated(token, (e => { Console.WriteLine("Goods"); }));
        }

        public void SubscribePurchaseOrdersUpdated(IServer server, string token)
        {
            //server.SubscribeUserPurchaseOrdersUpdated(token, FirePurchaseOrdersUpdated);
            server.SubscribeUserPurchaseOrdersUpdated(token, (e => { Console.WriteLine("Goods"); }));
        }

        public void SubscribeSellOrdersUpdated(IServer server, string token)
        {
            //server.SubscribeUserSellOrdersUpdated(token, FireSellOrdersUpdated);
            server.SubscribeUserSellOrdersUpdated(token, (e => { Console.WriteLine("Goods"); }));
        }

        public void SubscribeTransactionsUpdated(IServer server, string token)
        {
            //server.SubscribeUserTransactionsUpdated(token, FireTransactionsUpdated);
            server.SubscribeUserTransactionsUpdated(token, (e => { Console.WriteLine("Goods"); }));
        }
    }
}
