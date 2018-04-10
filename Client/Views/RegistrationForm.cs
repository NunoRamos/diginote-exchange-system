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

            Exception exception = Client.State.Register(name, nickname, password);

            if (exception != null)
            {
                MessageBox.Show("Sign up failed!\n" + exception.ToString());
                return;
            }

            nameTextField.Clear();
            nicknameTextField.Clear();
            passwordTextField.Clear();
            repeatPasswordTextField.Clear();

            Client.Forms.SystemForm.Show();
            Hide();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            Client.Forms.AuthenticationForm.Show();
            Hide();
        }
    }
}
