using System;

namespace Common.Interfaces
{
    public abstract class IServer : MarshalByRefObject
    {
        public event EventHandler<float?> OnQuoteUpdated;

        public abstract Tuple<string, Exception> Login(string nickname, string password);

        public abstract Tuple<string, Exception> Register(string name, string nickname, string password);

        public abstract Exception Logout(string token);

        public abstract Tuple<Exception, OrderNotSatisfiedException> CreateSellOrder(string token, int quantity, float value);

        public abstract float? GetCurrentQuote();
    }
}
