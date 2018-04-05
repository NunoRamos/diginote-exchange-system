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
            BinaryServerFormatterSinkProvider provider = new BinaryServerFormatterSinkProvider();
            provider.TypeFilterLevel = TypeFilterLevel.Full;
            IDictionary props = new Hashtable();
            int port = 8085;
            props["port"] = port;
            TcpChannel chan = new TcpChannel(props, null, provider);

            ChannelServices.RegisterChannel(chan, false);

            RemotingConfiguration.RegisterWellKnownServiceType(server.GetType(),
                "Diginote-Server/Server", WellKnownObjectMode.Singleton);
            
            Console.WriteLine("Server started on port :" + port);
        }
    }
}
