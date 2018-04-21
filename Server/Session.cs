using Common.Interfaces;
using Common.Serializable;
using RabbitMQ.Client;
using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Common
{
    public class Session
    {
        private IModel channel;
        public string Token { get; }
        public int Id { get; }

        private string diginotesChannelName;
        private string purchaseOrdersChannelName;
        private string sellOrdersChannelName;
        private string transactionsChannelName;

        public Session(IModel channel, string token, int id)
        {
            this.channel = channel;
            Token = token;
            Id = id;

            diginotesChannelName = "Diginotes" + token;
            purchaseOrdersChannelName = "PurchaseOrders" + token;
            sellOrdersChannelName = "SellOrders" + token;
            transactionsChannelName = "Transactions" + token;

            /*CreateChannel(diginotesChannelName);
            CreateChannel(purchaseOrdersChannelName);
            CreateChannel(sellOrdersChannelName);
            CreateChannel(transactionsChannelName);*/
        }

        private void CreateChannel(string channelName)
        {
            channel.QueueDeclare(
                queue: channelName,
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);
        }

        public void UpdateDiginotes(int diginotes)
        {
            IFormatter formatter = new BinaryFormatter();
            MemoryStream memoryStream = new MemoryStream();
            formatter.Serialize(memoryStream, diginotes);

            var body = memoryStream.ToArray();

            channel.BasicPublish(
                exchange: "diginotes",
                routingKey: diginotesChannelName,
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
                exchange: "diginotes",
                routingKey: purchaseOrdersChannelName,
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
                exchange: "diginotes",
                routingKey: sellOrdersChannelName,
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
                exchange: "diginotes",
                routingKey: transactionsChannelName,
                basicProperties: null,
                body: body
                );
        }
    }
}
