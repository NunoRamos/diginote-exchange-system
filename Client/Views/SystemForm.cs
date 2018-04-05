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
        private readonly FormManager formManager;

        public SystemForm()
        {
            InitializeComponent();
            Client.StateManager.Server.OnQuoteUpdated += OnQuoteUpdated;
        }

        private void OnQuoteUpdated(object sender, float? newQuote)
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
    }
}
