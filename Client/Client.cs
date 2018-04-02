using Common.Interfaces;
using System.Windows.Forms;

namespace diginote_exchange_system
{
    public class Client
    {
        public IServer serverObj;

        public IServer ServerObj { get => serverObj; set => serverObj = value; }

        public Client(IServer serverObj)
        {
            this.ServerObj = serverObj;

            Application.Run(new AuthenticationForm(this));
        }

    }
}
