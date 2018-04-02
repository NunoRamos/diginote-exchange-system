using Server.models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

namespace Server
{
    class ServerLauncher
    {
        static void Main(string[] args)
        {
            using (var db = new DiginoteSystemContext())
            {
                // @FIXME Está a criar sempre este user!!
                /*var user = new User {
                    Name = "Bernardo Belchior", Nickname = "bernardobelchior", Password = "password", Id = 1, Diginotes = new List<Diginote>(), Orders = new List<Order>() };
               
                var diginote = new Diginote { Id = 0, FacialValue = 1.0f, Owner = user };

                db.Users.Add(user);
                db.Diginotes.Add(diginote);
                db.SaveChanges();*/

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
            Int32 port = 8085;
            TcpChannel chan = new TcpChannel(port);
            ChannelServices.RegisterChannel(chan, false);

            RemotingConfiguration.RegisterWellKnownServiceType(
                new Server().GetType(),
                "tcp://localhost:8085/Diginote-Server/Server",
                WellKnownObjectMode.Singleton);

            RemotingConfiguration.RegisterWellKnownServiceType(new Server().GetType(),
                "Diginote-Server/Server", WellKnownObjectMode.Singleton);
            
            Console.WriteLine("Server started on port :" + port);
        }
    }
}
