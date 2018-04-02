using Common.Interfaces;
using System.Windows.Forms;

namespace diginote_exchange_system
{
    public class Client
    {
        public IServer serverObj { get; set; }
        

        public Client(IServer serverObj)
        {
            this.serverObj = serverObj;

            Application.Run(new AuthenticationForm(this));
        }

    }
}
