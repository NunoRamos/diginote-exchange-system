using Server.models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Serialization.Formatters;
using System.Collections;
using System.Runtime.Remoting.Channels.Tcp;

namespace Server
{
    class ServerLauncher
    {
        static void Main(string[] args)
        {
            using (var db = new DiginoteSystemContext())
            {
                var user = new User {
                    Name = "Bernardo Belchior", Nickname = "bernardobelchior", Password = "password", Id = 1, Diginotes = new List<Diginote>(), Orders = new List<Order>() };

                var diginote = new Diginote { Id = 0, FacialValue = 1.0f, Owner = user };

                db.Users.Add(user);
                db.Diginotes.Add(diginote);
                db.SaveChanges();

                var query = from d in db.Diginotes
                            select d;

                foreach(var item in query)
                {
                    Console.WriteLine(item.FacialValue);
                }

                SetupServer();

                Console.ReadLine();
            }

        }

        private static void SetupServer()
        {
            BinaryServerFormatterSinkProvider provider = new BinaryServerFormatterSinkProvider
            {
                TypeFilterLevel = TypeFilterLevel.Full
            };
            IDictionary props = new Hashtable();
            int port = 35994;
            props["port"] = port;
            TcpChannel channel = new TcpChannel(props, null, provider);

            ChannelServices.RegisterChannel(channel, false);

            RemotingConfiguration.RegisterWellKnownServiceType(new Server().GetType(),
                "Diginote-Server/Server", WellKnownObjectMode.Singleton);
            
            Console.WriteLine("Server started on port :" + port);
        }
    }
}
