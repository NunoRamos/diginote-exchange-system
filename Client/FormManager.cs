using diginote_exchange_system.Views;
using System.Windows.Forms;

namespace diginote_exchange_system
{
    public class FormManager
    {
        public AuthenticationForm AuthenticationForm { get; }

        public RegistrationForm RegistrationForm { get; }

        public SystemForm SystemForm { get; }

        public FormManager()
        {
            AuthenticationForm = new AuthenticationForm();
            RegistrationForm = new RegistrationForm();
            SystemForm = new SystemForm();

            AuthenticationForm.FormClosing += (s, e) => { Application.Exit(); };
            RegistrationForm.FormClosing += (s, e) => { Application.Exit(); };
            SystemForm.FormClosing += (s, e) => { Application.Exit(); };
        }
    }
}
