using System;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Windows.Forms;
using Common.Interfaces;

namespace diginote_exchange_system
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ConnectToServer();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new AuthenticationForm());
        }

        static void ConnectToServer()
        {
            TcpChannel chan = new TcpChannel(8086);
            ChannelServices.RegisterChannel(chan, false);

            IServer serverOjb;

            serverOjb = (IServer)Activator.GetObject(
            typeof(IServer),
            "tcp://localhost:8085/Diginote-Server/Server");
            if (serverOjb == null)
                Console.WriteLine("Could not locate server");
            else
            {
                Console.WriteLine("Consegui ligar!");
                serverOjb.Login("teste", "teste");
            }
        }
    }
}
