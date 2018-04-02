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
        public override bool Login(string nickname, string password)
        {
            Console.WriteLine("Login request");
            return true;
        }
    }
}
