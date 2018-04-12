using Common;
using Common.Interfaces;
using Common.Serializable;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections;
using System.IO;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;

namespace diginote_exchange_system
{
    public class Client
    {
        public static FormManager Forms { get; private set; }
        public static Client State { get; private set; }
        public float CurrentQuote { get; set; }

        private string Token;

        private IServer Server;

        private readonly IModel channel;

        public event EventHandler<float> QuoteUpdated;
        public event EventHandler<SellOrder[]> SellOrdersUpdated;
        public event EventHandler<PurchaseOrder[]> PurchaseOrdersUpdated;
        public event EventHandler<Transaction[]> TransactionsUpdated;
        public event EventHandler<int> AvailableDiginotesUpdated;

        public Client()
        {
            Server = ConnectToServer();
            var factory = new ConnectionFactory() { HostName = "localhost" };
            var connection = factory.CreateConnection();
            channel = connection.CreateModel();

            SetupEventRepeater();
        }

        private void SetupEventRepeater()
        {
            CreateQueue("CurrentQuote", (model, args) =>
                {
                    QuoteUpdated.Invoke(this, (float)Deserialize(args));
                    CurrentQuote = (float)Deserialize(args);
                }
            );
        }

        private void CreateQueue(string name, EventHandler<BasicDeliverEventArgs> onReceive)
        {
            channel.QueueBind(queue: name,
                                exchange: "diginotes",
                                routingKey: name);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += onReceive;

            channel.BasicConsume(queue: name,
                                 autoAck: true,
                                 consumer: consumer);
        }

        private object Deserialize(BasicDeliverEventArgs args)
        {
            IFormatter formatter = new BinaryFormatter();
            MemoryStream memoryStream = new MemoryStream(args.Body);
            return formatter.Deserialize(memoryStream);
        }

        private void SetupLoggedInEvents()
        {
            string diginotesChannelName = "Diginotes" + Token;
            string purchaseOrdersChannelName = "PurchaseOrders" + Token;
            string sellOrdersChannelName = "SellOrders" + Token;
            string transactionsChannelName = "Transactions" + Token;

            CreateQueue(diginotesChannelName, (model, args) =>
                AvailableDiginotesUpdated.Invoke(this, (int)Deserialize(args))
           );

            CreateQueue(purchaseOrdersChannelName, (model, args) =>
                PurchaseOrdersUpdated.Invoke(this, (PurchaseOrder[])Deserialize(args))
           );

            CreateQueue(sellOrdersChannelName, (model, args) =>
                SellOrdersUpdated.Invoke(this, (SellOrder[])Deserialize(args))
           );

            CreateQueue(transactionsChannelName, (model, args) =>
                TransactionsUpdated.Invoke(this, (Transaction[])Deserialize(args))
           );
        }

        internal Exception Login(string nickname, string password)
        {
            Tuple<string, Exception> result = Server.Login(nickname, password);

            if (result.Item2 == null)
                Token = result.Item1;

            SetupLoggedInEvents();

            return result.Item2;
        }

        internal void SignOut()
        {
            Server.Logout(Token);
        }

        internal Exception Register(string name, string nickname, string password)
        {
            Tuple<string, Exception> result = Server.Register(name, nickname, password);

            if (result.Item2 == null)
                Token = result.Item1;

            return result.Item2;
        }

        internal object GetAvailableDiginotes()
        {
            int diginotes = Server.GetAvailableDiginotes(Token);
            AvailableDiginotesUpdated.Invoke(this, diginotes);
            return diginotes;
        }

        internal float GetCurrentQuote()
        {
            return Server.GetCurrentQuote();
        }

        internal Exception ConfirmPurchaseOrder(int diginotesLeft, float value)
        {
            return Server.ConfirmPurchaseOrder(Token, diginotesLeft, value);
        }

        internal Exception ConfirmSellOrder(int diginotesLeft, float value)
        {
            return Server.ConfirmSellOrder(Token, diginotesLeft, value);
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

        public SellOrder[] GetUserIncompleteSellOrders()
        {
            SellOrder[] updatedSellOrders = Server.GetUserIncompleteSellOrders(Token);
            SellOrdersUpdated.Invoke(this, updatedSellOrders);
            return updatedSellOrders;
        }
        public PurchaseOrder[] GetUserIncompletePurchaseOrders()
        {
            PurchaseOrder[] updatedPurchaseOrders = Server.GetUserIncompletePurchaseOrders(Token);
            PurchaseOrdersUpdated.Invoke(this, updatedPurchaseOrders);
            return updatedPurchaseOrders;
        }

        internal Transaction[] GetTransactions()
        {
            return Server.GetUserTransactions(Token);
        }
    }
}
