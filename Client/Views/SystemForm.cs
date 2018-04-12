using Common;
using Common.Serializable;
using diginote_exchange_system.Views;
using MaterialSkin.Controls;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace diginote_exchange_system
{
    public partial class SystemForm : MaterialForm
    {
        public SystemForm()
        {
            InitializeComponent();
            Client.State.EventRepeater.QuoteUpdated += OnQuoteUpdated;
            Client.State.AvailableDiginotesUpdated += OnDiginotesUpdated;
            Client.State.PurchaseOrdersUpdated += OnPurchaseOrdersUpdated;
            Client.State.SellOrdersUpdated += OnSellOrdersUpdated;
        }

        private void OnPurchaseOrdersUpdated(object sender, PurchaseOrder[] updatedPurchaseOrders)
        {
            BindingList<PurchaseOrder> dataSource = new BindingList<PurchaseOrder>();
            foreach (PurchaseOrder el in updatedPurchaseOrders)
            {
                dataSource.Add(el);
            }
            PurchaseOrdersGridView.DataSource = new BindingList<PurchaseOrder>(updatedPurchaseOrders);
        }
        private void OnSellOrdersUpdated(object sender, SellOrder[] updatedSellOrders)
        {
            BindingList<SellOrder> dataSource = new BindingList<SellOrder>();
            foreach (SellOrder el in updatedSellOrders)
            {
                dataSource.Add(el);
            }
            SellOrdersGridView.DataSource = dataSource;
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
            SellOrdersGridView.DataSource = new BindingList<SellOrder>(); 
            PurchaseOrdersGridView.DataSource = new BindingList<PurchaseOrder>();
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

       /* private void btnDelete_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.SellOrdersGridView.SelectedRows)
            {
                SellOrdersGridView.Rows.RemoveAt(item.Index);
            }
        }*/

        private void btnDeleteOrders_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.SellOrdersGridView.SelectedRows)
            {
                SellOrdersGridView.Rows.RemoveAt(item.Index);
            }
        }
    }
}
