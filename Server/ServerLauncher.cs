using Server.models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Serialization.Formatters;
using System.Collections;

namespace Server
{
    public class ServerLauncher
    {
        static void Main(string[] args)
        {
            DotNetEnv.Env.Load("../../.env");
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
