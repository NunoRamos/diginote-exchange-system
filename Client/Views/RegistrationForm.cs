using MaterialSkin.Controls;
using System;
using System.Windows.Forms;

namespace diginote_exchange_system.Views
{
    public partial class RegistrationForm : MaterialForm
    {
        public RegistrationForm()
        {
            InitializeComponent();
        }

        private void createAccountButton_Click(object sender, EventArgs e)
        {
            String name = nameTextField.Text;
            String nickname = nicknameTextField.Text;
            String password = passwordTextField.Text;
            String repeatPassword = repeatPasswordTextField.Text;

            if (name.Length == 0 || nickname.Length == 0 || password.Length == 0 || repeatPassword.Length == 0)
            {
                errorBoxLabel.Visible = true;
                errorBoxLabel.Text = "All fields are required!";

                return;
            }

            if (!password.Equals(repeatPassword))
            {
                errorBoxLabel.Visible = true;
                errorBoxLabel.Text = "Passwords don't match!";
                repeatPasswordTextField.Text = String.Empty;

                return;
            }

            // Create account function call

            //TODO: Return error instead of boolean to show the user why something failed
            Tuple<string, Exception> result = Client.StateManager.Server.Register(name, nickname, password);
            string token = result.Item1;
            Exception exception = result.Item2;

            if (exception != null)
            {
                MessageBox.Show("Sign up failed!\n" + exception.ToString());
                return;
            } else
            {
                Client.StateManager.Token = token;
            }

            Client.FormManager.SystemForm.Show();
            Hide();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            Client.FormManager.AuthenticationForm.Show();
            Hide();
        }
    }
}
