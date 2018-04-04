using Common.Interfaces;
using System.Windows.Forms;

namespace diginote_exchange_system
{
    public class Client
    {
        public IServer Server { get; set; }

        private FormManager FormManager;

        public Client(IServer server)
        {
            Server = server;

            FormManager = new FormManager(this);
            
            Application.Run(FormManager.AuthenticationForm);
        }

    }
}
