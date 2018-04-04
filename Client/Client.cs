using Common.Interfaces;
using System.Windows.Forms;

namespace diginote_exchange_system
{
    public class Client
    {
        private FormManager FormManager;

        public Client()
        {
            FormManager = new FormManager(this);
            
            Application.Run(FormManager.AuthenticationForm);
        }

    }
}
