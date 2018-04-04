using System;
using System.Linq;
using Common.Interfaces;
using Server.models;
using System.Collections.Generic;

namespace Server
{
    class Server : IServer
    {
        static private DiginoteSystemContext diginoteDB;
        static private Dictionary<int, User> loggedInUsers = new Dictionary<int, User>();

        public Server()
        {

        }

        public Server(DiginoteSystemContext db)
        {
            diginoteDB = db;

            db.Users.Add(new User
            {
                Diginotes = new List<Diginote>(),
                Name = "admin",
                Nickname = "admin",
                Orders = new List<Order>(),
                Password = "admin"
            });

            db.SaveChangesAsync();
        }

        public override Tuple<int?, Exception> Login(string nickname, string password)
        {
            Console.WriteLine("SERVER: Login request by User with nickname: " + nickname);

            var query = from user in diginoteDB.Users
                        where user.Nickname == nickname && user.Password == password
                        select user;

            // Can only return one result
            if (query.ToArray().Length != 1)
            {
                return Tuple.Create<int?, Exception>(null, new Exception("Invalid credentials."));
            }

            User userObj = query.ToArray()[0];
            loggedInUsers.Add(userObj.Id, userObj);

            return Tuple.Create<int?, Exception>(userObj.Id, null);
        }

        public override Exception Logout(int id)
        {
            if(loggedInUsers.ContainsKey(id))
            {
            loggedInUsers.Remove(id);
                return null;
            }
            else
            {
                return new Exception("Invalid User Id.");
            }
        }

        public override Tuple<int?, Exception> Register(string name, string nickname, string password)
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
                return Tuple.Create<int?, Exception>(null, e);
            }

            return Tuple.Create<int?, Exception>(user.Id, null);
        }
    }
}
