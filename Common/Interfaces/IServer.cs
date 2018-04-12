using Common.Serializable;
using System;
using System.Collections.Generic;

namespace Common.Interfaces
{
    public interface IServer
    {
        Tuple<string, Exception> Login(string nickname, string password);

        Tuple<string, Exception> Register(string name, string nickname, string password);

        Exception Logout(string token);

        Tuple<Exception, OrderNotSatisfiedException> CreateSellOrder(string token, int quantity);

        Tuple<Exception, OrderNotSatisfiedException> CreatePurchaseOrder(string token, int quantity);

        float GetCurrentQuote();

        int GetAvailableDiginotes(string token);
        Exception ConfirmPurchaseOrder(string token, int diginotesLeft, float value);

        Exception ConfirmSellOrder(string token, int diginotesLeft, float value);

        SellOrder[] GetUserIncompleteSellOrders(string token);

        PurchaseOrder[] GetUserIncompletePurchaseOrders(string token);

        Transaction[] GetUserTransactions(string token);

        String DeleteSellOrders(int[] ordersId);

        String DeletePurchaseOrders(int[] ordersId);
    }
}
