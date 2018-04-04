using Server.models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

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
            Int32 port = 8085;
            TcpChannel chan = new TcpChannel(port);
            ChannelServices.RegisterChannel(chan, false);

            RemotingConfiguration.RegisterWellKnownServiceType(server.GetType(),
                "Diginote-Server/Server", WellKnownObjectMode.Singleton);
            
            Console.WriteLine("Server started on port :" + port);
        }
    }
}
