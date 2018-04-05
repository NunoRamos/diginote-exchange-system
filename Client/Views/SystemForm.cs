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
            Client.StateManager.EvntRepeater.QuoteUpdated += OnQuoteUpdated;
        }


        private void OnQuoteUpdated(float? newQuote)
        {
            CurrentQuoteTextField.Text = newQuote == null ? "N/A" : newQuote.ToString();
        }

        private void signOutButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void CreateSellOrderButton_Click(object sender, EventArgs e)
        {
            Client.FormManager.CreateSellOrderForm.ShowDialog(this);
        }

        private void SystemForm_Shown(object sender, EventArgs e)
        {
            DiginotesTextField.Text = Client.StateManager.Server.GetDiginotes(Client.StateManager.Token).ToString();
        }
    }
}
