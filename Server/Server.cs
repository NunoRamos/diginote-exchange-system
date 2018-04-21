using System;
using System.Linq;
using Common.Interfaces;
using System.Collections.Generic;
using Common;
using Server.Models;
using RabbitMQ.Client;
using System.Data.Entity;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;

namespace Server
{
    class Server : MarshalByRefObject, IServer
    {
        private readonly int REGISTER_DIGINOTE_BONUS = 100;

        static private DiginoteSystemContext diginoteDB;

        private Dictionary<string, Session> loggedInUsers = new Dictionary<string, Session>();

        private IModel channel;

        public Server()
        {
            ConnectionFactory factory = new ConnectionFactory();
            IConnection connection = factory.CreateConnection();
            channel = connection.CreateModel();

            channel.ExchangeDeclare(exchange: "current.quote", type: "topic");
        }

        public Server(DiginoteSystemContext db)
        {
            diginoteDB = db;
        }

        private void QuoteUpdated(float newQuote)
        {
            IFormatter formatter = new BinaryFormatter();
            MemoryStream memoryStream = new MemoryStream();
            formatter.Serialize(memoryStream, newQuote);

            channel.BasicPublish(exchange: "current.quote",
                routingKey: "current.quote",
                basicProperties: null,
                body: memoryStream.ToArray());
        }

        private User GetLoggedInUser(string token)
        {
            int userId = loggedInUsers[token].Id;
            return (from u in diginoteDB.Users
                    where u.Id == userId
                    select u).First();
        }

        #region SessionManagement

        public Tuple<string, Exception> Login(string nickname, string password)
        {
            Console.WriteLine("SERVER: Login request by User with nickname: " + nickname);

            var query = from user in diginoteDB.Users
                        where user.Nickname == nickname && user.Password == password
                        select user;

            // Can only return one result
            if (query.ToArray().Length != 1)
            {
                return Tuple.Create<string, Exception>(null, new Exception("Invalid credentials."));
            }

            User userObj = query.ToArray()[0];
            string token = Utils.generateToken();

            loggedInUsers.Add(token, new Session(channel, token, userObj.Id));

            return Tuple.Create<string, Exception>(token, null);
        }


        public Exception Logout(string token)
        {
            if (loggedInUsers.ContainsKey(token))
            {
                loggedInUsers.Remove(token);
                return null;
            }
            else
            {
                return new Exception("Invalid user token.");
            }
        }

        public Tuple<string, Exception> Register(string name, string nickname, string password)
        {
            Console.WriteLine("SERVER: Register request by user with name: " + name + " and nickname " + nickname);

            var user = new User
            {
                Name = name,
                Nickname = nickname,
                Password = password,
                Diginotes = new List<Diginote>(),
                Orders = new List<Models.Order>()
            };

            user = diginoteDB.Users.Add(user);

            for (int i = 0; i < REGISTER_DIGINOTE_BONUS; i++)
            {
                diginoteDB.Diginotes.Add(new Diginote
                {
                    FacialValue = 1,
                    OwnerId = user.Id
                });
            }

            try
            {
                diginoteDB.SaveChanges();
            }
            catch (Exception e)
            {
                return Tuple.Create<string, Exception>(null, e);
            }

            string token = Utils.generateToken();
            loggedInUsers.Add(token, new Session(channel, token, user.Id));

            return Tuple.Create<string, Exception>(token, null);
        }

        #endregion

        public Tuple<Exception, OrderNotSatisfiedException> CreateSellOrder(string token, int quantity)
        {
            float value = GetCurrentQuote();
            User user = GetLoggedInUser(token);
            DbContextTransaction dbTransaction = diginoteDB.Database.BeginTransaction();

            var userIncompleteOrders =
                from purchaseOrders in diginoteDB.PurchaseOrders
                where purchaseOrders.Status == OrderStatus.Active && purchaseOrders.Quote >= value && purchaseOrders.CreatedById != user.Id
                orderby purchaseOrders.CreatedAt ascending
                select purchaseOrders;

            var availableDiginotes = GetUserAvailableDiginotes(user.Id);

            if (availableDiginotes.Count() < quantity)
            {
                dbTransaction.Rollback();
                return Tuple.Create<Exception, OrderNotSatisfiedException>(new Exception("Insufficient diginotes to place sell order."), null);
            }

            HashSet<Session> affectedUsers = new HashSet<Session>();

            int numSellOrdersCreated = 0;
            foreach (PurchaseOrder purchaseOrder in userIncompleteOrders)
            {
                SellOrder sellOrder = new SellOrder
                {
                    CreatedAt = DateTime.Now,
                    CreatedBy = user,
                    Status = OrderStatus.Complete,
                    Diginote = availableDiginotes.First(),
                    Quote = value
                };

                numSellOrdersCreated++;
                availableDiginotes.RemoveAt(0);
                diginoteDB.SellOrders.Add(sellOrder);

                sellOrder.Diginote.Owner = purchaseOrder.CreatedBy;

                purchaseOrder.Status = OrderStatus.Complete;

                Models.Transaction transaction = new Models.Transaction
                {
                    CreatedAt = DateTime.Now,
                    PurchaseOrder = purchaseOrder,
                    SellOrder = sellOrder,
                    Quote = value
                };

                diginoteDB.Transactions.Add(transaction);

                foreach (var affectedUser in loggedInUsers.Where(pair => pair.Value.Id == purchaseOrder.CreatedBy.Id))
                {
                    affectedUsers.Add(affectedUser.Value);
                }

                if (numSellOrdersCreated >= quantity)
                {
                    break;
                }
            }

            dbTransaction.Commit();
            diginoteDB.SaveChanges();

            QuoteUpdated(value);

            foreach (var session in affectedUsers)
            {
                session.UpdatePurchaseOrders(GetUserIncompletePurchaseOrders(session.Token));
            }

            loggedInUsers[token].UpdateDiginotes(availableDiginotes.Count);
            loggedInUsers[token].UpdateSellOrders(GetUserIncompleteSellOrders(token));

            if (numSellOrdersCreated < quantity)
            {
                return Tuple.Create<Exception, OrderNotSatisfiedException>(null, new OrderNotSatisfiedException("Order not satisfied", quantity - numSellOrdersCreated, value));
            }

            return Tuple.Create<Exception, OrderNotSatisfiedException>(null, null);
        }

        private List<Diginote> GetUserAvailableDiginotes(int userId)
        {
            var userIncompleteSellOrders = from order in diginoteDB.SellOrders
                                           where order.Status != OrderStatus.Complete && order.CreatedById == userId
                                           select order;


            var unavailableDiginotes = from diginote in diginoteDB.Diginotes
                                       where diginote.OwnerId == userId
                                       join order in userIncompleteSellOrders on diginote.Id equals order.Diginote.Id
                                       select diginote;

            return (from diginote in diginoteDB.Diginotes
                    where !unavailableDiginotes.Contains(diginote) && diginote.OwnerId == userId
                    select diginote).ToList();
        }

        public Tuple<Exception, OrderNotSatisfiedException> CreatePurchaseOrder(string token, int quantity)
        {
            User user = GetLoggedInUser(token);
            DbContextTransaction dbTransaction = diginoteDB.Database.BeginTransaction();
            float value = GetCurrentQuote();

            var unmatchedActiveOrders =
                from sellOrders in diginoteDB.SellOrders
                where sellOrders.Status == OrderStatus.Active && sellOrders.Quote <= value && sellOrders.CreatedById != user.Id
                orderby sellOrders.CreatedAt ascending
                select sellOrders;

            var availableDiginotes = GetUserAvailableDiginotes(user.Id);

            if (availableDiginotes.Count() < quantity)
            {
                dbTransaction.Rollback();
                return Tuple.Create<Exception, OrderNotSatisfiedException>(new Exception("Insufficient diginotes to place purchase order."), null);
            }

            HashSet<Session> affectedUsers = new HashSet<Session>();

            int numPurchaseOrdersCreated = 0;
            foreach (SellOrder sellOrder in unmatchedActiveOrders)
            {
                PurchaseOrder purchaseOrder = new PurchaseOrder
                {
                    CreatedAt = DateTime.Now,
                    CreatedBy = user,
                    Status = OrderStatus.Complete,
                    Quote = value
                };

                availableDiginotes.RemoveAt(0);
                numPurchaseOrdersCreated++;
                diginoteDB.PurchaseOrders.Add(purchaseOrder);

                sellOrder.Status = OrderStatus.Complete;

                sellOrder.Diginote.Owner = purchaseOrder.CreatedBy;

                Models.Transaction transaction = new Models.Transaction
                {
                    CreatedAt = DateTime.Now,
                    PurchaseOrder = purchaseOrder,
                    SellOrder = sellOrder,
                    Quote = value
                };

                diginoteDB.Transactions.Add(transaction);

                foreach (var affectedUser in loggedInUsers.Where(pair => pair.Value.Id == sellOrder.CreatedBy.Id))
                {
                    affectedUsers.Add(affectedUser.Value);
                }

                if (numPurchaseOrdersCreated >= quantity)
                {
                    break;
                }
            }

            dbTransaction.Commit();
            diginoteDB.SaveChanges();

            QuoteUpdated(value);

            foreach (var session in affectedUsers)
            {
                session.UpdateSellOrders(GetUserIncompleteSellOrders(session.Token));
            }

            loggedInUsers[token].UpdateDiginotes(availableDiginotes.Count);
            loggedInUsers[token].UpdatePurchaseOrders(GetUserIncompletePurchaseOrders(token));

            if (numPurchaseOrdersCreated < quantity)
            {
                return Tuple.Create<Exception, OrderNotSatisfiedException>(null, new OrderNotSatisfiedException("Order not satisfied", quantity - numPurchaseOrdersCreated, value));
            }

            return Tuple.Create<Exception, OrderNotSatisfiedException>(null, null);
        }

        public float GetCurrentQuote()
        {
            var query = (from lastOrder in diginoteDB.SellOrders
                         orderby lastOrder.CreatedAt descending
                         select lastOrder).ToList();

            try
            {
                return query.First().Quote;
            }
            catch (InvalidOperationException)
            {
                return 1;
            }
        }

        public void UpdateCurrentQuote(float newQuote)
        {
            QuoteUpdated(newQuote);
        }

        public int GetAvailableDiginotes(string token)
        {
            int id = loggedInUsers[token].Id;

            var dbTransactions = diginoteDB.Database.BeginTransaction();
            var usersDiginotes = from diginote in diginoteDB.Diginotes
                                 where diginote.OwnerId == id
                                 select diginote;

            var diginotesOnPendingSellOrders = from order in diginoteDB.SellOrders
                                               where order.CreatedById == id && order.Status != OrderStatus.Complete
                                               select order;

            dbTransactions.Commit();
            diginoteDB.SaveChanges();

            return usersDiginotes.Count() - diginotesOnPendingSellOrders.Count();
        }

        public Exception ConfirmPurchaseOrder(string token, int diginotesLeft, float value)
        {
            int ownerId = loggedInUsers[token].Id;

            var dbTransaction = diginoteDB.Database.BeginTransaction();
            float currentQuote = GetCurrentQuote();

            if (value < currentQuote)
            {
                dbTransaction.Rollback();
                return new Exception("Value must be greater than or equal to the current quote");
            }

            var availableDiginotes = GetUserAvailableDiginotes(ownerId);

            if (availableDiginotes.Count < diginotesLeft)
            {
                dbTransaction.Rollback();
                return new Exception("Not enough diginotes available to place order.");
            }

            for (int i = 0; i < diginotesLeft; i++)
            {
                diginoteDB.PurchaseOrders.Add(new PurchaseOrder
                {
                    CreatedAt = DateTime.Now,
                    CreatedById = loggedInUsers[token].Id,
                    Quote = value,
                    Status = OrderStatus.Active,
                });

                availableDiginotes.RemoveAt(0);
            }

            dbTransaction.Commit();
            diginoteDB.SaveChanges();

            QuoteUpdated(value);
            loggedInUsers[token].UpdateDiginotes(availableDiginotes.Count);
            loggedInUsers[token].UpdatePurchaseOrders(GetUserIncompletePurchaseOrders(token));

            return null;
        }
        public Exception ConfirmSellOrder(string token, int diginotesLeft, float value)
        {
            int OwnerId = loggedInUsers[token].Id;
            var dbTransaction = diginoteDB.Database.BeginTransaction();
            float currentQuote = GetCurrentQuote();

            if (value > currentQuote)
            {
                dbTransaction.Rollback();
                return new Exception("Value must be lesser than or equal to the current quote");
            }

            if (value < currentQuote)
            {

            }

            var availableDiginotes = GetUserAvailableDiginotes(OwnerId);

            if (availableDiginotes.Count < diginotesLeft)
            {
                dbTransaction.Rollback();
                return new Exception("Not enough diginotes available to place order.");
            }

            var usedDiginotes = new List<Diginote>();
            for (int i = 0; i < diginotesLeft; i++)
            {
                diginoteDB.SellOrders.Add(new SellOrder
                {
                    CreatedAt = DateTime.Now,
                    CreatedById = loggedInUsers[token].Id,
                    Quote = value,
                    Status = OrderStatus.Active,
                    Diginote = availableDiginotes.First()
                });

                usedDiginotes.Add(availableDiginotes.First());
                availableDiginotes.RemoveAt(0);
            }

            dbTransaction.Commit();
            diginoteDB.SaveChanges();

            QuoteUpdated(value);
            loggedInUsers[token].UpdateDiginotes(availableDiginotes.Count);
            loggedInUsers[token].UpdateSellOrders(GetUserIncompleteSellOrders(token));

            return null;
        }

        public Common.Serializable.SellOrder[] GetUserIncompleteSellOrders(string token)
        {
            int ownerId = loggedInUsers[token].Id;

            var query = from o in diginoteDB.SellOrders
                        where o.CreatedById == ownerId && o.Status != OrderStatus.Complete
                        select o;

            return query.ToArray().Select(o => o.Serialize()).ToArray();
        }

        public Common.Serializable.PurchaseOrder[] GetUserIncompletePurchaseOrders(string token)
        {
            int ownerId = loggedInUsers[token].Id;

            var query = from o in diginoteDB.PurchaseOrders
                        where o.CreatedById == ownerId && o.Status != OrderStatus.Complete
                        select o;

            return query.ToArray().Select(o => o.Serialize()).ToArray();
        }

        public Common.Serializable.Transaction[] GetUserTransactions(string token)
        {
            int userId = loggedInUsers[token].Id;

            var query = from t in diginoteDB.Transactions
                        where t.PurchaseOrder.CreatedById == userId || t.SellOrder.CreatedById == userId
                        select t;

            return query.ToArray().Select(t => t.Serialize()).ToArray();
        }

        public String DeleteSellOrders(int[] ordersId)
        {
            String status = "";

            foreach (int id in ordersId)
            {
                var order = (from o in diginoteDB.SellOrders
                             where o.Id == id
                             select o).Single();

                diginoteDB.SellOrders.Remove(order);
                diginoteDB.SaveChanges();
            }

            status = "Sell Order Deleted!";

            return status;
        }

        public String DeletePurchaseOrders(int[] ordersId)
        {
            String status = "";

            foreach (int id in ordersId)
            {
                var order = (from o in diginoteDB.PurchaseOrders
                             where o.Id == id
                             select o).Single();

                diginoteDB.PurchaseOrders.Remove(order);
                diginoteDB.SaveChanges();
            }

            status = "Purchase Order Deleted!";

            return status;
        }

        public String UpdatePurchaseOrders(Common.Serializable.PurchaseOrder[] UpdatePurchaseOrders)
        {
            String status = "";

            foreach (Common.Serializable.PurchaseOrder purchaseOrder in UpdatePurchaseOrders)
            {
                var order = (from o in diginoteDB.PurchaseOrders
                             where o.Id == purchaseOrder.Id
                             select o).Single();

                if (order != null)
                {
                    if (order.Quote <= purchaseOrder.Quote)
                    {
                        order.Quote = purchaseOrder.Quote;
                        diginoteDB.SaveChanges();
                        status = "Purchase Order Updated!";
                    }
                    else
                    {
                        status = "Purchase Order Quote needs to be higher or equal to the atual!";
                    }
                }

            }

            return status;
        }

        public String UpdateSellOrders(Common.Serializable.SellOrder[] UpdateSellOrders)
        {
            String status = "";

            foreach (Common.Serializable.SellOrder sellOrder in UpdateSellOrders)
            {
                var order = (from o in diginoteDB.SellOrders
                             where o.Id == sellOrder.Id
                             select o).Single();

                if (order != null)
                {
                    if (order.Quote >= sellOrder.Quote)
                    {
                        order.Quote = sellOrder.Quote;
                        diginoteDB.SaveChanges();
                        status = "Sell Order Updated!";
                    }
                    else
                    {
                        status = "Sell Order Quote needs to be less or equal to the atual!";
                    }
                }

            }

            return status;
        }
    }
}
