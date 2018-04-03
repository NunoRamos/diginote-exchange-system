using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Windows.Forms;
using System.Runtime.Remoting.Channels;
using diginote_exchange_system.Views;

namespace diginote_exchange_system
{
    public partial class AuthenticationForm : MaterialForm
    {
        private Client client;

        public AuthenticationForm(Client client)
        {
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

            bool loggedIn = client.serverObj.Login(nickname, password);

            if(!loggedIn)
            {
                MessageBox.Show("Invalid credentials. Please try again.");
                passwordTextField.Text = String.Empty;
            }
            else
            {
                var systemForm = new SystemForm();

                systemForm.FormClosed += SystemForm_FormClosed;
                systemForm.Show();
                Hide();
            }
        }

        private void SystemForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Show();
        }

        private void signUpButton_Click(object sender, EventArgs e)
        {
            var registrationForm = new RegistrationForm(client);

            registrationForm.Show();
            Hide();
        }
    }
}
