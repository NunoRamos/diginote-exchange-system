using Common;
using Common.Interfaces;
using Common.Serializable;
using System;
using System.Collections;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Serialization.Formatters;
using System.Windows.Forms;

namespace diginote_exchange_system
{
    public class Client
    {
        public static FormManager Forms { get; private set; }
        public static Client State { get; private set; }

        public float? CurrentQuote { get; set; }

        public string Token { get; set; }

        public IServer Server { get; }

        public EventRepeater EvntRepeater = new EventRepeater();

        public event EventHandler<Order[]> SellOrdersUpdated;
        public event EventHandler<Order[]> PurchaseOrdersUpdated;
        public event EventHandler<int> AvailableDiginotesUpdated;

        public Client()
        {
            Server = ConnectToServer();
            Server.QuoteUpdated += EvntRepeater.FireQuoteUpdated;
            EvntRepeater.QuoteUpdated += OnQuoteUpdated;
            OnQuoteUpdated(Server.GetCurrentQuote());
        }

        internal void SignOut()
        {
            Server.Logout(Token);
        }

        private void OnQuoteUpdated(float? newQuote)
        {
            CurrentQuote = newQuote;
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            State = new Client();
            Forms = new FormManager();
            Application.Run(Forms.AuthenticationForm);
        }


        private static IServer ConnectToServer()
        {
            RemotingConfiguration.Configure("diginote-exchange-system.exe.config", false);
            var iServer = (IServer)Activator.GetObject(typeof(IServer), "tcp://localhost:9000/Server/Server");

            Console.WriteLine("Connection successfully established!");

            return iServer;
        }

        public Tuple<Exception, OrderNotSatisfiedException> CreateSellOrder(int quantity)
        {
            return Server.CreateSellOrder(Token, quantity);
        }

        internal Tuple<Exception, OrderNotSatisfiedException> CreatePurchaseOrder(int quantity)
        {
            return Server.CreatePurchaseOrder(Token, quantity);
        }

        public Order[] GetUserSellOrders()
        {
            Order[] updatedSellOrders = Server.GetUserOrders(Token, OrderType.Sell);
            SellOrdersUpdated.Invoke(this, updatedSellOrders);
            return updatedSellOrders;
        }
        public Order[] GetUserPurchaseOrders()
        {
            Order[] updatedPurchaseOrders = Server.GetUserOrders(Token, OrderType.Purchase);
            PurchaseOrdersUpdated.Invoke(this, updatedPurchaseOrders);
            return updatedPurchaseOrders;
        }
    }
}
