using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Windows.Forms;
using diginote_exchange_system.Views;

namespace diginote_exchange_system
{
    public partial class AuthenticationForm : MaterialForm
    {
        private readonly FormManager formManager;

        private readonly Client client;

        public AuthenticationForm(FormManager formManager, Client client)
        {
            this.formManager = formManager;
            this.client = client;

            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void signInButton_Click(object sender, EventArgs e)
        {
            String nickname = nicknameTextField.Text;
            String password = passwordTextField.Text;

            Tuple<string, Exception> result = StateManager.getInstance().Server.Login(nickname, password);
            string token = result.Item1;
            Exception exception = result.Item2;

            if (exception != null)
            {
                MessageBox.Show(exception.Message, "Sign in failed");
                passwordTextField.Text = String.Empty;
            }
            else
            {
                StateManager.getInstance().Token = token;
                formManager.SystemForm.Show();
                Hide();
            }
        }

        private void signUpButton_Click(object sender, EventArgs e)
        {
            formManager.RegistrationForm.Show();
            Hide();
        }
    }
}
