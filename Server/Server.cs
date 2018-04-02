using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
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
            return true;
        }
    }
}
