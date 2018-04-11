    using System;
using System.Linq;
using Common.Interfaces;
using System.Collections.Generic;
using Common;
using Server.Models;
using System.Data.Entity;

namespace Server
{
    class Server : MarshalByRefObject, IServer
    {
        private readonly int REGISTER_DIGINOTE_BONUS = 100;

        static private DiginoteSystemContext diginoteDB;
        static private Dictionary<string, int> loggedInUsers = new Dictionary<string, int>();

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
            int userId = loggedInUsers[token];
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

            loggedInUsers.Add(token, userObj.Id);

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
                Orders = new List<Order>()
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
            loggedInUsers.Add(token, user.Id);

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

                sellOrder.Status = OrderStatus.Complete;

                Transaction transaction = new Transaction
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

            if (numSellOrdersCreated < quantity)
            {
                return Tuple.Create<Exception, OrderNotSatisfiedException>(null, new OrderNotSatisfiedException("Order not satisfied", quantity - numSellOrdersCreated, value));
            }

            return Tuple.Create<Exception, OrderNotSatisfiedException>(null, null);
        }

        private List<Diginote> GetUserAvailableDiginotes(int userId)
        {
            // TODO
            /*var userIncompleteOrders = from order in diginoteDB.Orders
                                       where order.Status != OrderStatus.Complete && order.CreatedById == userId
                                       select order;

            var unavailableDiginotes = from diginote in diginoteDB.Diginotes
                                       where diginote.OwnerId == userId
                                       join order in userIncompleteOrders on diginote.Id equals order.Diginote.Id
                                       select diginote;*/

            return (from diginote in diginoteDB.Diginotes
                        // where !unavailableDiginotes.Contains(diginote) && diginote.OwnerId == userId
                    where diginote.OwnerId == userId
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

                Transaction transaction = new Transaction
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

            if (numPurchaseOrdersCreated < quantity)
            {
                return Tuple.Create<Exception, OrderNotSatisfiedException>(null, new OrderNotSatisfiedException("Order not satisfied", quantity - numPurchaseOrdersCreated, value));
            }

            return Tuple.Create<Exception, OrderNotSatisfiedException>(null, null);
        }

        public float GetCurrentQuote()
        {
            var query = from lastOrder in diginoteDB.SellOrders
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
            int id = loggedInUsers[token];

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
            var OwnerId = loggedInUsers[token];

            var dbTransaction = diginoteDB.Database.BeginTransaction();
            float currentQuote = GetCurrentQuote();

            if (value < currentQuote)
            {
                dbTransaction.Rollback();
                return new Exception("Value must be greater than or equal to the current quote");
            }

            var availableDiginotes = GetUserAvailableDiginotes(OwnerId);

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
                    CreatedById = loggedInUsers[token],
                    Quote = value,
                    Status = OrderStatus.Active,
                });

                availableDiginotes.RemoveAt(0);
            }

            dbTransaction.Commit();
            diginoteDB.SaveChanges();

            return null;
        }
        public Exception ConfirmSellOrder(string token, int diginotesLeft, float value)
        {
            int OwnerId = loggedInUsers[token];
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
                diginoteDB.SellOrders.Add(new SellOrder
                {
                    CreatedAt = DateTime.Now,
                    CreatedById = loggedInUsers[token],
                    Quote = value,
                    Status = OrderStatus.Active,
                    Diginote = availableDiginotes.First()
                });

                usedDiginotes.Add(availableDiginotes.First());
                availableDiginotes.RemoveAt(0);
            }

            dbTransaction.Commit();
            diginoteDB.SaveChanges();

            return null;
        }

        public Common.Serializable.SellOrder[] GetUserIncompleteSellOrders(string token)
        {
            int ownerId = loggedInUsers[token];

            var query = from o in diginoteDB.SellOrders
                        where o.CreatedById == ownerId && o.Status != OrderStatus.Complete
                        select o;

            return query.ToArray().Select(o => o.Serialize()).ToArray();
        }

        public Common.Serializable.PurchaseOrder[] GetUserIncompletePurchaseOrders(string token)
        {
            int ownerId = loggedInUsers[token];
            
            var query = from o in diginoteDB.PurchaseOrders
                        where o.CreatedById == ownerId && o.Status != OrderStatus.Complete
                        select o;

            return query.ToArray().Select(o => o.Serialize()).ToArray();
        }

        public Common.Serializable.Transaction[] GetUserTransactions(string token)
        {
            int userId = loggedInUsers[token];

            var query = from t in diginoteDB.Transactions
                        where t.PurchaseOrder.CreatedById == userId || t.SellOrder.CreatedById == userId
                        select t;

            return query.ToArray().Select(t => t.Serialize()).ToArray();
        }
    }
}
