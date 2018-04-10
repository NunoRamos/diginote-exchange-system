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
            Text = orderType == OrderType.Purchase ? "Purchase" : "Sell";
            Text += " Order Not Satisfied";
            Client.State.EvntRepeater.QuoteUpdated += OnQuoteUpdated;
            DiginotesLeftTextField.Text = diginotesLeft.ToString();
        }

        private void OnQuoteUpdated(float? newQuote)
        {
            CurrentQuoteTextField.Text = newQuote.ToString();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            int diginotesLeft = int.Parse(DiginotesLeftTextField.Text);
            Exception exception =
                orderType == OrderType.Purchase
                ? Client.State.Server.ConfirmPurchaseOrder(Client.State.Token, diginotesLeft, float.Parse(ValueTextField.Text))
                : Client.State.Server.ConfirmSellOrder(Client.State.Token, diginotesLeft, float.Parse(ValueTextField.Text));

            if (exception != null)
            {
                MessageBox.Show(exception.ToString());
                Client.State.GetUserPurchaseOrders();
                Client.State.GetUserSellOrders();
            }
            else
            {
                MessageBox.Show((orderType == OrderType.Purchase ? "Purchase" : "Sell") + " order successfully placed.");
                Close();
            }
        }
    }
}
