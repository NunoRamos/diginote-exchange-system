using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace diginote_exchange_system.Views
{
    public partial class RegistrationForm : MaterialForm
    {
        private Client client;

        public RegistrationForm(Client client)
        {
            this.client = client;
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
            bool success = client.serverObj.Register(name, nickname, password);

            if (!success)
            {
                MessageBox.Show("Sign up failed!");
                return;
            }
            
            var systemForm = new SystemForm();
            
            systemForm.Show();
            Hide();
        }
    }
}
