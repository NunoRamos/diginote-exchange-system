using Common;
using Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Text;
using System.Threading.Tasks;

namespace diginote_exchange_system
{
    class StateManager
    {
        private static StateManager state;

        public string Token { get; set; }

        public IServer Server { get; }

        private StateManager()
        {
            Server = ConnectToServer();
        }

        public static StateManager getInstance()
        {
            if (state == null)
            {
                state = new StateManager();
            }

            return state;
        }

        private static IServer ConnectToServer()
        {
            string SERVER_ADDR = "tcp://localhost:8085/Diginote-Server/Server";
            TcpChannel chan = new TcpChannel(8086);
            ChannelServices.RegisterChannel(chan, false);

            IServer serverObj;

            serverObj = (IServer)Activator.GetObject(typeof(IServer), SERVER_ADDR);

            if (serverObj == null)
            {
                throw new Exception("Could not locate server on: \"" + SERVER_ADDR + "\"");
            }

            Console.WriteLine("Connection successfully established!");

            return serverObj;
        }

        public Tuple<Exception, OrderNotSatisfiedException> CreateSellOrder(int quantity, float value)
        {
            return Server.CreateSellOrder(Token, quantity, value);
        }
    }
}
