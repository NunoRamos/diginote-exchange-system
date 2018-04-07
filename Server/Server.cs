using System;
using System.Linq;
using Common.Interfaces;
using System.Collections.Generic;
using Common;
using System.Data.Entity;

namespace Server
{
    class Server : MarshalByRefObject, IServer
    {
        static private DiginoteSystemContext diginoteDB;
        static private Dictionary<string, User> loggedInUsers = new Dictionary<string, User>();

        public event QuoteUpdated QuoteUpdated;

        public Server()
        {

        }

        public Server(DiginoteSystemContext db)
        {
            diginoteDB = db;

            User user = new User
            {
                Name = "admin",
                Nickname = "admin",
                Password = "admin",
                Diginotes = new List<Diginote>(),
                Orders = new List<Order>()
            };

            db.Users.Add(user);

            for (int i = 0; i < 10; i++)
            {
                db.Diginotes.Add(new Diginote
                {
                    FacialValue = 1.0f,
                    Owner = user,
                    Order = null
                });
            }

            db.SaveChanges();
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

            loggedInUsers.Add(token, userObj);

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
                return new Exception("Invalid User Id.");
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

            diginoteDB.Users.Add(user);

            try
            {
                diginoteDB.SaveChanges();
            }
            catch (Exception e)
            {
                return Tuple.Create<string, Exception>(null, e);
            }

            string token = Utils.generateToken();
            loggedInUsers.Add(token, user);

            return Tuple.Create<string, Exception>(token, null);
        }

        #endregion

        public Tuple<Exception, OrderNotSatisfiedException> CreateSellOrder(string token, int quantity, float value)
        {
            User user = loggedInUsers[token];
            DbContextTransaction dbTransaction = diginoteDB.Database.BeginTransaction();

            var query = from purchaseOrders in diginoteDB.Orders
                        where purchaseOrders.Status == OrderStatus.Active && purchaseOrders.Type == OrderType.Purchase && purchaseOrders.Quote <= value
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
                    SellOrder = sellOrder
                };

                diginoteDB.Transaction.Add(transaction);
            }

            dbTransaction.Commit();

            if (numSellOrdersCreated < quantity)
            {
                return Tuple.Create<Exception, OrderNotSatisfiedException>(null, new OrderNotSatisfiedException("Order not satisfied", quantity - numSellOrdersCreated, value));
            }

            return Tuple.Create<Exception, OrderNotSatisfiedException>(null, null);
        }

        public float? GetCurrentQuote()
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
                return null;
            }
        }

        public void UpdateCurrentQuote(float? newQuote)
        {
            QuoteUpdated(newQuote);
        }

        public int GetDiginotes(string token)
        {
            return loggedInUsers[token].Diginotes.Count;
        }
    }
}
