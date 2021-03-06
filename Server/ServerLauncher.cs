﻿using RabbitMQ.Client;
using System;
using System.IO;
using System.Runtime.Remoting;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Server
{
    public class ServerLauncher
    {
        static void Main(string[] args)
        {
            using (var db = new DiginoteSystemContext())
            {
                Server server = new Server(db);
                SetupServer(server);

                Console.ReadLine();
            }

        }

        private static void SetupServer(Server server)
        {
            RemotingConfiguration.Configure("Server.exe.config", false);
            Console.WriteLine("Server started on port: 9000");
        }
    }
}
