using System;
using System.Linq;
using Common.Interfaces;

namespace Server
{
    class Server : IServer
    {
        private DiginoteSystemContext diginoteDB;

        public Server() { }

        public Server(DiginoteSystemContext db)
        {
            this.diginoteDB = db;
        }

        public override bool Login(string nickname, string password)
        {
            Console.WriteLine("Login request");

            var query = from user in diginoteDB.Users
                        where user.Nickname == nickname && user.Password == password
                        select user;

            foreach (var item in query)
            {
                Console.WriteLine(item.Nickname);
            }

            return true;
        }
    }
}
