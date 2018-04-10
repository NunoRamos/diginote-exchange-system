using System;
using System.Linq;
using Common.Interfaces;
using System.Collections.Generic;
using Common;
using System.Data.Entity;
using Server.Models;

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

            var query = from purchaseOrders in diginoteDB.Orders
                        where purchaseOrders.Status == OrderStatus.Active && purchaseOrders.Type == OrderType.Purchase && purchaseOrders.Quote >= value
                        orderby purchaseOrders.CreatedAt ascending
                        select purchaseOrders;


            int numSellOrdersCreated = 0;
            foreach (Order order in query)
            {
                Order sellOrder = new Order
                {
                    CreatedAt = DateTime.Now,
                    CreatedBy = user,
                    Status = OrderStatus.Complete,
                    Type = OrderType.Sell,
                    Diginote = user.Diginotes.Last(),
                    Quote = value
                };

                numSellOrdersCreated++;
                user.Diginotes.Remove(user.Diginotes.Last());
                diginoteDB.Orders.Add(sellOrder);


                Transaction transaction = new Transaction
                {
                    CreatedAt = DateTime.Now,
                    PurchaseOrder = order,
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

        public Tuple<Exception, OrderNotSatisfiedException> CreatePurchaseOrder(string token, int quantity)
        {
            User user = GetLoggedInUser(token);
            DbContextTransaction dbTransaction = diginoteDB.Database.BeginTransaction();
            float value = GetCurrentQuote();

            var query = from sellOrders in diginoteDB.Orders
                        where sellOrders.Status == OrderStatus.Active && sellOrders.Type == OrderType.Sell && sellOrders.Quote <= value
                        orderby sellOrders.CreatedAt ascending
                        select sellOrders;

            int numPurchaseOrdersCreated = 0;
            foreach (Order order in query)
            {
                User ownerOfOrder = order.CreatedBy;

                Order purchaseOrder = new Order
                {
                    CreatedAt = DateTime.Now,
                    CreatedBy = user,
                    Status = OrderStatus.Complete,
                    Type = OrderType.Purchase,
                    Quote = value
                };

                numPurchaseOrdersCreated++;
                user.Diginotes.Add(ownerOfOrder.Diginotes.Last());
                ownerOfOrder.Diginotes.Remove(ownerOfOrder.Diginotes.Last());
                diginoteDB.Orders.Add(purchaseOrder);


                Transaction transaction = new Transaction
                {
                    CreatedAt = DateTime.Now,
                    PurchaseOrder = purchaseOrder,
                    SellOrder = order,
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

        public void UpdateCurrentQuote(float? newQuote)
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

            var diginotesOnPendingOrders = from order in diginoteDB.Orders
                         where order.CreatedById == id && order.Status != OrderStatus.Complete
                         select order;

            dbTransactions.Commit();

            return usersDiginotes.Count() - diginotesOnPendingOrders.Count();
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

            var diginotes = (from d in diginoteDB.Diginotes
                             where d.OwnerId == OwnerId
                             select d).Take(diginotesLeft).ToArray();

            for (int i = 0; i < diginotesLeft; i++)
            {
                diginoteDB.Orders.Add(new Order
                {
                    CreatedAt = DateTime.Now,
                    CreatedById = loggedInUsers[token],
                    DiginoteId = diginotes[i].Id,
                    Quote = value,
                    Status = OrderStatus.Active,
                    Type = OrderType.Purchase,
                });
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

            var diginotes = (from d in diginoteDB.Diginotes
                             where d.OwnerId == OwnerId
                             select d).Take(diginotesLeft).ToArray();

            for (int i = 0; i < diginotesLeft; i++)
            {
                diginoteDB.Orders.Add(new Order
                {
                    CreatedAt = DateTime.Now,
                    CreatedById = loggedInUsers[token],
                    //DiginoteId = diginotes[i].Id,
                    Diginote = diginotes[i],
                    Quote = value,
                    Status = OrderStatus.Active,
                    Type = OrderType.Sell,
                });
            }

            dbTransaction.Commit();
            diginoteDB.SaveChanges();

            return null;
        }

        public Common.Serializable.Order[] GetUserOrders(string token, OrderType type)
        {
            int ownerId = loggedInUsers[token];

            var query = from o in diginoteDB.Orders
                        where o.CreatedById == ownerId && o.Type == type
                        select o;

            return query.ToArray().Select(o => o.Serialize()).ToArray();
        }
    }
}
