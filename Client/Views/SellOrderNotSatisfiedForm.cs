using MaterialSkin.Controls;
using System;
using System.Windows.Forms;

namespace diginote_exchange_system.Views
{
    public partial class SellOrderNotSatisfiedForm : MaterialForm
    {
        public SellOrderNotSatisfiedForm()
        {
            InitializeComponent();
            CurrentQuoteTextField.Text = Client.State.CurrentQuote.ToString();
            Client.State.EvntRepeater.QuoteUpdated += OnQuoteUpdated;
        }

        public void UpdateDiginotesLeft(int diginotesLeft)
        {
            DiginotesLeftTextField.Text = "" + diginotesLeft;
        }

        private void OnQuoteUpdated(float? newQuote)
        {
            CurrentQuoteTextField.Text = newQuote.ToString();
        }

        private void BackButton_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void ConfirmButton_Click(object sender, System.EventArgs e)
        {
            float value = float.Parse(ValueTextField.Text);
            int diginotesLeft = int.Parse(DiginotesLeftTextField.Text);
            Exception exception = Client.State.Server.ConfirmSellOrder(Client.State.Token, diginotesLeft, value);

            if (exception != null)
            {
                MessageBox.Show(exception.ToString());
            }
            else
            {
                MessageBox.Show("Sell order successfully placed.");
            }
        }
    }
}
