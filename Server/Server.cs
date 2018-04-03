using System;
using System.Linq;
using Common.Interfaces;
using System.Collections;
using Server.models;
using System.Collections.Generic;

namespace Server
{
    class Server : IServer
    {
        static private DiginoteSystemContext diginoteDB;
        static private ArrayList loggedInUsers = new ArrayList();

        public Server() { }

        public Server(DiginoteSystemContext db)
        {
            diginoteDB = db;
        }

        public override bool Login(string nickname, string password)
        {
            Console.WriteLine("SERVER: Login request by User with nickname: " + nickname);

            var query = from user in diginoteDB.Users
                        where user.Nickname == nickname && user.Password == password
                        select user;

            // Can only return one result
            if (query.ToArray().Length != 1)
            {
                return false;
            }
            
            loggedInUsers.Add(query.ToArray()[0]);

            return true;
        }

        public override bool Register(string name, string nickname, string password)
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

            var diginote = new Diginote { FacialValue = 0.0f, Owner = user };

            diginoteDB.Users.Add(user);
            diginoteDB.Diginotes.Add(diginote);
            try
            {
                diginoteDB.SaveChanges();
            }
            catch (Exception e)
            {

                return false;
            }

            return true;
        }
    }
}
