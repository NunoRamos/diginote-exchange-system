using Common.Serializable;
using RabbitMQ.Client;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Common
{
    public class Session
    {
        private const string DiginotesExchangeName = "Diginotes";
        private const string PurchaseOrdersExchangeName = "PurchaseOrders";
        private const string SellOrdersExchangeName = "SellOrders";
        private const string TransactionsExchangeName = "Transactions";
        private IModel channel;
        public string Token { get; }
        public int Id { get; }

        public Session(IModel channel, string token, int id)
        {
            this.channel = channel;
            Token = token;
            Id = id;

            CreateExchange(DiginotesExchangeName);
            CreateExchange(PurchaseOrdersExchangeName);
            CreateExchange(SellOrdersExchangeName);
            CreateExchange(TransactionsExchangeName);
        }

        private void CreateExchange(string exchangeName)
        {
            channel.ExchangeDeclare(
                exchange: exchangeName,
                type: "direct",
                durable: false,
                autoDelete: true
                );
        }

        public void UpdateDiginotes(int diginotes)
        {
            IFormatter formatter = new BinaryFormatter();
            MemoryStream memoryStream = new MemoryStream();
            formatter.Serialize(memoryStream, diginotes);

            var body = memoryStream.ToArray();

            channel.BasicPublish(
                exchange: DiginotesExchangeName,
                routingKey: Token,
                basicProperties: null,
                body: body
                );
        }

        public void UpdatePurchaseOrders(PurchaseOrder[] orders)
        {
            IFormatter formatter = new BinaryFormatter();
            MemoryStream memoryStream = new MemoryStream();
            formatter.Serialize(memoryStream, orders);

            var body = memoryStream.ToArray();

            channel.BasicPublish(
                exchange: PurchaseOrdersExchangeName,
                routingKey: Token,
                basicProperties: null,
                body: body
                );
        }

        public void UpdateSellOrders(SellOrder[] orders)
        {
            IFormatter formatter = new BinaryFormatter();
            MemoryStream memoryStream = new MemoryStream();
            formatter.Serialize(memoryStream, orders);

            var body = memoryStream.ToArray();

            channel.BasicPublish(
                exchange: SellOrdersExchangeName,
                routingKey: Token,
                basicProperties: null,
                body: body
                );
        }

        public void UpdateTransactionsUpdated(Transaction[] transactions)
        {
            IFormatter formatter = new BinaryFormatter();
            MemoryStream memoryStream = new MemoryStream();
            formatter.Serialize(memoryStream, transactions);

            var body = memoryStream.ToArray();

            channel.BasicPublish(
                exchange: TransactionsExchangeName,
                routingKey: Token,
                basicProperties: null,
                body: body
                );
        }
    }
}
