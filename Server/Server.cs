using System;
using System.Linq;
using Common.Interfaces;
using System.Collections.Generic;
using Common;
using System.Data.Entity;
using Server.Models;
using Common.Serializable;

namespace Server
{
    class Server : MarshalByRefObject, IServer
    {
        private readonly int REGISTER_DIGINOTE_BONUS = 100;

        static private DiginoteSystemContext diginoteDB;

        private Dictionary<string, Session> loggedInUsers = new Dictionary<string, Session>();

        public event QuoteUpdated QuoteUpdated;

        public Server()
        {

        }

        public Server(DiginoteSystemContext db)
        {
            diginoteDB = db;
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

            loggedInUsers.Add(token, new Session(userObj.Id));

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
            loggedInUsers.Add(token, new Session(user.Id));

            return Tuple.Create<string, Exception>(token, null);
        }

        #endregion

        public Tuple<Exception, OrderNotSatisfiedException> CreateSellOrder(string token, int quantity)
        {
            float value = GetCurrentQuote();
            User user = GetLoggedInUser(token);
            DbContextTransaction dbTransaction = diginoteDB.Database.BeginTransaction();

            var userIncompleteOrders =
                from purchaseOrders in diginoteDB.Orders
                where purchaseOrders.Status == OrderStatus.Active && purchaseOrders.Type == OrderType.Purchase && purchaseOrders.Quote >= value && purchaseOrders.CreatedById != user.Id
                orderby purchaseOrders.CreatedAt ascending
                select purchaseOrders;

            var availableDiginotes = GetUserAvailableDiginotes(user.Id);

            if (availableDiginotes.Count() < quantity)
            {
                dbTransaction.Rollback();
                return Tuple.Create<Exception, OrderNotSatisfiedException>(new Exception("Insufficient diginotes to place sell order."), null);
            }

            int numSellOrdersCreated = 0;
            foreach (Models.Order purchaseOrder in userIncompleteOrders)
            {
                Models.Order sellOrder = new Models.Order
                {
                    CreatedAt = DateTime.Now,
                    CreatedBy = user,
                    Status = OrderStatus.Complete,
                    Type = OrderType.Sell,
                    Diginote = availableDiginotes.First(),
                    Quote = value
                };

                numSellOrdersCreated++;
                availableDiginotes.RemoveAt(0);
                diginoteDB.Orders.Add(sellOrder);

                sellOrder.Diginote.Owner = purchaseOrder.CreatedBy;
                purchaseOrder.Diginote.Owner = sellOrder.CreatedBy;

                sellOrder.Status = OrderStatus.Complete;

                Models.Transaction transaction = new Models.Transaction
                {
                    CreatedAt = DateTime.Now,
                    PurchaseOrder = purchaseOrder,
                    SellOrder = sellOrder,
                    Quote = value
                };

                diginoteDB.Transactions.Add(transaction);
            }

            dbTransaction.Commit();
            diginoteDB.SaveChanges();

            loggedInUsers[token].UpdateDiginotes(availableDiginotes.Count);
            loggedInUsers[token].UpdateSellOrders(GetUserIncompleteOrders(token, OrderType.Sell));

            if (numSellOrdersCreated < quantity)
            {
                return Tuple.Create<Exception, OrderNotSatisfiedException>(null, new OrderNotSatisfiedException("Order not satisfied", quantity - numSellOrdersCreated, value));
            }

            return Tuple.Create<Exception, OrderNotSatisfiedException>(null, null);
        }

        private List<Diginote> GetUserAvailableDiginotes(int userId)
        {
            var userIncompleteOrders = from order in diginoteDB.Orders
                                       where order.Status != OrderStatus.Complete && order.CreatedById == userId
                                       select order;

            var unavailableDiginotes = from diginote in diginoteDB.Diginotes
                                       where diginote.OwnerId == userId
                                       join order in userIncompleteOrders on diginote.Id equals order.Diginote.Id
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
                from sellOrders in diginoteDB.Orders
                where sellOrders.Status == OrderStatus.Active && sellOrders.Type == OrderType.Sell && sellOrders.Quote <= value && sellOrders.CreatedById != user.Id
                orderby sellOrders.CreatedAt ascending
                select sellOrders;

            var availableDiginotes = GetUserAvailableDiginotes(user.Id);

            if (availableDiginotes.Count() < quantity)
            {
                dbTransaction.Rollback();
                return Tuple.Create<Exception, OrderNotSatisfiedException>(new Exception("Insufficient diginotes to place purchase order."), null);
            }

            int numPurchaseOrdersCreated = 0;
            foreach (Models.Order sellOrder in unmatchedActiveOrders)
            {
                Models.Order purchaseOrder = new Models.Order
                {
                    CreatedAt = DateTime.Now,
                    CreatedBy = user,
                    Status = OrderStatus.Complete,
                    Type = OrderType.Purchase,
                    Quote = value,
                    Diginote = availableDiginotes.First()
                };

                availableDiginotes.RemoveAt(0);
                numPurchaseOrdersCreated++;
                diginoteDB.Orders.Add(purchaseOrder);

                sellOrder.Status = OrderStatus.Complete;

                sellOrder.Diginote.Owner = purchaseOrder.CreatedBy;
                purchaseOrder.Diginote.Owner = sellOrder.CreatedBy;

                Models.Transaction transaction = new Models.Transaction
                {
                    CreatedAt = DateTime.Now,
                    PurchaseOrder = purchaseOrder,
                    SellOrder = sellOrder,
                    Quote = value
                };

                diginoteDB.Transactions.Add(transaction);
            }

            dbTransaction.Commit();
            diginoteDB.SaveChanges();

            loggedInUsers[token].UpdateDiginotes(availableDiginotes.Count);
            loggedInUsers[token].UpdatePurchaseOrders(GetUserIncompleteOrders(token, OrderType.Purchase));

            if (numPurchaseOrdersCreated < quantity)
            {
                return Tuple.Create<Exception, OrderNotSatisfiedException>(null, new OrderNotSatisfiedException("Order not satisfied", quantity - numPurchaseOrdersCreated, value));
            }

            return Tuple.Create<Exception, OrderNotSatisfiedException>(null, null);
        }

        public float GetCurrentQuote()
        {
            var query = from lastOrder in diginoteDB.Orders
                        orderby lastOrder.CreatedAt descending
                        select lastOrder;

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

            var diginotesOnPendingOrders = from order in diginoteDB.Orders
                                           where order.CreatedById == id && order.Status != OrderStatus.Complete
                                           select order;

            dbTransactions.Commit();
            diginoteDB.SaveChanges();

            return usersDiginotes.Count() - diginotesOnPendingOrders.Count();
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
                diginoteDB.Orders.Add(new Models.Order
                {
                    CreatedAt = DateTime.Now,
                    CreatedById = loggedInUsers[token].Id,
                    Diginote = availableDiginotes.First(),
                    Quote = value,
                    Status = OrderStatus.Active,
                    Type = OrderType.Purchase,
                });

                availableDiginotes.RemoveAt(0);
            }

            dbTransaction.Commit();
            diginoteDB.SaveChanges();

            loggedInUsers[token].UpdateDiginotes(availableDiginotes.Count);
            loggedInUsers[token].UpdatePurchaseOrders(GetUserIncompleteOrders(token, OrderType.Purchase));

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

            var availableDiginotes = GetUserAvailableDiginotes(OwnerId);

            if (availableDiginotes.Count < diginotesLeft)
            {
                dbTransaction.Rollback();
                return new Exception("Not enough diginotes available to place order.");
            }

            var usedDiginotes = new List<Diginote>();
            for (int i = 0; i < diginotesLeft; i++)
            {
                diginoteDB.Orders.Add(new Models.Order
                {
                    CreatedAt = DateTime.Now,
                    CreatedById = loggedInUsers[token].Id,
                    Diginote = availableDiginotes.First(),
                    Quote = value,
                    Status = OrderStatus.Active,
                    Type = OrderType.Sell,
                });

                usedDiginotes.Add(availableDiginotes.First());
                availableDiginotes.RemoveAt(0);
            }

            dbTransaction.Commit();
            diginoteDB.SaveChanges();

            loggedInUsers[token].UpdateDiginotes(availableDiginotes.Count);
            loggedInUsers[token].UpdateSellOrders(GetUserIncompleteOrders(token, OrderType.Sell));

            return null;
        }

        public Common.Serializable.Order[] GetUserIncompleteOrders(string token, OrderType type)
        {
            int ownerId = loggedInUsers[token].Id;

            var query = from o in diginoteDB.Orders
                        where o.CreatedById == ownerId && o.Type == type && o.Status != OrderStatus.Complete
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


        #region Subscriptions

        public bool SubscribeUserPurchaseOrdersUpdated(string token, UserPurchaseOrdersUpdated userPurchaseOrdersUpdated)
        {
            if (!loggedInUsers.ContainsKey(token))
                return false;

            loggedInUsers[token].UserPurchaseOrdersUpdated += userPurchaseOrdersUpdated;
            return true;
        }

        public bool SubscribeUserDiginotesUpdated(string token, UserDiginotesUpdated userDiginotesUpdated)
        {
            if (!loggedInUsers.ContainsKey(token))
                return false;

            loggedInUsers[token].UserDiginotesUpdated += userDiginotesUpdated;
            return true;
        }

        public bool SubscribeUserTransactionsUpdated(string token, UserTransactionsUpdated userTransactionsUpdated)
        {
            if (!loggedInUsers.ContainsKey(token))
                return false;

            loggedInUsers[token].UserTransactionsUpdated += userTransactionsUpdated;
            return true;
        }

        public bool SubscribeUserSellOrdersUpdated(string token, UserSellOrdersUpdated userSellOrdersUpdated)
        {
            if (!loggedInUsers.ContainsKey(token))
                return false;

            loggedInUsers[token].UserSellOrdersUpdated += userSellOrdersUpdated;
            return true;
        }

        #endregion
    }
}
