using System;
using System.Runtime.Remoting;

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
