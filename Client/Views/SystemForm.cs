using Common;
using Common.Serializable;
using diginote_exchange_system.Views;
using MaterialSkin.Controls;
using System;
using System.Windows.Forms;

namespace diginote_exchange_system
{
    public partial class SystemForm : MaterialForm
    {
        public SystemForm()
        {
            InitializeComponent();
            Client.State.EvntRepeater.QuoteUpdated += OnQuoteUpdated;
            Client.State.AvailableDiginotesUpdated += OnDiginotesUpdated;
            Client.State.PurchaseOrdersUpdated += OnPurchaseOrdersUpdated;
            Client.State.SellOrdersUpdated += OnSellOrdersUpdated;
        }

        private void OnPurchaseOrdersUpdated(object sender, PurchaseOrder[] updatedPurchaseOrders)
        {
            PurchaseOrdersGridView.DataSource = updatedPurchaseOrders;
        }
        private void OnSellOrdersUpdated(object sender, SellOrder[] updatedSellOrders)
        {
            SellOrdersGridView.DataSource = updatedSellOrders;
        }

        private void OnDiginotesUpdated(object sender, int diginotes)
        {
            DiginotesTextField.Text = diginotes.ToString();
        }


        private void OnQuoteUpdated(float newQuote)
        {
            CurrentQuoteTextField.Text = newQuote.ToString();
        }

        private void signOutButton_Click(object sender, EventArgs e)
        {
            Client.State.SignOut();
            Client.Forms.SystemForm.Hide();
            Client.Forms.AuthenticationForm.Show();
            SellOrdersGridView.DataSource = new Order[] { }; 
            PurchaseOrdersGridView.DataSource = new Order[] { };
        }

        private void SystemForm_Shown(object sender, EventArgs e)
        {
            Client.State.GetAvailableDiginotes();
            Client.State.GetUserIncompleteSellOrders();
            Client.State.GetUserIncompletePurchaseOrders();
            OnQuoteUpdated(Client.State.GetCurrentQuote());
        }

        private void PlaceOrderButton_Click(object sender, EventArgs e)
        {
            OrderType orderType = PurchaseRadioButton.Checked ? OrderType.Purchase : OrderType.Sell;
            int quantity = decimal.ToInt32(DiginoteNumberNumericUpDown.Value);

            Tuple<Exception, OrderNotSatisfiedException> result =
                orderType == OrderType.Purchase
                ? Client.State.CreatePurchaseOrder(quantity)
                : Client.State.CreateSellOrder(quantity);

            MessageBox.Show(result.ToString());

            if (result.Item2 != null)
            {
                var form = new OrderNotSatisfiedForm(orderType, result.Item2.Quantity);
                form.ShowDialog(this);
            }

            Client.State.GetAvailableDiginotes();
            Client.State.GetUserIncompletePurchaseOrders();
            Client.State.GetUserIncompleteSellOrders();
        }

        private void HistoryButton_Click(object sender, EventArgs e)
        {
            new HistoryForm().ShowDialog(this);
        }
    }
}
