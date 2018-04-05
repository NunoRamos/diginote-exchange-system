using Common;
using Common.Interfaces;
using System;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Windows.Forms;

namespace diginote_exchange_system
{
    public class Client : IClient
    {
        public static FormManager FormManager { get; private set; } 
        public static Client StateManager { get; private set; }

        public float CurrentQuote { get; set; } = 0.01f;

        public string Token { get; set; }

        public IServer Server { get; }

        public Client()
        {
            Server = ConnectToServer();
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            FormManager = new FormManager();
            StateManager = new Client();
            Application.Run(FormManager.AuthenticationForm);
        }


        private static IServer ConnectToServer()
        {
            string SERVER_ADDR = "tcp://localhost:8085/Diginote-Server/Server";
            TcpChannel chan = new TcpChannel(8086);
            ChannelServices.RegisterChannel(chan, false);

            IServer serverObj;

            serverObj = (IServer)Activator.GetObject(typeof(IServer), SERVER_ADDR);

            if (serverObj == null)
            {
                throw new Exception("Could not locate server on: \"" + SERVER_ADDR + "\"");
            }

            Console.WriteLine("Connection successfully established!");

            return serverObj;
        }

        public override void UpdateQuote(float newValue)
        {
            CurrentQuote = newValue;
        }

        public Tuple<Exception, OrderNotSatisfiedException> CreateSellOrder(int quantity, float value)
        {
            return Server.CreateSellOrder(Token, quantity, value);
        }
    }
}
