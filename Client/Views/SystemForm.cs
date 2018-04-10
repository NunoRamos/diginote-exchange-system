using Common;
using Common.Models;
using diginote_exchange_system.Views;
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
            Client.State.DiginotesUpdated += OnDiginotesUpdated;
            Client.State.PurchaseOrdersUpdated += OnPurchaseOrdersUpdated;
            Client.State.SellOrdersUpdated += OnSellOrdersUpdated;
        }

        private void OnPurchaseOrdersUpdated(object sender, Order[] updatedPurchaseOrders)
        {
            PurchaseOrdersGridView.DataSource = updatedPurchaseOrders;
        }
        private void OnSellOrdersUpdated(object sender, Order[] updatedSellOrders)
        {
            SellOrdersGridView.DataSource = updatedSellOrders;
        }

        private void OnDiginotesUpdated(object sender, int diginotes)
        {
            DiginotesTextField.Text = diginotes.ToString();
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

        private void SystemForm_Shown(object sender, EventArgs e)
        {
            DiginotesTextField.Text = Client.State.Server.GetDiginotes(Client.State.Token).ToString();
            OnQuoteUpdated(Client.State.Server.GetCurrentQuote());
        }

        private void SystemForm_Load(object sender, EventArgs e)
        {
            SellOrdersGridView.DataSource = Client.State.GetUserSellOrders();
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

            Client.State.GetUserPurchaseOrders();
            Client.State.GetUserSellOrders();
        }
    }
}
