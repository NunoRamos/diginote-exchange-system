using System;

namespace Common.Interfaces
{
    [Serializable]
    public delegate void QuoteUpdated(float newQuote);

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

        Serializable.SellOrder[] GetUserIncompleteSellOrders(string token);
    
        Serializable.PurchaseOrder[] GetUserIncompletePurchaseOrders(string token);

        Serializable.Transaction[] GetUserTransactions(string token);
    }
    
    [Serializable]
    public class EventRepeater: MarshalByRefObject
    {
        public event QuoteUpdated QuoteUpdated;

        public void FireQuoteUpdated(float newQuote)
        {
            QuoteUpdated(newQuote);
        }
    }
}
