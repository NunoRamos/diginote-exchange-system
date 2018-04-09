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
    public partial class PurchaseOrderNotSatisfiedForm : MaterialForm
    {
        public PurchaseOrderNotSatisfiedForm()
        {
            InitializeComponent();
            CurrentQuoteTextField.Text = Client.State.CurrentQuote.ToString();
            Client.State.EvntRepeater.QuoteUpdated += OnQuoteUpdated;
        }

        private void OnQuoteUpdated(float? newQuote)
        {
            CurrentQuoteTextField.Text = newQuote.ToString();
        }

        public void UpdateDiginotesLeft(int diginotesLeft)
        {
            DiginotesLeftTextField.Text = diginotesLeft.ToString();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            float value = float.Parse(ValueTextField.Text);
            int diginotesLeft = int.Parse(DiginotesLeftTextField.Text);
            Exception exception = Client.State.Server.ConfirmPurchaseOrder(Client.State.Token, diginotesLeft, value);

            if (exception != null)
            {
                MessageBox.Show(exception.ToString());
            }
            else
            {
                MessageBox.Show("Purchase Order successfully placed.");
            }
        }
    }
}
