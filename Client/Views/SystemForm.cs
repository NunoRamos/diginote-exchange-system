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

namespace diginote_exchange_system
{
    public partial class SystemForm : MaterialForm
    {
        public SystemForm()
        {
            InitializeComponent();
            Client.State.EvntRepeater.QuoteUpdated += OnQuoteUpdated;
        }


        private void OnQuoteUpdated(float? newQuote)
        {
            CurrentQuoteTextField.Text = newQuote.ToString();
        }

        private void signOutButton_Click(object sender, EventArgs e)
        {
            Client.State.SignOut();
            Client.Forms.SystemForm.Hide();
            Client.Forms.AuthenticationForm.Show();
        }

        private void CreateSellOrderButton_Click(object sender, EventArgs e)
        {
            Client.Forms.CreateSellOrderForm.ShowDialog(this);
        }

        private void SystemForm_Shown(object sender, EventArgs e)
        {
            DiginotesTextField.Text = Client.State.Server.GetDiginotes(Client.State.Token).ToString();
            OnQuoteUpdated(Client.State.Server.GetCurrentQuote());
        }

        private void CreatePurchaseOrderButton_Click_1(object sender, EventArgs e)
        {
            Client.Forms.CreatePurchaseOrderForm.ShowDialog(this);
        }
    }
}
