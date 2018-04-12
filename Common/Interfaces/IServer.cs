﻿using Common.Serializable;
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

        SellOrder[] GetUserIncompleteSellOrders(string token);

        PurchaseOrder[] GetUserIncompletePurchaseOrders(string token);

        Transaction[] GetUserTransactions(string token);

        String DeleteSellOrders(int[] ordersId);

        String DeletePurchaseOrders(int[] ordersId);

        String UpdatePurchaseOrders(PurchaseOrder[] UpdatePurchaseOrders);

        String UpdateSellOrders(SellOrder[] UpdateSellOrders);
    }

    [Serializable]
    public class EventRepeater : MarshalByRefObject
    {
        public event QuoteUpdated QuoteUpdated;

        public void FireQuoteUpdated(float newQuote)
        {
            QuoteUpdated(newQuote);
        }
    }
}
