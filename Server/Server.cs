using System;
using System.Linq;
using Common.Interfaces;
using System.Collections;

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


            return true;
        }
    }
}
