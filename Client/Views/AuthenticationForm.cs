using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Windows.Forms;
using diginote_exchange_system.Views;

namespace diginote_exchange_system
{
    public partial class AuthenticationForm : MaterialForm
    {
        public AuthenticationForm()
        {
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

            Exception exception = Client.State.Login(nickname, password);

            if (exception != null)
            {
                MessageBox.Show(exception.Message, "Sign in failed");
                passwordTextField.Text = String.Empty;
            }
            else
            {
                Client.Forms.SystemForm = new SystemForm();
                Client.Forms.SystemForm.Show();
                Hide();
            }
        }

        private void signUpButton_Click(object sender, EventArgs e)
        {
            Client.Forms.RegistrationForm = new RegistrationForm();
            Client.Forms.RegistrationForm.Show();
            Hide();
        }

        private void AuthenticationForm_Load(object sender, EventArgs e)
        {
            nicknameTextField.Focus();
        }
    }
}
