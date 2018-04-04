using diginote_exchange_system.Views;
using System.Windows.Forms;

namespace diginote_exchange_system
{
    public class FormManager
    {
        public AuthenticationForm AuthenticationForm { get; }
        public RegistrationForm RegistrationForm { get; }
        public SystemForm SystemForm { get; }

        public CreateSellOrderForm CreateSellOrderForm { get; }

        public FormManager(Client client)
        {
            AuthenticationForm = new AuthenticationForm(this, client);
            RegistrationForm = new RegistrationForm(this, client);
            SystemForm = new SystemForm(this);
            CreateSellOrderForm = new CreateSellOrderForm(this);

            AuthenticationForm.FormClosing += (s, e) => { Application.Exit(); };
            RegistrationForm.FormClosing += (s, e) => { Application.Exit(); };
            SystemForm.FormClosing += (s, e) => { Application.Exit(); };
        }
    }
}
