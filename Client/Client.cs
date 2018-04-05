using Common;
using Common.Interfaces;
using System;
using System.Collections;
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
            BinaryServerFormatterSinkProvider provider = new BinaryServerFormatterSinkProvider();
            provider.TypeFilterLevel = TypeFilterLevel.Full;
            IDictionary props = new Hashtable();
            int port = 8086;
            props["port"] = port;

            TcpChannel chan = new TcpChannel(props, null, provider);
            // TcpChannel chan = new TcpChannel(8086);
            ChannelServices.RegisterChannel(chan, false);

            string SERVER_ADDR = "tcp://localhost:8085/Diginote-Server/Server";

            IServer serverObj;

            serverObj = (IServer)Activator.GetObject(typeof(IServer), SERVER_ADDR);

            if (serverObj == null)
            {
                throw new Exception("Could not locate server on: \"" + SERVER_ADDR + "\"");
            }

            Console.WriteLine("Connection successfully established!");

            return serverObj;
        }

        public Tuple<Exception, OrderNotSatisfiedException> CreateSellOrder(int quantity, float value)
        {
            return Server.CreateSellOrder(Token, quantity, value);
        }
    }
}
