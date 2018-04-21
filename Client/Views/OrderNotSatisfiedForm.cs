using Common;
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
    public partial class OrderNotSatisfiedForm : MaterialForm
    {
        private readonly OrderType orderType;

        public OrderNotSatisfiedForm(OrderType orderType, int diginotesLeft)
        {
            this.orderType = orderType;
            InitializeComponent();

            CurrentQuoteTextField.Text = Client.State.CurrentQuote.ToString();
            ValueTextField.Text = Client.State.CurrentQuote.ToString();
            Text = orderType == OrderType.Purchase ? "Purchase" : "Sell";
            Text += " Order Not Satisfied";
            Client.State.QuoteUpdated += OnQuoteUpdated;
            DiginotesLeftTextField.Text = diginotesLeft.ToString();
        }

        private void OnQuoteUpdated(object sender, float newQuote)
        {
            CurrentQuoteTextField.Invoke(new Action(() => CurrentQuoteTextField.Text = newQuote.ToString()));
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            int diginotesLeft = int.Parse(DiginotesLeftTextField.Text);
            float value = float.Parse(ValueTextField.Text);

            Exception exception =
                orderType == OrderType.Purchase
                ? Client.State.ConfirmPurchaseOrder(diginotesLeft, value)
                : Client.State.ConfirmSellOrder(diginotesLeft, value);

            if (exception != null)
            {
                MessageBox.Show("Could not confirm order.\n" + exception.Message);
                Client.State.GetUserIncompletePurchaseOrders();
                Client.State.GetUserIncompleteSellOrders();
            }
            else
            {
                MessageBox.Show((orderType == OrderType.Purchase ? "Purchase" : "Sell") + " order successfully placed.");
                Close();
            }
        }
    }
}
