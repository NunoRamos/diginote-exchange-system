using diginote_exchange_system.Views;
using System.Windows.Forms;

namespace diginote_exchange_system
{
    public class FormManager
    {
        public AuthenticationForm AuthenticationForm { get; set; }

        public RegistrationForm RegistrationForm { get; set; }

        public SystemForm SystemForm { get; set; }

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
