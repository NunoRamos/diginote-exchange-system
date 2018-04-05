using System;

namespace Common.Interfaces
{
    public delegate void QuoteUpdated(float? newQuote);

    public interface IServer
    {
        event QuoteUpdated QuoteUpdated;

        Tuple<string, Exception> Login(string nickname, string password);

        Tuple<string, Exception> Register(string name, string nickname, string password);

        Exception Logout(string token);

        Tuple<Exception, OrderNotSatisfiedException> CreateSellOrder(string token, int quantity, float value);

        float? GetCurrentQuote();
    }
    
    public class EventRepeater: MarshalByRefObject
    {
        public event QuoteUpdated QuoteUpdated;

        public void FireQuoteUpdated(float? newQuote)
        {
            QuoteUpdated(newQuote);
        }
    }
}
