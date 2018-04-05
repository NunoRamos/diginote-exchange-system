using Common;
using Common.Interfaces;
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
        public static FormManager FormManager { get; private set; }
        public static Client StateManager { get; private set; }

        public float? CurrentQuote { get; set; }

        public string Token { get; set; }

        public IServer Server { get; }

        public EventRepeater EvntRepeater = new EventRepeater();

        public Client()
        {
            Server = ConnectToServer();
            Server.QuoteUpdated += EvntRepeater.FireQuoteUpdated;
            EvntRepeater.QuoteUpdated += OnQuoteUpdated;
            OnQuoteUpdated(Server.GetCurrentQuote());
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
            StateManager = new Client();
            FormManager = new FormManager();
            Application.Run(FormManager.AuthenticationForm);
        }


        private static IServer ConnectToServer()
        {
            RemotingConfiguration.Configure("diginote-exchange-system.exe.config", false);
            var iServer = (IServer)Activator.GetObject(typeof(IServer), "tcp://localhost:9000/Server/Server");

            Console.WriteLine("Connection successfully established!");

            return iServer;
        }

        public Tuple<Exception, OrderNotSatisfiedException> CreateSellOrder(int quantity, float value)
        {
            return Server.CreateSellOrder(Token, quantity, value);
        }
    }
}
